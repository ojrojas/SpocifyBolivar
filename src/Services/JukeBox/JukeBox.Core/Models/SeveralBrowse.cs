namespace JukeBox.Core.Models;

public class Categories
{
    public string href { get; set; }
    public List<Item2> items { get; set; }
    public int limit { get; set; }
    public string next { get; set; }
    public int offset { get; set; }
    public object previous { get; set; }
    public int total { get; set; }
}

public class Icon
{
    public int? height { get; set; }
    public string url { get; set; }
    public int? width { get; set; }
}

public class Item2
{
    public string href { get; set; }
    public List<Icon> icons { get; set; }
    public string id { get; set; }
    public string name { get; set; }
}

public class SeveralBrowse
{
    public Categories categories { get; set; }
}