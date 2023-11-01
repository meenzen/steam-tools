namespace Meenzen.SteamTools.Components.Extensions;

public static class DoubleExtensions
{
    public static string ToReadable(this double value) => value.ToString("N2");
}
