using Microsoft.IdentityModel.Logging;

var builder = WebApplication.CreateBuilder(args);
var ProgramName = "Jukebox.Api";

Log.Logger = CreateSerilogLogger(ProgramName);
var configuration = builder.Configuration;


// Add services to the container.
builder.Services.AddDIOpenIddictApplication();

builder.Services.AddDIAuthenticationAndAuthorizationApplication();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDIServiceApplication();

var connectionRedis = configuration.GetSection("CacheConnection").Value;
builder.Services.AddDICacheApplicationService(connectionRedis, "Identity.Api");

builder.Services.AddSwaggerGen();

builder.Services.AddCors(setup => {
    setup.AddPolicy("JukeBoxCors", policy => {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("JukeBoxCors");
app.UseHttpsRedirection();

app.AddDIConfigurationApplication();

app.Run();

static Serilog.ILogger CreateSerilogLogger(string programName) => new LoggerConfiguration()
        .MinimumLevel.Verbose()
        .Enrich.WithProperty("Jukebox", programName)
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .CreateLogger();

public partial class Program { }
