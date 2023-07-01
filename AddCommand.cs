namespace MyCliApp;

public static class AddCommand
{
    public static void Add(string[] args)
    {
        // Check if the template name is provided as an argument
        if (args.Length < 2)
        {
            Console.WriteLine("Please provide the template name as an argument.");
            return;
        }

        // Get the template name provided by the user
        string templateName = args[1];

        // Get the templates directory
        string templatesDirectory = Path.Combine(AppContext.BaseDirectory, "Templates");

        // Check if the templates directory exists
        if (!Directory.Exists(templatesDirectory))
        {
            Console.WriteLine("Templates directory not found.");
            return;
        }

        // Get the calling directory
        string callingDirectory = Directory.GetCurrentDirectory();

        // Get the template directory path
        string templateDirectoryPath = Path.Combine(templatesDirectory, templateName);

        // Check if the template directory exists
        if (!Directory.Exists(templateDirectoryPath))
        {
            Console.WriteLine($"Template '{templateName}' not found.");
            return;
        }

        // Recursively copy the template files and directories to the calling directory
        CopyTemplate(templateDirectoryPath, callingDirectory);

        Console.WriteLine($"Template '{templateName}' added successfully.");
    }

    private static void CopyTemplate(string sourceDirPath, string destDirPath)
    {
        // Create the destination directory if it doesn't exist
        if (!Directory.Exists(destDirPath))
        {
            Directory.CreateDirectory(destDirPath);
        }

        // Copy the files
        foreach (string file in Directory.GetFiles(sourceDirPath))
        {
            if (file.EndsWith("ignore"))
            {
                continue;
            }
            string destFilePath = Path.Combine(destDirPath, Path.GetFileName(file));
            File.Copy(file, destFilePath, true);
        }

        // Copy the directories recursively
        foreach (string subDirPath in Directory.GetDirectories(sourceDirPath))
        {
            string subDirName = Path.GetFileName(subDirPath);
            string destSubDirPath = Path.Combine(destDirPath, subDirName);
            CopyTemplate(subDirPath, destSubDirPath);
        }
    }
}
