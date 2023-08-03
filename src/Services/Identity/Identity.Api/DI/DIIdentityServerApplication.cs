namespace Identity.Api.DI;

public static class DIIdentityServerApplication
{
	public static IServiceCollection AddDIIdentityServerApplication(this IServiceCollection services)
	{
        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<IdentityAppDbContext>()
            .AddDefaultTokenProviders();
        return services;
	}
}

