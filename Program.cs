
namespace MyCliApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Check if the template name is provided as an argument
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide the template name as an argument.");
                return;
            }

            // Get the template name provided by the user
            string templateName = args[0];

            // Get the templates directory
            string templatesDirectory = Path.Combine(AppContext.BaseDirectory, "Templates");
            System.Console.WriteLine(templatesDirectory);
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

            // Copy the template files to the calling directory
            string[] templateFiles = Directory.GetFiles(templateDirectoryPath, "*", SearchOption.AllDirectories);
            foreach (string templateFile in templateFiles)
            {
                string relativeFilePath = Path.GetRelativePath(templateDirectoryPath, templateFile);
                string destinationFilePath = Path.Combine(callingDirectory, relativeFilePath);
                string destinationDirectory = Path.GetDirectoryName(destinationFilePath);

                // Create the destination directory if it doesn't exist
                Directory.CreateDirectory(destinationDirectory);

                // Copy the file to the destination directory
                File.Copy(templateFile, destinationFilePath, true);
            }

            Console.WriteLine($"Template '{templateName}' added successfully.");
        }
    }
}
