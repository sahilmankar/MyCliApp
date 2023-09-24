using System;
using System.Collections.Generic;

namespace MyCliApp;

public class CommandDescription
{
    public required string Command { get; set; }
    public required string Description { get; set; }
    public required string Example { get; set; }

    private static List<CommandDescription> commandDescriptions = new List<CommandDescription>
    {
        new CommandDescription
        {
            Command = "generate , g ",
            Description = "Generate class, interface, or template.",
            Example = ""
        },
        new CommandDescription
        {
            Command = "all",
            Description = "Generate required classes or interfaces based on the folder structure.",
            Example = "Example: dt genrate all ClassName"
        },
        new CommandDescription
        {
            Command = "template , t ",
            Description = "Add folder structure following the repository pattern.",
            Example = "Example: dt genrate template rp. (Repository Pattern) "
        },
        new CommandDescription
        {
            Command = "class , c ",
            Description = "Generate a class in the 'Models' folder.",
            Example = "Example: dt genrate class User"
        },
        new CommandDescription
        {
            Command = "rclass , rc ",
            Description = "Generate a repository class in the 'Repositories' folder.",
            Example = "Example: dt genrate rclass User  . Genrates UserRepository"
        },
        new CommandDescription
        {
            Command = "sclass , sc ",
            Description = "Generate a service class in the 'Services' folder.",
            Example = "Example: dt genrate sclass User . Genrates UserService"
        },
        new CommandDescription
        {
            Command = "efclass , efc ",
            Description =
                "Generate an Entity Framework context class in the 'Repositories/Contexts' folder.",
            Example = "Example: dt genrate efclass User . Genrates UserContext"
        },
        new CommandDescription
        {
            Command = "interface , i ",
            Description = "Generate an interface in the calling directory.",
            Example = "Example: dt genrate interface User. Genrates IUserInterface"
        },
        new CommandDescription
        {
            Command = "rinterface , ri ",
            Description =
                "Generate a repository interface in the 'Repositories/Interfaces' folder.",
            Example = "Example: dt genrate rinterface  User . Genrates IUserRepository"
        },
        new CommandDescription
        {
            Command = "sinterface , si ",
            Description = "Generate a service interface in the 'Services/Interfaces' folder.",
            Example = "Example: dt genrate sinterface User . Genrates IUserService"
        },
        new CommandDescription
        {
            Command = "controller , co ",
            Description = "Generate a controller in the 'Controllers' folder.",
            Example = "Example: dt genrate controller User . Genrates UserController"
        }
    };

    public static void DisplayHelp()
    {
        Console.WriteLine("Usage: dt [command] [type] [classname]");
        Console.WriteLine("Available commands:\n");

        const int columnWidth = 30;

        foreach (var description in commandDescriptions)
        {
            Console.WriteLine($"{description.Command, -columnWidth}{description.Description}");
            Console.WriteLine($"{"", -columnWidth}{description.Example}");
            Console.WriteLine();
        }
    }
}
