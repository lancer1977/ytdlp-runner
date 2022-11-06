using System.Text.Json;

namespace YTDLP.Service;

public static class JSONHelpers
{
    public static T FromJSON<T>(this string value)
    {
        var personObject = JsonSerializer.Deserialize<T>(value);
        return personObject;
    }

    public static string ToJSON<T>(this T obj)
    {
        var result = JsonSerializer.Serialize(obj, new JsonSerializerOptions { WriteIndented = true });
        return result;
    }
}