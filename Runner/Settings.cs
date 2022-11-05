using System;

namespace YTDLP.Service;

public class Settings
{
    // Where to move the files when done
    public string DestinationFolder { get; set; }

    //output format
    public string Format { get; set; }

    // What options should the files use to dl.
    public string MediaOptions { get; set; }
    public bool EmbedMetaData { get; set; } = true;
    public bool EmbedThumbnail { get; set; } = true;

    public List<string>? Sources { get; set; }

    // Information on the channels and if to operate as if the majority have been downloaded already.
    public List<Playlist> PlayLists { get; set; } = new List<Playlist>();

    /// Where to save temporarily
    public string OutputFolder { get; set; }

    ///If last download of whole list was successful, only poll this many videos next time. Should be enough to check the latest additions to the list/
    public int VideosToDownload { get; set; } = 5;

    public string GetArguments(string source)
    {
        // $"-o {format} -i   --cookies youtube.com_cookies.txt {item}");
        return
            $"-P {DestinationFolder} -o {Format.Wrap()} {EmbedThumbnailArg()} {EmbedMetaArg()} -i --download-archive {FileHelpers.MergePath("videoarchive.txt").Wrap()} -f {MediaOptions} --cookies {FileHelpers.MergePath("cookies.txt").Wrap()} {source}";
    }

    public string GetArguments(Playlist source)
    {
        // $"-o {format} -i   --cookies youtube.com_cookies.txt {item}");
        return
            $"-P {DestinationFolder} -o {Format.Wrap()} {EmbedThumbnailArg()} {EmbedMetaArg()} {Completed(source.Completed)} -i --download-archive {FileHelpers.MergePath("videoarchive.txt").Wrap()} -f {MediaOptions} --cookies {FileHelpers.MergePath("cookies.txt").Wrap()} {source.Url}";
    }

    public string EmbedMetaArg()
    {
        return EmbedMetaData ? "--embed-metadata" : "";
    }

    public string EmbedThumbnailArg()
    {
        return EmbedThumbnail ? "--embed-thumbnail" : "";
    }

    public string Completed(bool complete)
    {
        return complete ? $"--playlist-end {VideosToDownload}" : "";
    }

    private static async Task UpgradeVideoList(Settings settings)
    {
        if (!(settings.Sources?.Any() ?? false)) return;
        foreach (var item in settings.Sources)
            settings.PlayLists.Add(new Playlist
            {
                Url = item
            });

        settings.Sources = null;
        await WriteSettings(settings);
    }

    public static async Task<Settings> GetSettings()
    {
        var setting = new Settings();
        var fileLocation = FileHelpers.SettingsFile;
        if (File.Exists(fileLocation))
        {
            var content = await File.ReadAllTextAsync(FileHelpers.SettingsFile);
            setting = content.FromJSON<Settings>();
            await UpgradeVideoList(setting);
        }
        else
        {
            setting.Format = "%(channel)s/%(playlist)s/%(title)s.%(ext)s";
            setting.MediaOptions = "bestvideo[ext=mp4]+bestaudio[ext=m4a]/best[ext=mp4]/best";
            setting.DestinationFolder = FileHelpers.TempDirectory;
            setting.OutputFolder = Path.Combine(FileHelpers.HomeDirectory, "YTOutput");
            setting.VideosToDownload = 5;
            setting.Sources = new List<string>();
            setting.PlayLists = new List<Playlist>
            {
                new()
                {
                    Name = "Polyhydra Games",
                    Url = "https://www.youtube.com/user/PolyhydraGames/videos"
                }
            };

            //Writes initial default setting to disk.
            await WriteSettings(setting);
        }

        return setting;
    }

    public static async Task WriteSettings(Settings settings)
    {
        await File.WriteAllTextAsync(FileHelpers.SettingsFile, settings.ToJSON());
    }
}