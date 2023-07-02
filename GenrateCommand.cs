namespace MyCliApp;

public static class GenrateCommand
{
    public static void GenerateClass(string className)
    {
        string newClassName = className.Substring(0, 1).ToUpper() + className.Substring(1);
        string fileName = newClassName + ".cs";
        string fileContent = GenerateClassCode(newClassName);

        string callingDirectory = Directory.GetCurrentDirectory();
        string filePath = Path.Combine(callingDirectory, fileName);

        File.WriteAllText(filePath, fileContent);

        Console.WriteLine($"Class '{newClassName}' generated successfully.");
    }

    public static void GenerateRepositoryClass(string className)
    {
        string newClassName = className.Substring(0, 1).ToUpper() + className.Substring(1);
        newClassName=newClassName+"Repository";
        string fileName = newClassName + ".cs";
        string fileContent = GenerateRepositoryClassCode(newClassName);

        string callingDirectory = Directory.GetCurrentDirectory();
        string filePath = Path.Combine(callingDirectory, fileName);

        File.WriteAllText(filePath, fileContent);

        Console.WriteLine($"Class '{newClassName}' generated successfully.");
    }

     public static void GenerateServiceClass(string className)
    {
        string newClassName = className.Substring(0, 1).ToUpper() + className.Substring(1);
        string fileName = newClassName+"Service" + ".cs";
        string fileContent = GenerateServiceClassCode(newClassName);

        string callingDirectory = Directory.GetCurrentDirectory();
        string filePath = Path.Combine(callingDirectory, fileName);

        File.WriteAllText(filePath, fileContent);

        Console.WriteLine($"Class '{newClassName+"Service"}' generated successfully.");
    }

     public static void GenerateInterface(string interfaceName)
    {
        string newInterfaceName = interfaceName.Substring(0, 1).ToUpper() + interfaceName.Substring(1);
        newInterfaceName="I"+newInterfaceName;
        string fileName = newInterfaceName + ".cs";
        string fileContent = GenerateInterfaceCode(newInterfaceName);

        string callingDirectory = Directory.GetCurrentDirectory();
        string filePath = Path.Combine(callingDirectory, fileName);

        File.WriteAllText(filePath, fileContent);

        Console.WriteLine($"Interface '{newInterfaceName}' generated successfully.");
    }

     public static void GenerateRepositoryInterface(string interfaceName)
    {
        string newInterfaceName = interfaceName.Substring(0, 1).ToUpper() + interfaceName.Substring(1);
        newInterfaceName="I"+newInterfaceName+"Repository";
        string fileName = newInterfaceName + ".cs";
        string fileContent = GenerateRepositoryInterfaceCode(newInterfaceName);

        string callingDirectory = Directory.GetCurrentDirectory();
        string filePath = Path.Combine(callingDirectory, fileName);

        File.WriteAllText(filePath, fileContent);

        Console.WriteLine($"Interface '{newInterfaceName}' generated successfully.");
    }

      public static void GenerateServiceInterface(string interfaceName)
    {
        string newInterfaceName = interfaceName.Substring(0, 1).ToUpper() + interfaceName.Substring(1);
        newInterfaceName="I"+newInterfaceName;
        string fileName = newInterfaceName+"Service" + ".cs";
        string fileContent = GenerateServiceInterfaceCode(newInterfaceName);

        string callingDirectory = Directory.GetCurrentDirectory();
        string filePath = Path.Combine(callingDirectory, fileName);

        File.WriteAllText(filePath, fileContent);

        Console.WriteLine($"Interface '{newInterfaceName+"Service"}' generated successfully.");
    }



    private static string GenerateClassCode(string className)
    {
        // Generate the code for the class using the provided className
        string classCode =
            "\n"
            + "namespace MyApp.Models ;\n"
            + "public class "
            + className
            + "\n"
            + "{\n"
            + "\n"
            + "}\n";

        return classCode;
    }

     private static string GenerateRepositoryClassCode(string className)
    {
        // Generate the code for the class using the provided className
        string classCode =
            "\n"
            + "using MyApp.Models;\n"
            + "using MyApp.Repositories.Interfaces ;\n"
            + "namespace MyApp.Repositories ;\n"
            + "public class "
            + className +": I"+className
            + "\n"
            + "{\n"
            + "\n"
            + "}\n";

        return classCode;
    }
     private static string GenerateServiceClassCode(string className)
    {
        // Generate the code for the class using the provided className
        string classCode =
            "\n"
            + "using MyApp.Models;\n"
            + "using MyApp.Repositories.Interfaces ;\n"
            + "using MyApp.Services.Interfaces ;\n"
            + "namespace MyApp.Services ;\n"
            + "public class "
            + className+"Service : I"+className+"Service"
            + "\n"
            + "{\n"
            + "private readonly I"+className+"Repository _repo;\n"
            + "public " + className + "Service ( I" + className + "Repository repo )\n"
            + "{\n"
            + "this._repo = repo;\n"
            + "}\n"
            + "\n"
            + "}\n";

        return classCode;
    }

     private static string GenerateInterfaceCode(string interfaceName)
    {
        
        string interfaceCode =
            "\n"
            + "namespace MyApp.Interfaces ;\n"
            + "public interface "
            + interfaceName
            + "\n"
            + "{\n"
            + "\n"
            + "}\n";

        return interfaceCode;
    }

      private static string GenerateRepositoryInterfaceCode(string interfaceName)
    {
        
        string interfaceCode =
            "\n"
            + "using MyApp.Models;\n"
            + "namespace MyApp.Repositories.Interfaces ;\n"
            + "public interface "
            + interfaceName
            + "\n"
            + "{\n"
            + "\n"
            + "}\n";

        return interfaceCode;
    }
      private static string GenerateServiceInterfaceCode(string interfaceName)
    {
        
        string interfaceCode =
            "\n"
            + "using MyApp.Repositories.Interfaces;\n"
            + "namespace MyApp.Services.Interfaces ;\n"
            + "public interface "
            + interfaceName+"Service : "+interfaceName+"Repository"
            + "\n"
            + "{\n"
            + "\n"
            + "}\n";

        return interfaceCode;
    }
}
