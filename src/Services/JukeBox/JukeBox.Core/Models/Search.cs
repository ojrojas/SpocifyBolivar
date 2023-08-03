// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
//curl--request GET \
//  --url 'https://api.spotify.com/v1/search?q=remaster%2520track%3ADoxy%2520artist%3AMiles%2520Davis&type=album' \
//  --header 'Authorization: Bearer 1POdFZRZbvb...qqillRxMr2z'

namespace JukeBox.Core.Models;

public class Search
{
    public Albums Albums { get; set; }
}

public class Albums
{
    public string Href { get; set; }
    public int Limit { get; set; }
    public string Next { get; set; }
    public int Offset { get; set; }
    public object Previous { get; set; }
    public int Total { get; set; }
    public List<Item> Items { get; set; }
}

public class Item
{
    public string AlbumType { get; set; }
    public int TotalTracks { get; set; }
    public List<string> AvailableMarkets { get; set; }
    public ExternalUrls ExternalUrls { get; set; }
    public string Href { get; set; }
    public string Id { get; set; }
    public List<Image> Images { get; set; }
    public string Name { get; set; }
    public string ReleaseDate { get; set; }
    public string ReleaseDatePrecision { get; set; }
    public string Type { get; set; }
    public string Uri { get; set; }
    public List<Artist> Artists { get; set; }
}

public class SearchRequest
{
    public string Query { get; set; }
    public string Type { get; set; }
    public int Limit { get; set; }
}