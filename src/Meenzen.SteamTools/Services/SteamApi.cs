using Microsoft.JSInterop;
using MudBlazor;

namespace Meenzen.SteamTools.Services;

public class SteamApi
{
    private readonly IJSRuntime _jsRuntime;
    private readonly ISnackbar _snackbar;

    public SteamApi(IJSRuntime jsRuntime, ISnackbar snackbar)
    {
        _jsRuntime = jsRuntime;
        _snackbar = snackbar;
    }

    public string ApiKey { get; set; } = string.Empty;
    public ulong SteamId { get; set; } = 0;
    public bool IsConfigured => !string.IsNullOrWhiteSpace(ApiKey) && SteamId != 0;

    private async Task OpenTabAsync(string url)
    {
        await _jsRuntime.InvokeVoidAsync("open", url, "_blank");
    }

    private void ShowConfigurationSnackbar()
    {
        _snackbar.Add("Please configure the Steam API key and Steam ID first.", Severity.Warning);
    }

    public Task GetOwnedGamesAsync()
    {
        if (!IsConfigured)
        {
            ShowConfigurationSnackbar();
            return Task.CompletedTask;
        }

        return OpenTabAsync(
            $"https://api.steampowered.com/IPlayerService/GetOwnedGames/v1/?key={ApiKey}&steamid={SteamId}"
        );
    }
}
