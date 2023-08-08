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
        try
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
            return JsonSerializer.Deserialize<Artist>(contentString, GetJsonSerializerOptions.GetInstanceJsonSerializerOptions());
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
            _logger.LogInformation("Getting info spotify album endpoint");
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

    public async ValueTask<PlayerStateResponse> GetPlayerAsync(ClaimsPrincipal principals, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Getting info spotify device state endpoint");
            SpocifyIdentity spocify = _service.GetSpocifyIdentity(principals);
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", spocify.Token);
            var response = await _httpClient.GetAsync(SpotifyConstantsUrls.GetPlayerState());
            if (response.IsSuccessStatusCode is false && response.StatusCode.Equals(HttpStatusCode.Unauthorized))
            {
                var newToken = await _tokenService.GetRefreshTokenAsync(spocify, cancellationToken);
                _httpClient.DefaultRequestHeaders.Remove("Authorization");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", newToken.Token);
                response = await _httpClient.GetAsync(SpotifyConstantsUrls.GetPlayerState());
            }
            var contentString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<PlayerStateResponse>(contentString, GetJsonSerializerOptions.GetInstanceJsonSerializerOptions());
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async ValueTask<object> GetStartResumePlayerAsync(PlayerPlayResumeRequest request, ClaimsPrincipal principals, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Getting info spotify start or resume player state endpoint");
            SpocifyIdentity spocify = _service.GetSpocifyIdentity(principals);
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", spocify.Token);
            StringContent content = new StringContent(JsonSerializer.Serialize(request, GetJsonSerializerOptions.GetInstanceJsonSerializerOptions()));
            var response = await _httpClient.PutAsync(SpotifyConstantsUrls.GetPlayerState(), content);
            if (response.IsSuccessStatusCode is false && response.StatusCode.Equals(HttpStatusCode.Unauthorized))
            {
                var newToken = await _tokenService.GetRefreshTokenAsync(spocify, cancellationToken);
                _httpClient.DefaultRequestHeaders.Remove("Authorization");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", newToken.Token);
                response = await _httpClient.PutAsync(SpotifyConstantsUrls.GetPlayerState(), content);
            }
            var contentString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<object>(contentString, GetJsonSerializerOptions.GetInstanceJsonSerializerOptions());
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async ValueTask<object> GetPlayBackVolumeAsync(int request, ClaimsPrincipal principals, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Getting info spotify set volume player state endpoint");
            SpocifyIdentity spocify = _service.GetSpocifyIdentity(principals);
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", spocify.Token);
            StringContent content = new StringContent(string.Empty);
            var response = await _httpClient.PutAsync(SpotifyConstantsUrls.SetPlayBackVolume(request), content);
            if (response.IsSuccessStatusCode is false && response.StatusCode.Equals(HttpStatusCode.Unauthorized))
            {
                var newToken = await _tokenService.GetRefreshTokenAsync(spocify, cancellationToken);
                _httpClient.DefaultRequestHeaders.Remove("Authorization");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", newToken.Token);
                response = await _httpClient.PutAsync(SpotifyConstantsUrls.GetPlayerState(), content);
            }
            var contentString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<object>(contentString, GetJsonSerializerOptions.GetInstanceJsonSerializerOptions());
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async ValueTask<object> GetPausePlayerAsync(ClaimsPrincipal principals, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Getting info spotify set volume player state endpoint");
            SpocifyIdentity spocify = _service.GetSpocifyIdentity(principals);
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", spocify.Token);
            StringContent content = new StringContent(string.Empty);
            var response = await _httpClient.PutAsync(SpotifyConstantsUrls.SetPausePlayer(), content);
            if (response.IsSuccessStatusCode is false && response.StatusCode.Equals(HttpStatusCode.Unauthorized))
            {
                var newToken = await _tokenService.GetRefreshTokenAsync(spocify, cancellationToken);
                _httpClient.DefaultRequestHeaders.Remove("Authorization");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", newToken.Token);
                response = await _httpClient.PutAsync(SpotifyConstantsUrls.GetPlayerState(), content);
            }
            var contentString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<object>(contentString, GetJsonSerializerOptions.GetInstanceJsonSerializerOptions());
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async ValueTask<object> GetPlayerNextAsync(ClaimsPrincipal principals, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Getting info spotify set volume player state endpoint");
            SpocifyIdentity spocify = _service.GetSpocifyIdentity(principals);
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", spocify.Token);
            StringContent content = new StringContent(string.Empty);
            var response = await _httpClient.PostAsync(SpotifyConstantsUrls.SetPausePlayer(), content);
            if (response.IsSuccessStatusCode is false && response.StatusCode.Equals(HttpStatusCode.Unauthorized))
            {
                var newToken = await _tokenService.GetRefreshTokenAsync(spocify, cancellationToken);
                _httpClient.DefaultRequestHeaders.Remove("Authorization");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", newToken.Token);
                response = await _httpClient.PostAsync(SpotifyConstantsUrls.GetPlayerState(), content);
            }
            var contentString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<object>(contentString, GetJsonSerializerOptions.GetInstanceJsonSerializerOptions());
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async ValueTask<object> GetPlayerPreviousAsync(ClaimsPrincipal principals, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Getting info spotify set volume player state endpoint");
            SpocifyIdentity spocify = _service.GetSpocifyIdentity(principals);
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", spocify.Token);
            StringContent content = new StringContent(string.Empty);
            var response = await _httpClient.PostAsync(SpotifyConstantsUrls.SetPausePlayer(), content);
            if (response.IsSuccessStatusCode is false && response.StatusCode.Equals(HttpStatusCode.Unauthorized))
            {
                var newToken = await _tokenService.GetRefreshTokenAsync(spocify, cancellationToken);
                _httpClient.DefaultRequestHeaders.Remove("Authorization");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", newToken.Token);
                response = await _httpClient.PostAsync(SpotifyConstantsUrls.GetPlayerState(), content);
            }
            var contentString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<object>(contentString, GetJsonSerializerOptions.GetInstanceJsonSerializerOptions());
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}