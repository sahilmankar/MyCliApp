using System;
using System.Collections.Generic;
namespace MyCliApp;

public class CommandProcessor
{
    private static Dictionary<string, Action<string, string>> baseCommandMap = 
    new Dictionary<string,Action<string, string>>(StringComparer.OrdinalIgnoreCase)
    {
        { "generate", CommandSelector.SelectType },
        { "g", CommandSelector.SelectType }
    };

   
    public static void Process(string[] args)
    {
        try
        {
        if (args.Length == 0 || args[0].Equals("--help", StringComparison.OrdinalIgnoreCase))
        {
            CommandDescription.DisplayHelp();
            return;
        }

        if (baseCommandMap.TryGetValue(args[0], out var command))
        {
            if (args.Length == 3)
            {
                command.Invoke(args[1], args[2]);
            }
            else
            {
                Console.WriteLine("Missing command or argument");
            }
        }
        else
        {
            Console.WriteLine($"Invalid command: {args[0]}");
        }
    }
     catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
}
}
