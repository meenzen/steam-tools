using System.Text.Json.Serialization;

namespace Meenzen.SteamTools.Models;

public class OwnedGamesResponse
{
    [JsonPropertyName("game_count")]
    public long GameCount { get; set; }

    [JsonPropertyName("games")]
    public required List<OwnedGame> Games { get; set; }
}

public class OwnedGame
{
    [JsonPropertyName("appid")]
    public long Appid { get; set; }

    [JsonPropertyName("playtime_forever")]
    public long PlaytimeForever { get; set; }

    [JsonPropertyName("playtime_windows_forever")]
    public long PlaytimeWindowsForever { get; set; }

    [JsonPropertyName("playtime_mac_forever")]
    public long PlaytimeMacForever { get; set; }

    [JsonPropertyName("playtime_linux_forever")]
    public long PlaytimeLinuxForever { get; set; }

    [JsonPropertyName("rtime_last_played")]
    public long RtimeLastPlayed { get; set; }

    [JsonPropertyName("playtime_disconnected")]
    public long PlaytimeDisconnected { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("playtime_2weeks")]
    public long? Playtime2Weeks { get; set; }
}
