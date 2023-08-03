using Microsoft.IdentityModel.Logging;

namespace JukeBox.Api.DI;

public static class DIAuthenticationAndAuthorizationApplication
{
    public static IServiceCollection AddDIAuthenticationAndAuthorizationApplication(this IServiceCollection services)
    {
        services.AddAuthentication(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme);
        services.AddAuthorization();

        IdentityModelEventSource.ShowPII = true;
        return services;
    }
}

