//Create config file in .ytdlrunner directory,
//explore parsing arguments to update the initial config? maybe not nessasary.
 
using YTDLP.Service;

var destinationDirectory = FileHelpers.TempDirectory; 

Console.WriteLine($"Edit config at {FileHelpers.AppDirectory}");
var settings = await Settings.GetSettings();

var channels = settings.Sources;
foreach (var item in channels)
{
    var arguments = settings.GetArguments(item);
    Console.WriteLine(arguments);
    var result = await FileHelpers.ExecuteProcess("yt-dlp",arguments );
    FileHelpers.MoveInner(destinationDirectory, settings.OutputFolder,true);
}
