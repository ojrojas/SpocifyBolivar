namespace JukeBox.Core.Interfaces;

public interface ISpotifyTokenService
{
    ValueTask<SpocifyIdentity> GetTokenAsync(string userid, CancellationToken cancellationToken);
}

