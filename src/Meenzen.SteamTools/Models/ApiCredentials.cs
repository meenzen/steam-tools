using System.Text.Json.Serialization;

namespace Meenzen.SteamTools.Models;

public record ApiCredentials(ulong SteamId, string ApiKey)
{
    public const string LocalStorageKey = "ApiCredentials";

    [JsonIgnore]
    public bool Valid => SteamId != 0 && !string.IsNullOrWhiteSpace(ApiKey);
}
