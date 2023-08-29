namespace Identity.Core.Data;

public class InitializerDbContext
{
    private readonly IdentityAppDbContext _context;
    private readonly IPasswordHasher<ApplicationUser> _passwordHasher = new PasswordHasher<ApplicationUser>();

    public InitializerDbContext(IdentityAppDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public virtual async Task Run()
    {
#if DEBUG
        try
        {
            await _context.Database.EnsureDeletedAsync();
            await _context.Database.EnsureCreatedAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
#endif
    }

    public virtual async Task RunConfigurationDbContext(IOpenIddictApplicationManager manager, IOpenIddictScopeManager _scopeManager, Dictionary<string, string> clientsUrls)
    {
        try
        {
            if (await manager.FindByClientIdAsync("identityswaggerui") is null)
            {
                await manager.CreateAsync(new OpenIddictApplicationDescriptor
                {
                    ClientId = "identityswaggerui",
                    DisplayName = "Identity Swagger UI",
                    ClientSecret = "a961a072-4a69-4b10-bc17-1551d454d44c",
                    ConsentType = ConsentTypes.Implicit,
                   // RedirectUris = { new Uri($"{clientsUrls["IdentityApi"]}/swagger/oauth2-redirect.html") },
                    RedirectUris = { new Uri($"{clientsUrls["IdentityApi"]}/callback/login/spotify") },
                    Permissions = {
                        Permissions.Endpoints.Token,
                        Permissions.Endpoints.Logout,
                        Permissions.GrantTypes.AuthorizationCode,
                        Permissions.GrantTypes.ClientCredentials,
                        Permissions.GrantTypes.Password,
                        Permissions.Endpoints.Authorization,
                        Permissions.ResponseTypes.Code,
                        Permissions.Scopes.Email,
                        Permissions.Scopes.Profile,
                        Permissions.Scopes.Roles,
                        Permissions.Prefixes.Scope + "identity",
                    },
                    PostLogoutRedirectUris = { new Uri($"{clientsUrls["IdentityApi"]}/swagger") },
                    Requirements = { Requirements.Features.ProofKeyForCodeExchange }
                });
            }

            if (await manager.FindByClientIdAsync("jukeboxswaggerui") is null)
            {
                await manager.CreateAsync(new OpenIddictApplicationDescriptor
                {
                    ClientId = "jukeboxswaggerui",
                    DisplayName = "JukeBox Swagger UI",
                    ClientSecret = "ecc12056-5ac5-4067-938a-544c0a579f31",
                    ConsentType = ConsentTypes.Implicit,
                    // RedirectUris = { new Uri($"{clientsUrls["IdentityApi"]}/swagger/oauth2-redirect.html") },
                    RedirectUris = { new Uri($"{clientsUrls["JukeBoxApi"]}/callback/login/spotify") },
                    Permissions = {
                        Permissions.Endpoints.Token,
                        Permissions.Endpoints.Logout,
                        Permissions.GrantTypes.AuthorizationCode,
                        Permissions.GrantTypes.ClientCredentials,
                        Permissions.GrantTypes.Password,
                        Permissions.Endpoints.Authorization,
                        Permissions.ResponseTypes.Code,
                        Permissions.Scopes.Email,
                        Permissions.Scopes.Profile,
                        Permissions.Scopes.Roles,
                        Permissions.Prefixes.Scope + "jukebox",
                    },
                    PostLogoutRedirectUris = { new Uri($"{clientsUrls["JukeBoxApi"]}/swagger") },
                    Requirements = { Requirements.Features.ProofKeyForCodeExchange }
                });
            }

            if (await manager.FindByClientIdAsync("spocifyweb-client") is null)
            {
                await manager.CreateAsync(new OpenIddictApplicationDescriptor
                {
                    ClientId = "spocifyweb-client",
                    DisplayName = "Spocify Bolivar",
                    ClientSecret = "25d91591-0e59-4241-8086-6f5202e5a409",
                   
                    RedirectUris = { new Uri($"http://localhost:3000/logincallback") },
                    Permissions = {
                        Permissions.Endpoints.Token,
                        Permissions.Endpoints.Authorization,
                        Permissions.GrantTypes.Password,
                        Permissions.ResponseTypes.Token,
                        Permissions.Scopes.Email,
                        Permissions.Scopes.Profile,
                        Permissions.Scopes.Roles,
                        Permissions.Prefixes.Scope + "aggregator",
                        Permissions.Prefixes.Scope + "jukebox",

                    },
                    PostLogoutRedirectUris = { new Uri($"http://localhost:3000") },
                });
            }

            if (await _scopeManager.FindByNameAsync("aggregator") is null)
            {
                await _scopeManager.CreateAsync(new OpenIddictScopeDescriptor
                {
                    Name = "aggregator",
                    DisplayName = "Aggregator Api",
                    Resources = {
                        "resource_aggregator"
                    }
                });
            }

            if (await _scopeManager.FindByNameAsync("jukebox") is null)
            {
                await _scopeManager.CreateAsync(new OpenIddictScopeDescriptor
                {
                    Name = "jukebox",
                    DisplayName = "JukeBox Api",
                    Resources = {
                        "resource_jukebox"
                    }
                });
            }
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException(ex.Message, ex);
        }
    }

    public virtual async Task RunConfigurationDbContextTesting(IOpenIddictApplicationManager manager)
    {
        try
        {
            if (await manager.FindByClientIdAsync("identityswaggeruitesting") is null)
            {
                await manager.CreateAsync(new OpenIddictApplicationDescriptor
                {
                    ClientId = "identityswaggeruitesting",
                    DisplayName = "Identity Swagger UI Testing",
                    ClientSecret = "187b02a3-7611-4a05-974c-3337655d169b",
                    Permissions = {
                        Permissions.Endpoints.Token,
                        Permissions.GrantTypes.ClientCredentials,
                        Permissions.Prefixes.Scope + "identity",
                    },
                });
            }
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException(ex.Message, ex);
        }
    }


}