namespace BuildingBlock.Commons.Services;

public class CacheApplicationService : ICacheApplicationService
{
    private readonly IDistributedCache _distributeCache;
    private readonly ILoggingApplication<CacheApplicationService> _logger;

    public CacheApplicationService(IDistributedCache distributeCache, ILoggingApplication<CacheApplicationService> logger)
    {
        _distributeCache = distributeCache ?? throw new ArgumentNullException(nameof(distributeCache));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task SetAsync<T>(T entity)
    {
        var encodeType = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(entity));
        await _distributeCache.SetAsync(entity.GetType().FullName, encodeType);
    }

    public async Task SetAsync<T>(string keyName, T entity)
    {
        _logger.LogInformation($"[>>>] set redis cache object key: {keyName}");
        var encodeType = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(entity, new JsonSerializerOptions
        {
            ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles
        }));

        await _distributeCache.SetAsync(keyName, encodeType);
    }

    public async ValueTask<T> GetValue<T>(string keyName, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"[<<<] get redis cache object key: {keyName}");
        var encodeType = await _distributeCache.GetAsync(keyName, cancellationToken);
        var decodeType = Encoding.UTF8.GetString(encodeType);
        return JsonSerializer.Deserialize<T>(decodeType, new JsonSerializerOptions
        {
            ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles
        });
    }
}

