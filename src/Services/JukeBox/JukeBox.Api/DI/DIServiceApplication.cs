namespace JukeBox.Api.DI;

public static class DIServiceApplication
{
	public static IServiceCollection AddDIServiceApplication(this IServiceCollection services)
	{
        services.AddTransient(typeof(ILoggingApplication<>), typeof(LoggingApplication<>));
        services.AddTransient<ICacheApplicationService, CacheApplicationService>();
        services.AddTransient<IJukeBoxService, JukeBoxService>();
        services.AddTransient<IIdentitySpocifyService, IdentitySpocifyService>();
        services.AddTransient<IGetTokenService, GetTokenService>();


        return services;
	}
}

