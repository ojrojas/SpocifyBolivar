namespace JukeBox.Core.Interfaces;

public interface ISpotifyTokenService
{
    ValueTask<SpocifyIdentity> GetTokenAsync(string userid, CancellationToken cancellationToken);
    ValueTask<SpocifyIdentity> GetRefreshTokenAsync(string userid, CancellationToken cancellationToken);
}

