using System.Text.RegularExpressions;

namespace MyCliApp;

public static class GenrateCommand
{
    public static void GenerateClass(string className)
    {
        className = className.Substring(0, 1).ToUpper() + className.Substring(1);
        string fileName = className + ".cs";
        string fileContent = GenerateClassCode(className);

        string callingDirectory = Directory.GetCurrentDirectory();
        string filePath = Path.Combine(callingDirectory, fileName);

        File.WriteAllText(filePath, fileContent);

        Console.WriteLine($"Class '{className}' generated successfully.");
    }

    public static void GenerateRepositoryClass(string className)
    {
        className = className.Substring(0, 1).ToUpper() + className.Substring(1);
        string fileName = className + "Repository" + ".cs";
        string fileContent = GenerateRepositoryClassCode(className);

        string callingDirectory = Directory.GetCurrentDirectory();
        string filePath = Path.Combine(callingDirectory, fileName);

        File.WriteAllText(filePath, fileContent);

        Console.WriteLine($"Class '{className + "Repository"}' generated successfully.");
    }

    public static void GenerateServiceClass(string className)
    {
        className = className.Substring(0, 1).ToUpper() + className.Substring(1);
        string fileName = className + "Service" + ".cs";
        string fileContent = GenerateServiceClassCode(className);

        string callingDirectory = Directory.GetCurrentDirectory();
        string filePath = Path.Combine(callingDirectory, fileName);

        File.WriteAllText(filePath, fileContent);

        Console.WriteLine($"Class '{className + "Service"}' generated successfully.");
    }

    public static void GenerateInterface(string interfaceName)
    {
        interfaceName = interfaceName.Substring(0, 1).ToUpper() + interfaceName.Substring(1);
        string fileName = "I" + interfaceName + ".cs";
        string fileContent = GenerateInterfaceCode(interfaceName);

        string callingDirectory = Directory.GetCurrentDirectory();
        string filePath = Path.Combine(callingDirectory, fileName);

        File.WriteAllText(filePath, fileContent);

        Console.WriteLine($"Interface '{"I" + interfaceName}' generated successfully.");
    }

    public static void GenerateRepositoryInterface(string interfaceName)
    {
        interfaceName = interfaceName.Substring(0, 1).ToUpper() + interfaceName.Substring(1);

        string fileName = "I" + interfaceName + "Repository" + ".cs";
        string fileContent = GenerateRepositoryInterfaceCode(interfaceName);

        string callingDirectory = Directory.GetCurrentDirectory();
        string filePath = Path.Combine(callingDirectory, fileName);

        File.WriteAllText(filePath, fileContent);

        Console.WriteLine($"Interface '{"I" + interfaceName + "Repository"}' generated successfully.");
    }

    public static void GenerateServiceInterface(string interfaceName)
    {
        interfaceName = interfaceName.Substring(0, 1).ToUpper() + interfaceName.Substring(1);
        string fileName = "I" +interfaceName + "Service" + ".cs";
        string fileContent = GenerateServiceInterfaceCode(interfaceName);

        string callingDirectory = Directory.GetCurrentDirectory();
        string filePath = Path.Combine(callingDirectory, fileName);

        File.WriteAllText(filePath, fileContent);

        Console.WriteLine($"Interface '{"I" +interfaceName + "Service"}' generated successfully.");
    }

    public static void GenerateController(string controllerName)
    {
        controllerName = controllerName.Substring(0, 1).ToUpper() + controllerName.Substring(1);

        string fileName = controllerName + "Controller" + ".cs";
        string fileContent = GenerateControllerCode(controllerName);

        string callingDirectory = Directory.GetCurrentDirectory();
        string filePath = Path.Combine(callingDirectory, fileName);

        File.WriteAllText(filePath, fileContent);

        Console.WriteLine($"Controller '{controllerName + "Controller"}' generated successfully.");
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

        string pattern = @"Template";
        string replacedCode = Regex.Replace(code, pattern, controllerName);
        return replacedCode;
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

        string pattern = @"Template";
        string replacedCode = Regex.Replace(code, pattern, className);
        return replacedCode;
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
        string pattern = @"Template";
        string replacedCode = Regex.Replace(code, pattern, className);
        return replacedCode;
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
        string pattern = @"Template";
        string replacedCode = Regex.Replace(code, pattern, className);
        return replacedCode;
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
        string pattern = @"Template";
        string replacedCode = Regex.Replace(code, pattern, interfaceName);
        return replacedCode;
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
        string pattern = @"Template";
        string replacedCode = Regex.Replace(code, pattern, interfaceName);
        return replacedCode;
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
        string pattern = @"Template";
        string replacedCode = Regex.Replace(code, pattern, interfaceName);
        return replacedCode;
    }
}
