using System.Text.Json;
using System.Text.Json.Serialization;

namespace YTDLP.Service;

public class Settings
{
    public string DestinationFolder { get; set; }
    public string Format { get; set; }
    public string MediaOptions { get; set; }
    public bool EmbedMetaData { get; set; } = true;
    public bool EmbedThumbnail { get; set; } = true;
    public List<string> Sources { get; set; }
    public string OutputFolder { get; set; }

    public string GetArguments(string source)
    {
        // $"-o {format} -i   --cookies youtube.com_cookies.txt {item}");
        return $"-P {DestinationFolder} -o {Format.Wrap()} {EmbedThumbnailArg()} {EmbedMetaArg()} -i --download-archive {FileHelpers.MergePath("videoarchive.txt").Wrap()} -f {MediaOptions} --cookies {FileHelpers.MergePath("cookies.txt").Wrap()} {source}";
    }
    public string EmbedMetaArg()
    {
        return EmbedMetaData ? "--embed-metadata" : "";
    }
    public string EmbedThumbnailArg()
    {
        return EmbedThumbnail ? "--embed-thumbnail" : "";
    }

public static async Task<Settings> GetSettings()
    {
        var setting = new Settings();
        var fileLocation = FileHelpers.SettingsFile;
        if (File.Exists(fileLocation))
        {
            var content = await File.ReadAllTextAsync(FileHelpers.SettingsFile);
            setting =  content.FromJSON<Settings>();
        }
        else
        {
            setting.Format = "%(channel)s/%(playlist)s/%(title)s.%(ext)s";
            setting.MediaOptions = "bestvideo[ext=mp4]+bestaudio[ext=m4a]/best[ext=mp4]/best";
            setting.Sources = new List<string>() { "https://www.youtube.com/user/PolyhydraGames/videos" };
            setting.DestinationFolder = FileHelpers.TempDirectory;
            setting.OutputFolder = Path.Combine(FileHelpers.HomeDirectory, "YTOutput");
            //Writes initial default setting to disk.
            await File.WriteAllTextAsync(fileLocation,setting.ToJSON());
        }

        return setting;
    }
}