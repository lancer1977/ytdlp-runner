using System;
using System.Diagnostics;

namespace YTDLP.Service;

public static class Constants{
    public static int AppVersion => 11;
}
public static class FileHelpers
{
    public static string GetDirectorySafe(string path)
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        return path;
    }
    public static string TempDirectory => GetDirectorySafe(Path.Combine(AppDirectory, "temp"));
    public static string HomeDirectory =>  Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
    public static string AppDirectory => GetDirectorySafe(Path.Combine(HomeDirectory, ".ytdlrunner"));

    public static string SettingsFile => MergePath("settings.json");

    public static string MergePath(string fileName)
    {
        return Path.Combine(AppDirectory, fileName);
    }
    public static async Task<bool> ExecuteProcess(string filename, string arguments)
    {

        try
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                Arguments = arguments,
                FileName = filename
            };

            var process = Process.Start(startInfo);
            await process?.WaitForExitAsync();
            var code = process?.ExitCode;
            return code == 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }

 
    }
    public static void MoveInner(string sourceDirName, string destDirName, bool moveSubDirs, bool pruneDirectory = false)
    {
        var dir = new DirectoryInfo(sourceDirName);
        var dirs = dir.GetDirectories();

        // If the source directory does not exist, throw an exception
        if (!dir.Exists)
        {
            throw new DirectoryNotFoundException(
                "Source directory does not exist or could not be found: "
                + sourceDirName);
        }

        // If the destination directory does not exist, create it
        if (!Directory.Exists(destDirName))
            Directory.CreateDirectory(destDirName);


        // Get the file contents of the directory to copy
        var files = dir.GetFiles();

        foreach (var file in files)
        {
            // Create the path to the new copy of the file
            var temppath = Path.Combine(destDirName, file.Name);

            // Move the file.
            file.MoveTo(temppath);
        }

        // If copySubDirs is true, copy the subdirectories
        if (!moveSubDirs)
            return;

        foreach (var subdir in dirs)
        {
            // Create the subdirectory
            var temppath = Path.Combine(destDirName, subdir.Name);

            // Move the subdirectories
            MoveInner(subdir.FullName, temppath, moveSubDirs: true,pruneDirectory = true);
        }

        if (pruneDirectory && Directory.GetFiles(sourceDirName).Any() == false)
        {
            Directory.Delete(sourceDirName);
        }
    }

}