﻿namespace JukeBox.Core.Models;

public class LinkedFrom
{
    public ExternalUrls external_urls { get; set; }
    public string href { get; set; }
    public string id { get; set; }
    public string type { get; set; }
    public string uri { get; set; }
}

public class AlbumResponse
{
    public string album_type { get; set; }
    public int total_tracks { get; set; }
    public List<string> available_markets { get; set; }
    public ExternalUrls external_urls { get; set; }
    public string href { get; set; }
    public string id { get; set; }
    public List<Image> images { get; set; }
    public string name { get; set; }
    public string release_date { get; set; }
    public string release_date_precision { get; set; }
    public Restrictions restrictions { get; set; }
    public string type { get; set; }
    public string uri { get; set; }
    public List<Copyright> copyrights { get; set; }
    public ExternalIds external_ids { get; set; }
    public List<string> genres { get; set; }
    public string label { get; set; }
    public int popularity { get; set; }
    public List<Artist> artists { get; set; }
    public Tracks tracks { get; set; }
}
