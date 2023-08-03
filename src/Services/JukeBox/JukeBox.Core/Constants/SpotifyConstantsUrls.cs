namespace JukeBox.Core.Constants
{
	public static class SpotifyConstantsUrls
	{
		public static string SeveralBrowseUrl(SeveralBrowseRequest request)
		{
			if(request.Country is not null && request.Locale is not null && request.Limit is not default(int))
			return $"https://api.spotify.com/v1/browse/categories?country={request.Country}&locale={request.Locale}&limit={request.Limit}";
			return $"https://api.spotify.com/v1/browse/categories?country=CO&locale=ES_CO&limit=50";
        }

		public static string SearchUrl(SearchRequest request)
		{
			return $"https://api.spotify.com/v1/search?q={request.Query}&type={request.Type}&limit={request.Limit}";
        }

		public static string ArtistUrl(string id)
		{
			return $"https://api.spotify.com/v1/artists/{id}";
		}
	}
}

