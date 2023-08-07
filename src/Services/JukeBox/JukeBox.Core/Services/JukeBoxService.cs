namespace JukeBox.Core.Services;

public class JukeBoxService : IJukeBoxService
{
    private readonly ILoggingApplication<JukeBoxService> _logger;
    private readonly IIdentitySpocifyService _service;
    private readonly IGetTokenService _tokenService;
    private HttpClient _httpClient;

    public JukeBoxService(ILoggingApplication<JukeBoxService> logger, IIdentitySpocifyService service)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    public async ValueTask<SearchResponse> GetSearchAsync(string request, ClaimsPrincipal principals, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Getting info spotify search endpoint");
            SpocifyIdentity spocify = _service.GetSpocifyIdentity(principals);
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", spocify.Token);
            var response = await _httpClient.GetAsync(SpotifyConstantsUrls.SearchUrl(request));
            if (response.IsSuccessStatusCode is false && response.StatusCode.Equals(HttpStatusCode.Unauthorized))
            {
                var newToken = await _tokenService.GetRefreshTokenAsync(spocify, cancellationToken);
                _httpClient.DefaultRequestHeaders.Remove("Authorization");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", newToken.Token);
                response = await _httpClient.GetAsync(SpotifyConstantsUrls.SearchUrl(request));
            }
            var contentString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<SearchResponse>(contentString, GetJsonSerializerOptions.GetInstanceJsonSerializerOptions());
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async ValueTask<Artist> GetArtistAsync(string request, ClaimsPrincipal principals, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Getting info spotify artist endpoint");
        SpocifyIdentity spocify = _service.GetSpocifyIdentity(principals);
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", spocify.Token);
        var response = await _httpClient.GetAsync(SpotifyConstantsUrls.ArtistUrl(request));
        if (response.IsSuccessStatusCode is false && response.StatusCode.Equals(HttpStatusCode.Unauthorized))
        {
            var newToken = await _tokenService.GetRefreshTokenAsync(spocify, cancellationToken);
            _httpClient.DefaultRequestHeaders.Remove("Authorization");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", newToken.Token);
            response = await _httpClient.GetAsync(SpotifyConstantsUrls.ArtistUrl(request));
        }

        var contentString = await response.Content.ReadAsStringAsync();
        try
        {
            var artist = JsonSerializer.Deserialize<Artist>(contentString, GetJsonSerializerOptions.GetInstanceJsonSerializerOptions());
            return artist;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async ValueTask<AlbumResponse> GetAlbumAsync(string request, ClaimsPrincipal principals, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Getting info spotify search endpoint");
            SpocifyIdentity spocify = _service.GetSpocifyIdentity(principals);
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", spocify.Token);
            var response = await _httpClient.GetAsync(SpotifyConstantsUrls.AlbumUrl(request));
            if (response.IsSuccessStatusCode is false && response.StatusCode.Equals(HttpStatusCode.Unauthorized))
            {
                var newToken = await _tokenService.GetRefreshTokenAsync(spocify, cancellationToken);
                _httpClient.DefaultRequestHeaders.Remove("Authorization");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", newToken.Token);
                response = await _httpClient.GetAsync(SpotifyConstantsUrls.SearchUrl(request));
            }
            var contentString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<AlbumResponse>(contentString, GetJsonSerializerOptions.GetInstanceJsonSerializerOptions());
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}