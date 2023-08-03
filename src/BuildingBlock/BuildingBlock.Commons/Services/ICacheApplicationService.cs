namespace BuildingBlock.Commons.Services
{
    public interface ICacheApplicationService
    {
        ValueTask<T> GetValue<T>(string keyName, CancellationToken cancellationToken);
        Task SetAsync<T>(T entity);
        Task SetAsync<T>(string keyName, T entity);
    }
}