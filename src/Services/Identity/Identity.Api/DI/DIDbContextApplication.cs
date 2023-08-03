namespace Identity.Api.DI;

public static class DIDbContextApplication
{
	public static IServiceCollection AddDIDbContextApplication(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<IdentityAppDbContext>(options =>
		{
			options.UseNpgsql(configuration.GetSection("ConnectionIdentity").Value, opt => {
				opt.EnableRetryOnFailure(maxRetryCount:15, maxRetryDelay: TimeSpan.FromSeconds(20), errorCodesToAdd : null);
			});

			options.UseOpenIddict();
		});

		return services;
	}
}

