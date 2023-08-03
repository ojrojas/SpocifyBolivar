namespace Identity.Api.DI;

public static class DIAuthenticationAndAuthorizationApplication
{
	public static IServiceCollection AddDIAuthenticationAndAuthorizationApplication(this IServiceCollection services)
	{
        services.AddAuthorization()
            .AddAuthentication(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme)
            .AddCookie();
        return services;
	}
}

