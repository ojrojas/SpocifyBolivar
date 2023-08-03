namespace JukeBox.Core.Services;

public class SpotifyTokenService: ISpotifyTokenService
{
    private readonly ILoggingApplication<JukeBoxService> _logger;
    private readonly ICacheApplicationService _cache;

    public SpotifyTokenService(ILoggingApplication<JukeBoxService> logger, ICacheApplicationService cache)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    }

    public async ValueTask<SpocifyIdentity> GetTokenAsync(string userid, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Getting token from cache");
        return  await _cache.GetValue<SpocifyIdentity>(userid, cancellationToken);
    }
}

