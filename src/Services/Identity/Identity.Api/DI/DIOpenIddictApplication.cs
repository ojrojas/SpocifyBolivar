namespace Identity.Api.DI;

public static class DIOpenIddictApplication
{
    public static IServiceCollection AddDIOpenIddictApplication(this IServiceCollection services)
    {
        services.AddOpenIddict()

            .AddCore(config =>
            {
                config.UseEntityFrameworkCore()
                .UseDbContext<IdentityAppDbContext>();
            })

            .AddServer(config =>
            {
                config.AllowAuthorizationCodeFlow();
                config.AllowPasswordFlow();
                config.AllowClientCredentialsFlow();

                config.RequireProofKeyForCodeExchange();

                config.SetTokenEndpointUris("connect/token");
                config.SetAuthorizationEndpointUris("connect/authorize");
                config.SetLogoutEndpointUris("connect/logout");

                // Spocify3d9c278b-82d1-4b88-944c-82193bea0595
                config.AddEncryptionKey(
                    new SymmetricSecurityKey(
                        Convert.FromBase64String("U3BvY2lmeTNkOWMyNzhiLTgyZDEtNGI4OC05NDRjLTg=")));

                config.AddSigningCertificate(Certificates.Certificate.GetCert());

                config.UseAspNetCore()
                .DisableTransportSecurityRequirement()
                .EnableAuthorizationEndpointPassthrough()
                .EnableLogoutEndpointPassthrough()
                .EnableTokenEndpointPassthrough();
            })

            .AddValidation(config =>
            {
                config.UseLocalServer();
                config.UseAspNetCore();
            })

            .AddClient(config =>
            {
                config.AllowAuthorizationCodeFlow();
                config.AllowClientCredentialsFlow();

                config.UseAspNetCore()
                .EnableRedirectionEndpointPassthrough()
                .DisableTransportSecurityRequirement();

                config.UseSystemNetHttp()
                .SetProductInformation(typeof(Program).Assembly);

                // Spocify3d9c278b-82d1-4b88-944c-82193bea0595
                config.AddEncryptionKey(
                    new SymmetricSecurityKey(
                        Convert.FromBase64String("U3BvY2lmeTNkOWMyNzhiLTgyZDEtNGI4OC05NDRjLTg=")));
                config.AddSigningCertificate(Certificates.Certificate.GetCert());

                config.UseWebProviders()
                .AddSpotify(cfg =>
                {
                    cfg.SetClientId("b25e7e1a1fad419a98938cbcf2958cc9")
                    .SetClientSecret("2396c6c3d1ef4f1692421d78e6e6ffa9")
                    .SetRedirectUri("/callback/login/spotify");
                });
            });

        return services;

    }
}

