namespace Meenzen.SteamTools;

public class SteamToolsOptions
{
    public required Uri BaseAddress { get; set; }
    public required Uri ProxyUri { get; set; }

    public bool IsOfficialDeployment => BaseAddress.Host.EndsWith("mnzn.dev");
    public bool IsPreviewDeployment => BaseAddress.Host.EndsWith("steam-tools-8yd.pages.dev");
}
