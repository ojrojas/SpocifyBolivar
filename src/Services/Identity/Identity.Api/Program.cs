var builder = WebApplication.CreateBuilder(args);
var ProgramName = "Identity.Api";

Log.Logger = CreateSerilogLogger(ProgramName);
var configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddDIDbContextApplication(configuration);

builder.Services.AddQuartz(conf =>
{
    conf.UseMicrosoftDependencyInjectionJobFactory();
    conf.UseSimpleTypeLoader();
    conf.UseInMemoryStore();
});

builder.Services.AddQuartzHostedService(options => options.WaitForJobsToComplete = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDIOpenIddictApplication(configuration);
builder.Services.AddDIIdentityServerApplication();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
var connectionRedis = configuration.GetSection("CacheConnection").Value;
builder.Services.AddDICacheApplicationService(connectionRedis, ProgramName);

builder.Services.AddSwaggerGen();
builder.Services.AddDIAuthenticationAndAuthorizationApplication();

builder.Services.AddDISwaggerApplication(configuration);
builder.Services.AddDIServicesApplication();

builder.Services.AddCors(setup =>
{
    setup.AddPolicy("IdentityCors", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddHealthChecks();

var urls = configuration["UrlsAllow"];
ArgumentNullException.ThrowIfNull(urls);
var clientUrls = TransformString.TransformStringtoDictionary(urls);

var app = builder.Build();

using var scope = app.Services.CreateScope();
var service = scope.ServiceProvider;

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    var initializer = service.GetRequiredService<InitializerDbContext>();
    var context = service.GetRequiredService<IdentityAppDbContext>();
    var _managerApplication = service.GetRequiredService<IOpenIddictApplicationManager>();
    var _managerScopes = service.GetRequiredService<IOpenIddictScopeManager>();

    await initializer.Run();

    var applied = context.Database.GetAppliedMigrations();
    await initializer.RunConfigurationDbContext(_managerApplication, _managerScopes, clientUrls);

    app.UseCors("IdentityCors");

    app.UseSwagger();
    app.UseSwaggerUI(
        options =>
        {
            options.DisplayOperationId();
            options.EnablePersistAuthorization();
            options.OAuthUseBasicAuthenticationWithAccessCodeGrant();
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Identity api v1");
            options.OAuthClientId("identityswaggerui");
            options.OAuthClientSecret("a961a072-4a69-4b10-bc17-1551d454d44c");
        });
}

app.UseHttpsRedirection();

app.AddDIConfigurationApplication();

app.Run();

static Serilog.ILogger CreateSerilogLogger(string programName) => new LoggerConfiguration()
        .MinimumLevel.Verbose()
        .Enrich.WithProperty("SpocifyApp", programName)
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .CreateLogger();

public partial class Program { }
