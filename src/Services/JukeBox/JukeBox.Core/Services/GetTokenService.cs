namespace JukeBox.Core.Services;

public class GetTokenService : IGetTokenService
{
    private readonly ILoggingApplication<JukeBoxService> _logger;
    private readonly IConfiguration _configuration;
    private HttpClient _httpClient;

    public GetTokenService(ILoggingApplication<JukeBoxService> logger, IConfiguration configuration)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _configuration = configuration;
    }

    public async ValueTask<SpocifyIdentity> GetRefreshTokenAsync(SpocifyIdentity identity, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Getting a refresh token");
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
            "Basic", $"{GetValueFromConfigurationToBase64("ClientIdSpotify")}:{GetValueFromConfigurationToBase64("SecretClientSpotify")}");

        var content = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string> ("grant_type", "refresh_token"),
            new KeyValuePair<string, string> ("refresh_token", identity.RefreshToken)
        });

        var response = await _httpClient.PostAsync("https://accounts.spotify.com/api/token", content);
        response.EnsureSuccessStatusCode();
        var stringContent = await response.Content.ReadAsStringAsync();
        var newRefresToken = JsonSerializer.Deserialize<RefreshToken>(stringContent);
        identity.Token = newRefresToken.access_token;
        return identity;
    }

    private string GetValueFromConfigurationToBase64(string section)
    {
        var value = _configuration.GetSection(section).Value;
        var encode = System.Text.Encoding.UTF8.GetBytes(value);
        return Convert.ToBase64String(encode);
    }
}

