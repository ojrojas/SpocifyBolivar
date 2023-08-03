using System;
namespace JukeBox.Core.Models;
//curl --request GET \
//  --url 'https://api.spotify.com/v1/browse/categories?country=CO&locale=ES_CO&limit=50' \
//  --header 'Authorization: Bearer 1POdFZRZbvb...qqillRxMr2z'
// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class Categories
{
    public string Href { get; set; }
    public int Limit { get; set; }
    public string Next { get; set; }
    public int Offset { get; set; }
    public object Previous { get; set; }
    public int Total { get; set; }
    public List<Item2> Items { get; set; }
}

public class Icon
{
    public int? Height { get; set; }
    public string Url { get; set; }
    public int? Width { get; set; }
}

public class Item2
{
    public string Href { get; set; }
    public List<Icon> Icons { get; set; }
    public string Id { get; set; }
    public string Name { get; set; }
}

public class SeveralBrowse
{
    public Categories Categories { get; set; }
}

public class SeveralBrowseRequest
{
    public string Country { get; set; }
    public string Locale { get; set; }
    public int Limit { get; set; }
}

