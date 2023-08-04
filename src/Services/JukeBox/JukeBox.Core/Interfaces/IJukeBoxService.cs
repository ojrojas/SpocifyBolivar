namespace JukeBox.Core.Interfaces;

public interface IJukeBoxService
{
    ValueTask<Search> GetSearchAsync(string request, string userid, CancellationToken cancellationToken);
    ValueTask<Artist> GetArtistAsync(string request, string userid, CancellationToken cancellationToken);
    ValueTask<SeveralBrowse> GetSeveralBrowseAsync(string request, string userid, CancellationToken cancellationToken);
}