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
}

