using System.Text.RegularExpressions;

namespace MyCliApp;

public static class GenrateCommand
{
    private static string NamespacePattern = @"MyApp";
    private static string NamespceName =
        NamespceFinder.FindCsprojFile(Directory.GetCurrentDirectory()) ?? string.Empty;
    private static string ClassPattern = @"Template";

    private static string CapitalizeFirstLetter(string input)
    {
        return input.Substring(0, 1).ToUpper() + input.Substring(1);
    }

    public static void GenerateClass(string className)
    {
        className = CapitalizeFirstLetter(className);
        string fileName = className + ".cs";
        // string callingDirectory = Directory.GetCurrentDirectory();
        string filePath = Path.Combine("Models", fileName);
        if (!File.Exists(filePath))
        {
            string fileContent = GenerateClassCode(className);
            File.WriteAllText(filePath, fileContent);
            Console.WriteLine($"Class '{className}' generated successfully.");
        }
        else
        {
            Console.WriteLine($"File '{fileName}' already exists. Skipping file creation.");
        }
    }

    public static void GenerateRepositoryClass(string className)
    {
        className = CapitalizeFirstLetter(className);
        string fileName = className + "Repository" + ".cs";

        // string callingDirectory = Directory.GetCurrentDirectory();
        string filePath = Path.Combine("Repositories", fileName);

        if (!File.Exists(filePath))
        {
            string fileContent = GenerateRepositoryClassCode(className);
            File.WriteAllText(filePath, fileContent);
            Console.WriteLine($"Class '{className + "Repository"}' generated successfully.");
        }
        else
        {
            Console.WriteLine($"File '{fileName}' already exists. Skipping file creation.");
        }
    }

    public static void GenerateServiceClass(string className)
    {
        className = CapitalizeFirstLetter(className);
        string fileName = className + "Service" + ".cs";

        // string callingDirectory = Directory.GetCurrentDirectory();
        string filePath = Path.Combine("Services", fileName);

        if (!File.Exists(filePath))
        {
            string fileContent = GenerateServiceClassCode(className);
            File.WriteAllText(filePath, fileContent);
            Console.WriteLine($"Class '{className + "Service"}' generated successfully.");
        }
        else
        {
            Console.WriteLine($"File '{fileName}' already exists. Skipping file creation.");
        }
    }

    public static void GenerateEFClass(string className)
    {
        className = CapitalizeFirstLetter(className);
        string fileName = className + "Context" + ".cs";

        // string callingDirectory = Directory.GetCurrentDirectory();
        string filePath = Path.Combine("Repositories/Contexts", fileName);

        if (!File.Exists(filePath))
        {
            string fileContent = GenerateEFClassCode(className);
            File.WriteAllText(filePath, fileContent);
            Console.WriteLine($"Class '{className + "Context"}' generated successfully.");
        }
        else
        {
            Console.WriteLine($"File '{fileName}' already exists. Skipping file creation.");
        }
    }

    public static void GenerateInterface(string interfaceName)
    {
        interfaceName = CapitalizeFirstLetter(interfaceName);
        string fileName = "I" + interfaceName + ".cs";

        string callingDirectory = Directory.GetCurrentDirectory();
        string filePath = Path.Combine(callingDirectory, fileName);

        if (!File.Exists(filePath))
        {
            string fileContent = GenerateInterfaceCode(interfaceName);
            File.WriteAllText(filePath, fileContent);
            Console.WriteLine($"Interface '{"I" + interfaceName}' generated successfully.");
        }
        else
        {
            Console.WriteLine($"File '{fileName}' already exists. Skipping file creation.");
        }
    }

    public static void GenerateRepositoryInterface(string interfaceName)
    {
        interfaceName = CapitalizeFirstLetter(interfaceName);

        string fileName = "I" + interfaceName + "Repository" + ".cs";

        // string callingDirectory = Directory.GetCurrentDirectory();
        string filePath = Path.Combine("Repositories/Interfaces", fileName);

        if (!File.Exists(filePath))
        {
            string fileContent = GenerateRepositoryInterfaceCode(interfaceName);
            File.WriteAllText(filePath, fileContent);
            Console.WriteLine(
                $"Interface '{"I" + interfaceName + "Repository"}' generated successfully."
            );
        }
        else
        {
            Console.WriteLine($"File '{fileName}' already exists. Skipping file creation.");
        }
    }

    public static void GenerateServiceInterface(string interfaceName)
    {
        interfaceName = CapitalizeFirstLetter(interfaceName);
        string fileName = "I" + interfaceName + "Service" + ".cs";

        // string callingDirectory = Directory.GetCurrentDirectory();
        string filePath = Path.Combine("Services/Interfaces", fileName);

        if (!File.Exists(filePath))
        {
            string fileContent = GenerateServiceInterfaceCode(interfaceName);
            File.WriteAllText(filePath, fileContent);
            Console.WriteLine(
                $"Interface '{"I" + interfaceName + "Service"}' generated successfully."
            );
        }
        else
        {
            Console.WriteLine($"File '{fileName}' already exists. Skipping file creation.");
        }
    }

    public static void GenerateController(string controllerName)
    {
        controllerName = CapitalizeFirstLetter(controllerName);

        string fileName = controllerName + "Controller" + ".cs";

        // string callingDirectory = Directory.GetCurrentDirectory();
        string filePath = Path.Combine("Controllers", fileName);

        if (!File.Exists(filePath))
        {
            string fileContent = GenerateControllerCode(controllerName);
            File.WriteAllText(filePath, fileContent);
            Console.WriteLine(
                $"Controller '{controllerName + "Controller"}' generated successfully."
            );
        }
        else
        {
            Console.WriteLine($"File '{fileName}' already exists. Skipping file creation.");
        }
    }

