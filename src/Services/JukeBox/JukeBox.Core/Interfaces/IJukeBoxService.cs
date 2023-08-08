namespace JukeBox.Core.Services
{
    public interface IJukeBoxService
    {
        ValueTask<AlbumResponse> GetAlbumAsync(string request, ClaimsPrincipal principals, CancellationToken cancellationToken);
        ValueTask<Artist> GetArtistAsync(string request, ClaimsPrincipal principals, CancellationToken cancellationToken);
        ValueTask<object> GetPausePlayerAsync(ClaimsPrincipal principals, CancellationToken cancellationToken);
        ValueTask<object> GetPlayBackVolumeAsync(int request, ClaimsPrincipal principals, CancellationToken cancellationToken);
        ValueTask<PlayerStateResponse> GetPlayerAsync(ClaimsPrincipal principals, CancellationToken cancellationToken);
        ValueTask<object> GetPlayerNextAsync(ClaimsPrincipal principals, CancellationToken cancellationToken);
        ValueTask<object> GetPlayerPreviousAsync(ClaimsPrincipal principals, CancellationToken cancellationToken);
        ValueTask<SearchResponse> GetSearchAsync(string request, ClaimsPrincipal principals, CancellationToken cancellationToken);
        ValueTask<object> GetStartResumePlayerAsync(PlayerPlayResumeRequest request, ClaimsPrincipal principals, CancellationToken cancellationToken);
    }
}