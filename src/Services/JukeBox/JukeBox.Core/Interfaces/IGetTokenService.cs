namespace JukeBox.Core.Interfaces
{
    public interface IGetTokenService
    {
        ValueTask<SpocifyIdentity> GetRefreshTokenAsync(SpocifyIdentity identity, CancellationToken cancellationToken);
    }
}