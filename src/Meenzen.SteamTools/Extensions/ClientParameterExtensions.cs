namespace Meenzen.SteamTools.Extensions;

public static class ClientParameterExtensions
{
    public static string ToParameter(this bool value)
    {
        return value ? "true" : "false";
    }
}
