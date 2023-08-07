namespace JukeBox.Core.Interfaces;

public interface IJukeBoxService
{
    ValueTask<SearchResponse> GetSearchAsync(string request, ClaimsPrincipal principal, CancellationToken cancellationToken);
    ValueTask<Artist> GetArtistAsync(string request, ClaimsPrincipal principal, CancellationToken cancellationToken);
    ValueTask<AlbumResponse> GetAlbumAsync(string request, ClaimsPrincipal principals, CancellationToken cancellationToken);
}