using System.Net;

namespace JukeBox.Core.Services;

public class JukeBoxService : IJukeBoxService
{
    private readonly ILoggingApplication<JukeBoxService> _logger;
    private readonly ISpotifyTokenService _serviceToken;
    private HttpClient? _httpClient;
    private readonly JsonSerializerOptions _serializeOptions;

    public JukeBoxService(ILoggingApplication<JukeBoxService> logger, ICacheApplicationService cache, ISpotifyTokenService tokenSpotify)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _serviceToken = tokenSpotify ?? throw new ArgumentNullException(nameof(tokenSpotify));
        _serializeOptions = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }

    public async ValueTask<SeveralBrowse> GetSeveralBrowseAsync(string request, string userid, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Getting info spotify several browser endpoint");
        var spocify = await _serviceToken.GetTokenAsync(userid, cancellationToken);
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", spocify.Token);
        var response = await _httpClient.GetAsync(SpotifyConstantsUrls.SeveralBrowseUrl(request));
        if (response.IsSuccessStatusCode is false && response.StatusCode.Equals(HttpStatusCode.Unauthorized))
        {
            var newToken = await _serviceToken.GetRefreshTokenAsync(userid, cancellationToken);
            _httpClient.DefaultRequestHeaders.Remove("Authorization");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", newToken.Token);
            response = await _httpClient.GetAsync(SpotifyConstantsUrls.SeveralBrowseUrl(request));
        }
        var contentString = await response.Content.ReadAsStringAsync();

        try
        {
            var severalBrowse = JsonSerializer.Deserialize<SeveralBrowse>(contentString, _serializeOptions);
            return severalBrowse;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async ValueTask<Search> GetSearchAsync(string request, string userid, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Getting info spotify search endpoint");
        var spocify = await _serviceToken.GetTokenAsync(userid, cancellationToken);
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", spocify.Token);
        var response = await _httpClient.GetAsync(SpotifyConstantsUrls.SearchUrl(request));
        if (response.IsSuccessStatusCode is false && response.StatusCode.Equals(HttpStatusCode.Unauthorized))
        {
            var newToken = await _serviceToken.GetRefreshTokenAsync(userid, cancellationToken);
            _httpClient.DefaultRequestHeaders.Remove("Authorization");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", newToken.Token);
            response = await _httpClient.GetAsync(SpotifyConstantsUrls.SearchUrl(request));
        }
        var contentString = await response.Content.ReadAsStringAsync();
        try
        {
            var search = JsonSerializer.Deserialize<Search>(contentString, _serializeOptions);
            return search;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async ValueTask<Artist> GetArtistAsync(string request, string userid, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Getting info spotify artist endpoint");
        var spocify = await _serviceToken.GetTokenAsync(userid, cancellationToken);
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", spocify.Token);
        var response = await _httpClient.GetAsync(SpotifyConstantsUrls.ArtistUrl(request));
        if (response.IsSuccessStatusCode is false && response.StatusCode.Equals(HttpStatusCode.Unauthorized))
        {
            var newToken = await _serviceToken.GetRefreshTokenAsync(userid, cancellationToken);
            _httpClient.DefaultRequestHeaders.Remove("Authorization");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", newToken.Token);
            response = await _httpClient.GetAsync(SpotifyConstantsUrls.ArtistUrl(request));
        }

        var contentString = await response.Content.ReadAsStringAsync();
        try
        {
            var artist = JsonSerializer.Deserialize<Artist>(contentString, _serializeOptions);
            return artist;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}

