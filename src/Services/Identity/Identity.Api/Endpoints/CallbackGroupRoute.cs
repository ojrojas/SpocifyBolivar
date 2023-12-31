﻿namespace Identity.Api.Endpoints;

public static class CallbackGroupRoute
{
    public static RouteGroupBuilder AddCallbackGroupRoute(this RouteGroupBuilder group)
    {
        CallbackLogin(group);
        Login(group);

        return group;
    }

    private static RouteHandlerBuilder Login(RouteGroupBuilder group)
    {
        return group.MapGet("/login", (HttpContext _context, OpenIddictClientService _service, CancellationToken cancellationToken) =>
        {
            return Results.Challenge(properties: new AuthenticationProperties(new Dictionary<string, string?>
            {
                [OpenIddictClientAspNetCoreConstants.Properties.ProviderName] =
                OpenIddictClientWebIntegrationConstants.Providers.Spotify
            }),
            authenticationSchemes: new[]
            {
                OpenIddictClientAspNetCoreDefaults.AuthenticationScheme
            });
        });
    }

    private static RouteHandlerBuilder CallbackLogin(RouteGroupBuilder group)
    {
        return group.MapMethods("/callback/login/spotify", new[] { HttpMethods.Get, HttpMethods.Post },
            async (HttpContext _context, ICacheApplicationService _cache, IOpenIddictApplicationManager _manager) =>
            {
                var result = await _context.AuthenticateAsync(OpenIddictClientAspNetCoreDefaults.AuthenticationScheme);
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                var userid = result.Principal.FindFirst("id").Value;

                ArgumentNullException.ThrowIfNull(userid, "undefined user id response real spotify");

                SpocifyIdentity spocify = new()
                {
                    Id = result.Principal!.FindFirst("id")!.Value,
                    FullName = result.Principal!.FindFirst("display_name")!.Value,
                    Token = result.Properties.Items.First(x => x.Key.Equals(".Token.backchannel_access_token"))!.Value,
                    RefreshToken = result.Properties.Items.First(x => x.Key.Equals(".Token.refresh_token"))!.Value,
                    StateSpocify = result.Properties.Items.First(x => x.Key.Equals(".Token.state_token"))!.Value,
                    Code = result.Properties.Items.First(x => x.Key.Equals(".Token.authorization_code"))!.Value,
                    State = BuildingBlock.Infraestructure.Data.BaseEntityState.Active,
                    CreateOn = DateTimeOffset.UtcNow,
                };

                await _cache.SetAsync(userid, spocify);

                var properties = new AuthenticationProperties
                {
                    RedirectUri = $"http://localhost:3000/logincallback/{userid}",
                };

                return Results.SignIn(new ClaimsPrincipal(identity), properties: properties, CookieAuthenticationDefaults.AuthenticationScheme);
            });
    }
}