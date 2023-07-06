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
        string fileContent = GenerateClassCode(className);
        string callingDirectory = Directory.GetCurrentDirectory();
        string filePath = Path.Combine(callingDirectory, fileName);

        File.WriteAllText(filePath, fileContent);

        Console.WriteLine($"Class '{className}' generated successfully.");
    }

    public static void GenerateRepositoryClass(string className)
    {
        className = CapitalizeFirstLetter(className);
        string fileName = className + "Repository" + ".cs";
        string fileContent = GenerateRepositoryClassCode(className);

        string callingDirectory = Directory.GetCurrentDirectory();
        string filePath = Path.Combine(callingDirectory, fileName);

        File.WriteAllText(filePath, fileContent);

        Console.WriteLine($"Class '{className + "Repository"}' generated successfully.");
    }

    public static void GenerateServiceClass(string className)
    {
        className = CapitalizeFirstLetter(className);
        string fileName = className + "Service" + ".cs";
        string fileContent = GenerateServiceClassCode(className);

        string callingDirectory = Directory.GetCurrentDirectory();
        string filePath = Path.Combine(callingDirectory, fileName);

        File.WriteAllText(filePath, fileContent);

        Console.WriteLine($"Class '{className + "Service"}' generated successfully.");
    }

    public static void GenerateEFClass(string className)
    {
        className = CapitalizeFirstLetter(className);
        string fileName = className + "Context" + ".cs";
        string fileContent = GenerateEFClassCode(className);

        string callingDirectory = Directory.GetCurrentDirectory();
        string filePath = Path.Combine(callingDirectory, fileName);

        File.WriteAllText(filePath, fileContent);

        Console.WriteLine($"Class '{className + "Context"}' generated successfully.");
    }

    public static void GenerateInterface(string interfaceName)
    {
        interfaceName = CapitalizeFirstLetter(interfaceName);
        string fileName = "I" + interfaceName + ".cs";
        string fileContent = GenerateInterfaceCode(interfaceName);

        string callingDirectory = Directory.GetCurrentDirectory();
        string filePath = Path.Combine(callingDirectory, fileName);

        File.WriteAllText(filePath, fileContent);

        Console.WriteLine($"Interface '{"I" + interfaceName}' generated successfully.");
    }

    public static void GenerateRepositoryInterface(string interfaceName)
    {
        interfaceName = CapitalizeFirstLetter(interfaceName);

        string fileName = "I" + interfaceName + "Repository" + ".cs";
        string fileContent = GenerateRepositoryInterfaceCode(interfaceName);

        string callingDirectory = Directory.GetCurrentDirectory();
        string filePath = Path.Combine(callingDirectory, fileName);

        File.WriteAllText(filePath, fileContent);

        Console.WriteLine(
            $"Interface '{"I" + interfaceName + "Repository"}' generated successfully."
        );
    }

    public static void GenerateServiceInterface(string interfaceName)
    {
        interfaceName = CapitalizeFirstLetter(interfaceName);
        string fileName = "I" + interfaceName + "Service" + ".cs";
        string fileContent = GenerateServiceInterfaceCode(interfaceName);

        string callingDirectory = Directory.GetCurrentDirectory();
        string filePath = Path.Combine(callingDirectory, fileName);

        File.WriteAllText(filePath, fileContent);

        Console.WriteLine($"Interface '{"I" + interfaceName + "Service"}' generated successfully.");
    }

    public static void GenerateController(string controllerName)
    {
        controllerName = CapitalizeFirstLetter(controllerName);

        string fileName = controllerName + "Controller" + ".cs";
        string fileContent = GenerateControllerCode(controllerName);

        string callingDirectory = Directory.GetCurrentDirectory();
        string filePath = Path.Combine(callingDirectory, fileName);

        File.WriteAllText(filePath, fileContent);

        Console.WriteLine($"Controller '{controllerName + "Controller"}' generated successfully.");
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

namespace MyApp.Controllers
{
    [ApiController]
    [Route(""/api/[controller]"")]
    public class TemplateController : ControllerBase
    {
        private readonly ITemplateService _srv;

        public TemplateController(ITemplateService srv)
        {
            _srv = srv;
        }

    }
}";
        return ReplaceNamespaceAndClassName(code, controllerName);
    }

    private static string GenerateClassCode(string className)
    {
        string code =
            @"
namespace MyApp.Models
{
    public class Template
    {
      
    }
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

namespace MyApp.Repositories.Contexts
{
    public class TemplateContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string? _conString;

        public FarmersContext(IConfiguration configuration)
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

namespace MyApp.Repositories
{
    public class TemplateRepository : ITemplateRepository
    { 

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

namespace MyApp.Services
{
    public class TemplateService : ITemplateService
    {
        private readonly ITemplateRepository _repo;

        public TemplateService(ITemplateRepository repo)
        {
            _repo = repo;
        }
    }
}";
        return ReplaceNamespaceAndClassName(code, className);
    }

    private static string GenerateInterfaceCode(string interfaceName)
    {
        string code =
            @"
namespace MyApp.Interfaces
{
    public interface ITemplate
    {
      
    }
}";
        return ReplaceNamespaceAndClassName(code, interfaceName);
    }

    private static string GenerateRepositoryInterfaceCode(string interfaceName)
    {
        string code =
            @"
using MyApp.Models;

namespace MyApp.Repositories.Interfaces
{
    public interface ITemplateRepository
    {

    }
}";
        return ReplaceNamespaceAndClassName(code, interfaceName);
    }

    private static string GenerateServiceInterfaceCode(string interfaceName)
    {
        string code =
            @"
using MyApp.Repositories.Interfaces;

namespace MyApp.Services.Interfaces
{
    public interface ITemplateService:ITemplateRepository
    {

    } 
}";
        return ReplaceNamespaceAndClassName(code, interfaceName);
    }
}
