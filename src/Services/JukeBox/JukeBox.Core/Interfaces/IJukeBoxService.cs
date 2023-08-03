namespace JukeBox.Core.Interfaces;

public interface IJukeBoxService
{
    ValueTask<string> GetSearchAsync(SearchRequest request, string userid, CancellationToken cancellationToken);
    ValueTask<string> GetArtistAsync(string request, string userid, CancellationToken cancellationToken);
    ValueTask<string> GetSeveralBrowseAsync(SeveralBrowseRequest request, string userid, CancellationToken cancellationToken);
}