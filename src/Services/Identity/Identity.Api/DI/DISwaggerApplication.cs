namespace Identity.Api.DI;

public static class DISwaggerApplication
{
	public static IServiceCollection AddDISwaggerApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSwaggerGen(c =>
        {
            c.EnableAnnotations();
            c.SwaggerDoc("v1",
                         new OpenApiInfo
                         {
                             Title = "Identity Api",
                             Version = "v1",
                             Description = "Identity Services Api",
                             Contact = new OpenApiContact { Name = "Oscar Rojas", Url = new Uri("https://www.github.com/ojrojas") }
                         });
            c.AddSecurityDefinition("OAuth2", new OpenApiSecurityScheme
            {
                Scheme = "OAuth2",
                In = ParameterLocation.Header,
                Description = "OAuth authorization security scheme",
                Name = "Authorization",
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows
                {
                    ClientCredentials = new OpenApiOAuthFlow
                    {
                        AuthorizationUrl = new Uri($"{configuration["IdentityUrl"]}/connect/authorize"),
                        TokenUrl = new Uri($"{configuration["IdentityUrl"]}/connect/token"),
                        Scopes = { { "identity", "Resource scope" } }
                    }
                }
            });

            /// add security requeriments
            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
          {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "OAuth2"
                    },
                    Scheme = "oauth2",
                },
                new List<string>()
            }
          });
        });

        return services;
    }
}

