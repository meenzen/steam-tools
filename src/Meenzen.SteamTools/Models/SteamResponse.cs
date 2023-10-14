using System.Text.Json.Serialization;

namespace Meenzen.SteamTools.Models;

public class SteamResponse<T>
{
    [JsonPropertyName("response")]
    public required T Response { get; set; }
}
