namespace JukeBox.Core.Services;

public class JukeBoxService : IJukeBoxService
{
    private readonly ILoggingApplication<JukeBoxService> _logger;
    private readonly ICacheApplicationService _cache;
    private readonly ISpotifyTokenService _tokenSpotify;
    private HttpClient _httpClient;

    public JukeBoxService(ILoggingApplication<JukeBoxService> logger, ICacheApplicationService cache, ISpotifyTokenService tokenSpotify)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _cache = cache ?? throw new ArgumentNullException(nameof(cache));
        _tokenSpotify = tokenSpotify ?? throw new ArgumentNullException(nameof(tokenSpotify));
    }

    public async ValueTask<string> GetSeveralBrowseAsync(SeveralBrowseRequest request, string userid, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Getting info spotify several browser endpoint");
        var spocify = await _cache.GetValue<SpocifyIdentity>(userid, cancellationToken);
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", spocify.Token);
        var response = await _httpClient.GetAsync(SpotifyConstantsUrls.SeveralBrowseUrl(request));
        return  await response.Content.ReadAsStringAsync();
    }

    public async ValueTask<string> GetSearchAsync(SearchRequest request, string userid, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Getting info spotify search endpoint");
        var spocify = await _cache.GetValue<SpocifyIdentity>(userid, cancellationToken);
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", spocify.Token);
        var response = await _httpClient.GetAsync(SpotifyConstantsUrls.SearchUrl(request));
        return await response.Content.ReadAsStringAsync();
    }

    public async ValueTask<string> GetArtistAsync(string request, string userid, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Getting info spotify artist endpoint");
        var spocify = await _cache.GetValue<SpocifyIdentity>(userid, cancellationToken);
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", spocify.Token);
        var response = await _httpClient.GetAsync(SpotifyConstantsUrls.ArtistUrl(request));
        return  await response.Content.ReadAsStringAsync();
    }
}

