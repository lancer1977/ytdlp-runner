//Create config file in .ytdlrunner directory,
//explore parsing arguments to update the initial config? maybe not nessasary.
 
using YTDLP.Service;

var destinationDirectory = FileHelpers.TempDirectory; 

Console.WriteLine($"Running version {Constants.AppVersion}");
var settings = await Settings.GetSettings();

var channels = settings.Sources;
foreach (var item in channels)
{
    var arguments = settings.GetArguments(item);
    Console.WriteLine(arguments);
    var result = await FileHelpers.ExecuteProcess("yt-dlp",arguments ); 
    FileHelpers.MoveInner(destinationDirectory, settings.OutputFolder,true);
}

foreach (var item in settings.PlayLists)
{
    var arguments = settings.GetArguments(item);
    Console.WriteLine(arguments);
    item.Completed = await FileHelpers.ExecuteProcess("yt-dlp", arguments);
    Console.WriteLine(item.Completed);
    await Settings.WriteSettings(settings);
    FileHelpers.MoveInner(destinationDirectory, settings.OutputFolder, true);
}