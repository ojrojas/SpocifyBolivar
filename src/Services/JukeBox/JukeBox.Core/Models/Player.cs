namespace JukeBox.Core.Models;

public class PlayerPlayResumeRequest
{
    public string context_uri { get; set; }
    public int position_ms { get; set; }
    public OffSet offset { get; set; }
}

public class OffSet
{
    public int position { get; set; }
}

public class Actions
{
    public bool interrupting_playback { get; set; }
    public bool pausing { get; set; }
    public bool resuming { get; set; }
    public bool seeking { get; set; }
    public bool skipping_next { get; set; }
    public bool skipping_prev { get; set; }
    public bool toggling_repeat_context { get; set; }
    public bool toggling_shuffle { get; set; }
    public bool toggling_repeat_track { get; set; }
    public bool transferring_playback { get; set; }
}

public class Context
{
    public string type { get; set; }
    public string href { get; set; }
    public ExternalUrls external_urls { get; set; }
    public string uri { get; set; }
}

public class Device
{
    public string id { get; set; }
    public bool is_active { get; set; }
    public bool is_private_session { get; set; }
    public bool is_restricted { get; set; }
    public string name { get; set; }
    public string type { get; set; }
    public int volume_percent { get; set; }
}

public class PlayerStateResponse
{
    public Device device { get; set; }
    public string repeat_state { get; set; }
    public bool shuffle_state { get; set; }
    public Context context { get; set; }
    public int timestamp { get; set; }
    public int progress_ms { get; set; }
    public bool is_playing { get; set; }
    public Item item { get; set; }
    public string currently_playing_type { get; set; }
    public Actions actions { get; set; }
}

