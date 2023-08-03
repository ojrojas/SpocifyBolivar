namespace Identity.Api.DI;

public static class DIServicesApplication
{
	public static IServiceCollection AddDIServicesApplication(this IServiceCollection services)
	{
		services.AddTransient(typeof(ILoggingApplication<>), typeof(LoggingApplication<>));
		services.AddTransient<IApplicationUserService, ApplicationUserService>();
		services.AddTransient<ICacheApplicationService, CacheApplicationService>();
        services.AddTransient<InitializerDbContext>();

        return services;
	}
}

