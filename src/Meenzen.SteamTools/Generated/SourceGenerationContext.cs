using System.Text.Json.Serialization;
using Meenzen.SteamTools.Models;

namespace Meenzen.SteamTools.Generated;

[JsonSourceGenerationOptions(WriteIndented = true)]
[JsonSerializable(typeof(SteamResponse<OwnedGamesResponse>))]
internal partial class SourceGenerationContext : JsonSerializerContext { }
