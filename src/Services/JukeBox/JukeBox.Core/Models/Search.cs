namespace JukeBox.Core.Models;

public class Albums
{
    public string href { get; set; }
    public int limit { get; set; }
    public string next { get; set; }
    public int offset { get; set; }
    public string previous { get; set; }
    public int total { get; set; }
    public List<Item> items { get; set; }
}

public class ExternalUrls
{
    public string spotify { get; set; }
}

public class Image
{
    public string url { get; set; }
    public int height { get; set; }
    public int width { get; set; }
}

public class Item
{
    public string album_type { get; set; }
    public int total_tracks { get; set; }
    public ExternalUrls external_urls { get; set; }
    public string href { get; set; }
    public string id { get; set; }
    public List<Image> images { get; set; }
    public string name { get; set; }
    public string release_date { get; set; }
    public string release_date_precision { get; set; }
    public string type { get; set; }
    public string uri { get; set; }
    public List<Artist> artists { get; set; }
    public bool is_playable { get; set; }
}

public class Search
{
    public Albums albums { get; set; }
}

public class SearchRequest
{
    public string Query { get; set; }
    public IEnumerable<string> Type { get; set; } = new List<string> { "album" };
    public string Market { get; set; } = "CO";
    public int Limit { get; set; } = 10;
    public int OffSet { get; set; } = 5;
}