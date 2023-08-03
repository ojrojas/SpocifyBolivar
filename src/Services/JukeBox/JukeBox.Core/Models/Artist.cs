//curl--request GET \
//  --url https://api.spotify.com/v1/artists/0TnOYISbd1XYRBk9myaseg \
//  --header 'Authorization: Bearer 1POdFZRZbvb...qqillRxMr2z'
namespace JukeBox.Core.Models;

public class Artist
{
    public ExternalUrls ExternalUrls { get; set; }
    public Followers Followers { get; set; }
    public List<string> Genres { get; set; }
    public string Href { get; set; }
    public string Id { get; set; }
    public List<Image> Images { get; set; }
    public string Name { get; set; }
    public int Popularity { get; set; }
    public string Type { get; set; }
    public string Uri { get; set; }
}

public class ExternalUrls
{
    public string Spotify { get; set; }
}

public class Followers
{
    public object Href { get; set; }
    public int Total { get; set; }
}

public class Image
{
    public string Url { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }
}



