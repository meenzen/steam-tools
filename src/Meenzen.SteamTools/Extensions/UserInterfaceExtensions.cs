namespace Meenzen.SteamTools.Extensions;

public static class UserInterfaceExtensions
{
    public static string ToUiString(this DateTimeOffset dateTimeOffset)
    {
        if (dateTimeOffset <= DateTimeOffset.UnixEpoch)
        {
            return "Never";
        }

        return dateTimeOffset.ToString("yyyy-MM-dd HH:mm:ss");
    }

    public static string ToUiString(this bool value)
    {
        return value ? "Yes" : "No";
    }

    public static string ToUiString(this long value)
    {
        if (value == 0)
        {
            return "Never";
        }

        return TimeSpan.FromMinutes(value).TotalHours.ToReadable();
    }
}
