namespace BuildingBlock.Commons.DI;

public static class DICacheApplication
{
	public static IServiceCollection AddDICacheApplicationService(this IServiceCollection services, string connection, string InstanceApp)
	{
		ArgumentNullException.ThrowIfNull(connection, "Connection string can not be null or empty string");
        ArgumentNullException.ThrowIfNull(connection, "InstanceApp can not be null or empty string");

        services.AddStackExchangeRedisCache(setup =>
		{
			setup.Configuration = connection;
			setup.InstanceName = InstanceApp;
		});

        return services;
	}
}

