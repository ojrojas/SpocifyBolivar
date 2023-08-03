namespace Identity.Core.Services;

public class ApplicationUserService : IApplicationUserService
{
    /// <summary>
    /// Logger application services
    /// </summary>
	private readonly ILoggingApplication<ApplicationUserService> _logger;

    /// <summary>
    /// Application repository
    /// </summary>
    private readonly ICacheApplicationService _cache;
    /// <summary>
    /// UserManager
    /// </summary>
    private readonly UserManager<ApplicationUser> _userManager;
    /// <summary>
    /// Sign in manager
    /// </summary>
    private readonly SignInManager<ApplicationUser> _signInManager;

    /// <summary>
    /// Application usermanager
    /// </summary>
    private readonly IOpenIddictApplicationManager _applicationManager;

    /// <summary>
    /// Authorization manager
    /// </summary>
    private readonly IOpenIddictAuthorizationManager _authorizationManager;

    /// <summary>
    /// Scope manager open iddict
    /// </summary>
    private readonly IOpenIddictScopeManager _scopeManager;

    /// <summary>
    /// Password hasher
    /// </summary>
    private readonly IPasswordHasher<ApplicationUser> _passwordHasher = new PasswordHasher<ApplicationUser>();

    public ApplicationUserService(ILoggingApplication<ApplicationUserService> logger,
                                  ICacheApplicationService cache,
                                  UserManager<ApplicationUser> userManager,
                                  SignInManager<ApplicationUser> signInManager,
                                  IOpenIddictApplicationManager applicationManager,
                                  IOpenIddictAuthorizationManager authorizationManager,
                                  IOpenIddictScopeManager scopeManager,
                                  IPasswordHasher<ApplicationUser> passwordHasher)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _cache = cache ?? throw new ArgumentNullException(nameof(cache));
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
        _applicationManager = applicationManager ?? throw new ArgumentNullException(nameof(applicationManager));
        _authorizationManager = authorizationManager ?? throw new ArgumentNullException(nameof(authorizationManager));
        _scopeManager = scopeManager ?? throw new ArgumentNullException(nameof(scopeManager));
        _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
    }

    public async ValueTask<IResult> LoginAsync(LoginApplicationUserRequest request, CancellationToken cancellationToken)
    {
        try
        {
            LoginApplicationUserResponse response = new(request.CorrelationId())
            {
                Token = "Do not get token response"
            };

            _logger.LogInformation($"Encrypt password and get user by login");
            request.UserName = request.UserName.ToLowerInvariant();
            var result = await _cache.GetValue<SpocifyIdentity>(request.UserName.ToLower(), cancellationToken);
            if (result is not null)
            {
                // Retrieve the application details from the database.
                var application = await _applicationManager.FindByClientIdAsync(request.ClientId) ??
                    throw new InvalidOperationException("Details concerning the calling client application cannot be found.");

                // Retrieve the permanent authorizations associated with the user and the calling client application.
                var authorizations = await _authorizationManager.FindAsync(
                    subject: request.UserName,
                    client: await _applicationManager.GetIdAsync(application, cancellationToken),
                    status: Statuses.Valid,
                    type: AuthorizationTypes.Permanent,
                    scopes: request.Scopes.ToImmutableArray(),
                    cancellationToken).ToListExtensionsAsync();

                // Create the claims-based identity that will be used by OpenIddict to generate tokens.
                var identity = new ClaimsIdentity(
                    authenticationType: TokenValidationParameters.DefaultAuthenticationType,
                    nameType: Claims.Name,
                    roleType: Claims.Role);

                // Add the claims that will be persisted in the tokens.
                identity.SetClaim(Claims.Subject, request.UserName);

                // Note: in this sample, the granted scopes match the requested scope
                // but you may want to allow the user to uncheck specific scopes.
                // For that, simply restrict the list of scopes before calling SetScopes.
                identity.SetScopes(request.Scopes);
                identity.SetResources(await _scopeManager.ListResourcesAsync(identity.GetScopes()).ToListExtensionsAsync());

                // Automatically create a permanent authorization to avoid requiring explicit consent
                // for future authorization or token requests containing the same scopes.
                var authorization = authorizations.LastOrDefault();
                authorization ??= await _authorizationManager.CreateAsync(
                    identity: identity,
                    subject: request.UserName,
                    client: await _applicationManager.GetIdAsync(application),
                    type: AuthorizationTypes.Permanent,
                    scopes: identity.GetScopes());

                identity.SetAuthorizationId(await _authorizationManager.GetIdAsync(authorization));
                identity.SetDestinations(GetDestination.GetDestinations);

                // Returning a SignInResult will ask OpenIddict to issue the appropriate access/identity tokens.
                response.ActionResult = Results.SignIn(new ClaimsPrincipal(identity), new(), OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
                response.Token = "Signin successful";
            }
            else
            {
                response.ActionResult = Results.Ok(new object[] { response.Token });
            }

            return response.ActionResult;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}
