namespace BuildingBlock.Commons.Services;

public class LoggingApplication<T> : ILoggingApplication<T>
{
    private readonly ILogger<T> _logger;
    public LoggingApplication(ILogger<T> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public void LogInformation(BaseResponse response, string message) => _logger.LogInformation(SettingMessage(response, message));
    public void LogInformation(Guid correlationId, string message) => _logger.LogInformation(SettingMessage(correlationId, message));
    public void LogInformation(string message) => _logger.LogInformation(message);

    public void LogWarning(BaseResponse response, string message) => _logger.LogInformation(SettingMessage(response, message));
    public void LogWarning(Guid correlationId, string message) => _logger.LogInformation(SettingMessage(correlationId, message));
    public void LogWarning(string message) => _logger.LogInformation(message);

    public void LogError(BaseResponse response, string message) => _logger.LogInformation(SettingMessage(response, message));
    public void LogError(Guid correlationId, string message) => _logger.LogInformation(SettingMessage(correlationId, message));
    public void LogError(string message) => _logger.LogInformation(message);

    private string SettingMessage(BaseResponse response, string message) => $"[{response.CorrelationId()}] - {message}";
    private string SettingMessage(Guid correlationId, string message) => $"[{correlationId}] - {message}";
}