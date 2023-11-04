using System.Text.Json.Serialization;
using Meenzen.SteamTools.Converters;

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

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("playtime_forever")]
    public long PlaytimeForever { get; set; }

    [JsonPropertyName("img_icon_url")]
    public string? ImgIconUrl { get; set; }

    [JsonPropertyName("playtime_windows_forever")]
    public long PlaytimeWindowsForever { get; set; }

    [JsonPropertyName("playtime_mac_forever")]
    public long PlaytimeMacForever { get; set; }

    [JsonPropertyName("playtime_linux_forever")]
    public long PlaytimeLinuxForever { get; set; }

    [JsonPropertyName("rtime_last_played")]
    [JsonConverter(typeof(UnixTimestampConverter))]
    public DateTimeOffset LastPlayed { get; init; }

    [JsonPropertyName("has_workshop")]
    public bool HasWorkshop { get; set; }

    [JsonPropertyName("has_market")]
    public bool HasMarket { get; set; }

    [JsonPropertyName("has_dlc")]
    public bool HasDlc { get; set; }

    [JsonPropertyName("playtime_disconnected")]
    public long PlaytimeDisconnected { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("capsule_filename")]
    public string? CapsuleFilename { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("has_community_visible_stats")]
    public bool? HasCommunityVisibleStats { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("sort_as")]
    public string? SortAs { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("has_leaderboards")]
    public bool? HasLeaderboards { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("content_descriptorids")]
    public List<long> ContentDescriptorids { get; set; } = new();

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("playtime_2weeks")]
    public long? Playtime2Weeks { get; set; }
}
