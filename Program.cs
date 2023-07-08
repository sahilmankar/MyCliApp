namespace MyCliApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    Console.WriteLine("No command specified.");
                    return;
                }

                var commandMap = new Dictionary<string, Action<string, string>>(
                    StringComparer.OrdinalIgnoreCase
                )
                {
                    { "generate", Generate },
                    { "g", Generate }
                };

                if (commandMap.TryGetValue(args[0], out var command))
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

        static void Generate(string type, string name)
        {
            if (type == null)
            {
                Console.WriteLine("Provide type class or interface or template");
                return;
            }

            var generateMap = new Dictionary<string, Action<string>>(
                StringComparer.OrdinalIgnoreCase
            )
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

            if (generateMap.TryGetValue(type, out var generateAction))
            {
                generateAction.Invoke(name);
            }
            else
            {
                Console.WriteLine($"Invalid type: {type}");
            }
        }
    }
}
