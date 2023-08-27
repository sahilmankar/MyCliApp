namespace MyCliApp;

public static class NamespceFinder
{
    public static string? FindCsprojFile(string directory)
    {
        string[] csprojFiles = Directory.GetFiles(directory, "*.csproj");
        if (csprojFiles.Length > 0)
        {
            string csprojFilePath = csprojFiles[0];
            string namespceName=Path.GetFileNameWithoutExtension(csprojFilePath);
            Console.WriteLine($"Found Namespace {namespceName}");
            return namespceName;
        }

        string? parentDirectory = Directory.GetParent(directory)?.FullName;
        if (parentDirectory != null)
        {
            return FindCsprojFile(parentDirectory);
        }
        Console.WriteLine("Unable to find Namespace");
        return null;
    }
}
