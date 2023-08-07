namespace JukeBox.Api.DI;

public static class DIOpenIddictApplication
{
    public static IServiceCollection AddDIOpenIddictApplication(this IServiceCollection services)
    {
        services.AddOpenIddict()
            .AddValidation(config =>
            {
                config.SetIssuer("http://docker.for.mac.localhost:5005/");
                config.AddAudiences("resource_jukebox");

                //// Spocify3d9c278b-82d1-4b88-944c-82193bea0595
                config.AddEncryptionKey(
                    new SymmetricSecurityKey(
                        Convert.FromBase64String("U3BvY2lmeTNkOWMyNzhiLTgyZDEtNGI4OC05NDRjLTg=")));

                // Register the System.Net.Http integration.
                config.UseSystemNetHttp();

                // Register the ASP.NET Core host.
                config.UseAspNetCore();
            });

        return services;
    }
}

