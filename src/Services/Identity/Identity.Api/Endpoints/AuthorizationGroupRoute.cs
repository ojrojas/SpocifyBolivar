namespace Identity.Api.Endpoints;

public static class AuthorizationGroupRoute
{
    public static RouteGroupBuilder AddAuthorizationGroupRoute(this RouteGroupBuilder group)
    {
        ConnectToken(group);
        ConnectAuthorize(group);

        return group;
    }

    private static RouteHandlerBuilder ConnectAuthorize(RouteGroupBuilder group)
    {
        return
            group.MapMethods("/connect/authorize",
        new[] { HttpMethods.Get, HttpMethods.Post },
        async (
            HttpContext context,
            IOpenIddictApplicationManager _applicationManager,
            IOpenIddictScopeManager _scopeManager) => {

                var request = context.GetOpenIddictServerRequest() ?? throw new InvalidOperationException("Error request operation not found clientcredentials");
                var result = await context.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                if (!result.Succeeded)
                {
                    var url = context.Request.PathBase + context.Request.Path + QueryString.Create(
                               context.Request.HasFormContentType ? context.Request.Form.ToList() : context.Request.Query.ToList());

                    return Results.Challenge(
                        properties: new AuthenticationProperties
                        {
                            RedirectUri = url,
                        }, new List<string> { CookieAuthenticationDefaults.AuthenticationScheme });
                }

                ArgumentNullException.ThrowIfNull(request.ClientId);

                var application = await _applicationManager.FindByClientIdAsync(request.ClientId);
                if (application == null)
                {
                    throw new InvalidOperationException("The application details cannot be found in the database.");
                }

                // Create the claims-based identity that will be used by OpenIddict to generate tokens.
                var identity = new ClaimsIdentity(
                    authenticationType: TokenValidationParameters.DefaultAuthenticationType,
                    nameType: Claims.Name,
                    roleType: Claims.Role);

                // Add the claims that will be persisted in the tokens (use the client_id as the subject identifier).
                identity.SetClaim(Claims.Subject, await _applicationManager.GetClientIdAsync(application));
                identity.SetClaim(Claims.Name, await _applicationManager.GetDisplayNameAsync(application));

                identity.SetScopes(request.GetScopes());
                identity.SetResources(await _scopeManager.ListResourcesAsync(identity.GetScopes()).ToListAsync());
                identity.SetDestinations(GetDestination.GetDestinations);

                return Results.SignIn(new ClaimsPrincipal(identity), new(), OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
            });
    }

    private static RouteHandlerBuilder ConnectToken(RouteGroupBuilder group)
    {
        return group.MapPost("/connect/token", [IgnoreAntiforgeryToken]
        async (HttpContext _context,
                IOpenIddictApplicationManager _applicationManager,
                IOpenIddictScopeManager _scopeManager,
                IApplicationUserService _applicationService) =>
        {
            var request = _context.GetOpenIddictServerRequest() ??
            throw new InvalidOperationException("Error request opration not found a valid request open iddict");

            var parameters = request.GetParameters();

            if (request.IsClientCredentialsGrantType())
                return await CreateSignInLogin(_applicationManager, _scopeManager, request);

            if (request.IsAuthorizationCodeGrantType())
            {
                var authentication = await _context.AuthenticateAsync(OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
                return await CreateSignInLogin(_applicationManager, _scopeManager, request, authentication);
            }

            if (request.IsPasswordGrantType())
            {
                ArgumentNullException.ThrowIfNull(request.ClientId, "Not found clientId request");
                ArgumentNullException.ThrowIfNull(request.Username, "Not found username request");
                ArgumentNullException.ThrowIfNull(request.Password, "Not found password request");

                var response = await _applicationService.LoginAsync(
                    new()
                    {
                        ClientId = request.ClientId,
                        UserName = request.Username,
                        Password = request.Password,
                        Scopes = request.GetScopes()
                    }, default);

                return response;
            }

            throw new NotImplementedException("the specified request is no a open iddict request implemented");
        });
    }

    private static async ValueTask<IResult> CreateSignInLogin(
        IOpenIddictApplicationManager _applicationManager,
        IOpenIddictScopeManager _scopeManager,
        OpenIddictRequest request,
        AuthenticateResult? authentication = null)
    {
        ArgumentNullException.ThrowIfNull(request.ClientId, "Error request not found");

        var application = await _applicationManager.FindByClientIdAsync(request.ClientId) ??
            throw new InvalidOperationException("the application details cannot be found in the database");

        ClaimsIdentity identity;

        if (authentication is not null)
            identity = new ClaimsIdentity(
                authentication?.Principal?.Claims,
                authenticationType: TokenValidationParameters.DefaultAuthenticationType,
                nameType: Claims.Name,
                roleType: Claims.Role);
        else identity = new ClaimsIdentity(
            authenticationType: TokenValidationParameters.DefaultAuthenticationType,
            nameType: Claims.Name,
            roleType: Claims.Role);

        // Add the claims that will be persisted in the tokens (use the client_id as the subject identifier).
        identity.SetClaim(Claims.Subject, await _applicationManager.GetClientIdAsync(application));
        identity.SetClaim(Claims.Name, await _applicationManager.GetDisplayNameAsync(application));

        identity.SetScopes(request.GetScopes());
        identity.SetResources(await _scopeManager.ListResourcesAsync(identity.GetScopes()).ToListAsync());
        identity.SetDestinations(GetDestination.GetDestinations);

        return Results.SignIn(new ClaimsPrincipal(identity), new(), OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
    }
}