    public static void GenerateAllStructure(string className)
    {
        if (TemplatesNeeded())
        {
            SelectTemplate();
        }

        GenerateFolders(className);
    }

    private static bool TemplatesNeeded()
    {
        string[] foldersToCheck =
        {
            // "controllers",
            "Models",
            "Repositories",
            "Repositories/Interfaces",
            "Services",
            "Services/Interfaces",
            "Repositories/Contexts"
        };

        return !foldersToCheck.Any(Directory.Exists);
    }

    private static void SelectTemplate()
    {
        Console.WriteLine("1. Entity Framework Repository Pattern");
        Console.WriteLine("2. Simple Repository Pattern");
        Console.WriteLine("Select template:");

        string? userInput = Console.ReadLine();

        try
        {
            if (userInput is null)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }

            int templateSelection = int.Parse(userInput);

            switch (templateSelection)
            {
                case 1:
                    Console.WriteLine("You selected Entity Framework Repository Pattern.");
                    GenrateTemplate.AddTemplate("efrp");
                    break;

                case 2:
                    Console.WriteLine("You selected Simple Repository Pattern.");
                    GenrateTemplate.AddTemplate("rp");
                    break;

                default:
                    Console.WriteLine("Invalid template selection.");
                    break;
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }

    private static void GenerateFolders(string className)
    {
        string[] foldersToCheck =
        {
            "controllers",
            "Models",
            "Repositories/Interfaces",
            "Services/Interfaces",
            "Repositories",
            "Repositories/Contexts",
            "Services"
        };

        foreach (string folderPath in foldersToCheck)
        {
            if (Directory.Exists(folderPath))
            {
                switch (folderPath)
                {
                    case "controllers":
                        GenerateController(className);
                        break;
                    case "Models":
                        GenerateClass(className);
                        break;
                    case "Repositories/Interfaces":
                        GenerateRepositoryInterface(className);
                        break;
                    case "Services/Interfaces":
                        GenerateServiceInterface(className);
                        break;
                    case "Repositories":
                        GenerateRepositoryClass(className);
                        break;
                    case "Repositories/Contexts":
                        GenerateEFClass(className);
                        break;
                    case "Services":
                        GenerateServiceClass(className);
                        break;
                }
            }
        }
    }

    private static string ReplaceNamespaceAndClassName(string code, string name)
    {
        if (!string.IsNullOrEmpty(NamespceName))
        {
            code = Regex.Replace(code, NamespacePattern, NamespceName);
        }

        return Regex.Replace(code, ClassPattern, name);
    }

    private static string GenerateControllerCode(string controllerName)
    {
        string code =
            @"
using MyApp.Models;
using MyApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Controllers;

[ApiController]
[Route(""/api/[controller]"")]
public class TemplateController : ControllerBase
{
    private readonly ITemplateService _service;

    public TemplateController(ITemplateService service)
    {
        _service = service;
    }

}";
        return ReplaceNamespaceAndClassName(code, controllerName);
    }

    private static string GenerateClassCode(string className)
    {
        string code =
            @"
namespace MyApp.Models;

public class Template
{
    
}";
        return ReplaceNamespaceAndClassName(code, className);
    }

    private static string GenerateEFClassCode(string className)
    {
        string code =
            @"
using MyApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace MyApp.Repositories.Contexts;
public class TemplateContext : DbContext
{
    private readonly IConfiguration _configuration;
    private readonly string? _conString;

    public TemplateContext(IConfiguration configuration)
    {
        _configuration = configuration;
        _conString =
            this._configuration.GetConnectionString(""DefaultConnection"")
            ?? throw new ArgumentNullException(nameof(configuration));
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL(
            _conString ?? throw new InvalidOperationException(""Connection string is null."")
        );
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}";
        return ReplaceNamespaceAndClassName(code, className);
    }

    private static string GenerateRepositoryClassCode(string className)
    {
        // Generate the code for the class using the provided className
        string code =
            @"
using MyApp.Models;
using MyApp.Repositories.Interfaces;
using MyApp.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;


namespace MyApp.Repositories;
public class TemplateRepository : ITemplateRepository
{ 
    private readonly IConfiguration _configuration;

    public TemplateRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
}";
        return ReplaceNamespaceAndClassName(code, className);
    }

    private static string GenerateServiceClassCode(string className)
    {
        // Generate the code for the class using the provided className
        string code =
            @"
using MyApp.Services.Interfaces;
using MyApp.Repositories.Interfaces;
using MyApp.Models;

namespace MyApp.Services;
public class TemplateService : ITemplateService
{
    private readonly ITemplateRepository _repository;

    public TemplateService(ITemplateRepository repository)
    {
        _repository = repository;
    }
}";
        return ReplaceNamespaceAndClassName(code, className);
    }

    private static string GenerateInterfaceCode(string interfaceName)
    {
        string code =
            @"
namespace MyApp.Interfaces;
public interface ITemplate
{
    
}";
        return ReplaceNamespaceAndClassName(code, interfaceName);
    }

    private static string GenerateRepositoryInterfaceCode(string interfaceName)
    {
        string code =
            @"
using MyApp.Models;

namespace MyApp.Repositories.Interfaces;
public interface ITemplateRepository
{

}";
        return ReplaceNamespaceAndClassName(code, interfaceName);
    }

    private static string GenerateServiceInterfaceCode(string interfaceName)
    {
        string code =
            @"
using MyApp.Repositories.Interfaces;

namespace MyApp.Services.Interfaces;
public interface ITemplateService:ITemplateRepository
{

} ";
        return ReplaceNamespaceAndClassName(code, interfaceName);
    }
}
