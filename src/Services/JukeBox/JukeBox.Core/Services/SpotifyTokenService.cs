namespace JukeBox.Core.Services;

public class SpotifyTokenService: ISpotifyTokenService
{
    private readonly ILoggingApplication<JukeBoxService> _logger;
    private readonly ICacheApplicationService _cache;
    private HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public SpotifyTokenService(ILoggingApplication<JukeBoxService> logger, ICacheApplicationService cache, IConfiguration configuration)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _cache = cache ?? throw new ArgumentNullException(nameof(cache));
        _configuration = configuration;
    }

    public async ValueTask<SpocifyIdentity> GetTokenAsync(string userid, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Getting token from cache");
        return  await _cache.GetValue<SpocifyIdentity>(userid, cancellationToken);
    }

    public async ValueTask<SpocifyIdentity> GetRefreshTokenAsync(string userid, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Getting a refresh token");
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
            "Basic", $"{GetValueFromConfigurationToBase64("ClientIdSpotify")}:{GetValueFromConfigurationToBase64("SecretClientSpotify")}");

        var spocify = await _cache.GetValue<SpocifyIdentity>(userid, cancellationToken);

        var content = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string> ("grant_type", "refresh_token"),
            new KeyValuePair<string, string> ("refresh_token", spocify.RefreshToken)
        });

        var response = await _httpClient.PostAsync("https://accounts.spotify.com/api/token", content);
        response.EnsureSuccessStatusCode();
        var stringContent =await response.Content.ReadAsStringAsync();
        var newRefresToken = JsonSerializer.Deserialize<RefreshToken>(stringContent);
        spocify.Token = newRefresToken.access_token;
        _cache.SetAsync(userid, spocify);
        return spocify;
    }

    private string GetValueFromConfigurationToBase64(string section)
    {
        var value= _configuration.GetSection(section).Value;
        var encode = System.Text.Encoding.UTF8.GetBytes(value);
        return Convert.ToBase64String(encode);
    }
}

