namespace JukeBox.Core.Constants;

public static class SpotifyConstantsUrls
{
	public static string SeveralBrowseUrl(string request)
	{
	
		return $"https://api.spotify.com/v1/browse/categories?{request}";
        }

	public static string SearchUrl(string request)
	{
		return $"https://api.spotify.com/v1/search?{request}";
        }

	public static string ArtistUrl(string id)
	{
		return $"https://api.spotify.com/v1/artists/{id}";
	}

	public static string AlbumUrl(string id)
	{
		return $"https://api.spotify.com/v1/albums/{id}";
    }

	public static string GetPlayerState()
	{
		return "https://api.spotify.com/v1/me/player";

    }

	public static string PlayStartResume()
	{
		return "https://api.spotify.com/v1/me/player";
    }

	public static string SetPlayBackVolume(int request)
	{
		return $"https://api.spotify.com/v1/me/player/volume?volume_percent={request}";
    }

    public static string SetPausePlayer()
    {
        return "https://api.spotify.com/v1/me/player/pause";
    }

    public static string SetPlayerNext()
    {
        return "https://api.spotify.com/v1/me/player/next";
    }

    public static string SetPlayerPrevious()
    {
        return "https://api.spotify.com/v1/me/player/previous";
    }
}

