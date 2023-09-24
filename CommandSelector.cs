

using System;
using System.Collections.Generic;
namespace MyCliApp;

public class CommandSelector
{
 private static Dictionary<string, Action<string>> commandTypes = 
   
new Dictionary<string,Action<string>>(StringComparer.OrdinalIgnoreCase)
    {
        { "template", GenrateTemplate.AddTemplate },
        { "t", GenrateTemplate.AddTemplate },
        { "all", GenrateCommand.GenerateAllStructure },
        { "class", GenrateCommand.GenerateClass },
        { "c", GenrateCommand.GenerateClass },
        { "rclass", GenrateCommand.GenerateRepositoryClass },
        { "rc", GenrateCommand.GenerateRepositoryClass },
        { "sclass", GenrateCommand.GenerateServiceClass },
        { "sc", GenrateCommand.GenerateServiceClass },
        { "efclass", GenrateCommand.GenerateEFClass },
        { "efc", GenrateCommand.GenerateEFClass },
        { "interface", GenrateCommand.GenerateInterface },
        { "i", GenrateCommand.GenerateInterface },
        { "rinterface", GenrateCommand.GenerateRepositoryInterface },
        { "ri", GenrateCommand.GenerateRepositoryInterface },
        { "sinterface", GenrateCommand.GenerateServiceInterface },
        { "si", GenrateCommand.GenerateServiceInterface },
        { "controller", GenrateCommand.GenerateController },
        { "co", GenrateCommand.GenerateController }
    };

    internal static void SelectType(string type, string name)
    {
        if (type == null)
        {
            Console.WriteLine("Provide type class or interface or template");
            return;
        }

        if (commandTypes.TryGetValue(type, out var selectedType))
        {
            selectedType.Invoke(name);
        }
        else
        {
            Console.WriteLine($"Invalid type: {type}");
        }
    }
}