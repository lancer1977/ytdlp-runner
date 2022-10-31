namespace YTDLP.Service;

public static class StringHelpers
{
    public static string Wrap(this string value)
    {
        return $"\'{value}\'";
    }

}