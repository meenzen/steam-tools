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

    public ApiCredentials? Credentials { get; private set; }

    public void Configure(ApiCredentials credentials)
    {
        if (!credentials.Valid)
        {
            throw new ArgumentException("The provided credentials are not valid.", nameof(credentials));
        }

        Credentials = credentials;
    }

    public void ResetConfiguration()
    {
        Credentials = null;
    }

    public bool IsConfigured => Credentials is not null;

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
        if (Credentials is null)
        {
            ShowConfigurationSnackbar();
            return null;
        }

        SteamResponse<OwnedGamesResponse>? result = await _client.GetFromJsonAsync(
            $"IPlayerService/GetOwnedGames/v1/?key={Credentials.ApiKey}&steamid={Credentials.SteamId}&include_appinfo={includeAppInfo.ToParameter()}&include_played_free_games={includePlayedFreeGames.ToParameter()}&include_free_sub={includeFreeSub.ToParameter()}&include_extended_appinfo={includeExtendedAppInfo.ToParameter()}",
            SourceGenerationContext.Default.SteamResponseOwnedGamesResponse
        );
        return result;
    }
}
