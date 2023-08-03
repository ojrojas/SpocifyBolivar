namespace BuildingBlock.Commons.Services;

public interface ILoggingApplication<T>
{
    void LogError(BaseResponse response, string message);
    void LogError(Guid correlationId, string message);
    void LogError(string message);
    void LogInformation(BaseResponse response, string message);
    void LogInformation(Guid correlationId, string message);
    void LogInformation(string message);
    void LogWarning(BaseResponse response, string message);
    void LogWarning(Guid correlationId, string message);
    void LogWarning(string message);
}