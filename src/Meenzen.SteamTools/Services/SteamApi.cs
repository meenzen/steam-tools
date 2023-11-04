using System.Net.Http.Json;
using Meenzen.SteamTools.Extensions;
using Meenzen.SteamTools.Generated;
using Meenzen.SteamTools.Models;
using MudBlazor;

namespace Meenzen.SteamTools.Services;

public class SteamApi
{
    private readonly ISnackbar _snackbar;
    private readonly HttpClient _client;

    public SteamApi(ISnackbar snackbar, HttpClient client)
    {
        _snackbar = snackbar;
        _client = client;
    }

    public string ApiKey { get; set; } = string.Empty;
    public ulong SteamId { get; set; } = 0;
    public bool IsConfigured => !string.IsNullOrWhiteSpace(ApiKey) && SteamId != 0;

    private void ShowConfigurationSnackbar()
    {
        _snackbar.Add("Please configure the Steam API key and Steam ID first.", Severity.Warning);
    }

    public async Task<SteamResponse<OwnedGamesResponse>?> GetOwnedGamesAsync(
        bool includeAppInfo = true,
        bool includePlayedFreeGames = true,
        bool includeFreeSub = true,
        bool includeExtendedAppInfo = true
    )
    {
        if (!IsConfigured)
        {
            ShowConfigurationSnackbar();
            return null;
        }

        SteamResponse<OwnedGamesResponse>? result = await _client.GetFromJsonAsync(
            $"IPlayerService/GetOwnedGames/v1/?key={ApiKey}&steamid={SteamId}&include_appinfo={includeAppInfo.ToParameter()}&include_played_free_games={includePlayedFreeGames.ToParameter()}&include_free_sub={includeFreeSub.ToParameter()}&include_extended_appinfo={includeExtendedAppInfo.ToParameter()}",
            SourceGenerationContext.Default.SteamResponseOwnedGamesResponse
        );
        return result;
    }
}
