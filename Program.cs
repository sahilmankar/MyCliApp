namespace MyCliApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {  if (args.Length == 0)
                {
                    Console.WriteLine("No command specified.");
                    return;
                }
                switch (args[0])
                {
                    case "generate":
                    case "g":
                     if (args.Length == 1)
                        {
                            Console.WriteLine("Provide type class or interface or template");
                            return;
                        }
                        if (args.Length == 2)
                        {
                            Console.WriteLine("Provide class name or interface name");
                            return;
                        }

                        if (args[1] == "template" || args[1] == "t")
                        {
                            GenrateTemplate.AddTemplate(args[2]);
                        }
                        else if (args[1] == "class" || args[1] == "c")
                        {
                            GenrateCommand.GenerateClass(args[2]);
                        }
                        else if (args[1] == "rclass" || args[1] == "rc")
                        {
                            GenrateCommand.GenerateRepositoryClass(args[2]);
                        }
                        else if (args[1] == "sclass" || args[1] == "sc")
                        {
                            GenrateCommand.GenerateServiceClass(args[2]);
                        }
                        else if (args[1] == "interface" || args[1] == "i")
                        {
                            GenrateCommand.GenerateInterface(args[2]);
                        }
                        else if (args[1] == "rinterface" || args[1] == "ri")
                        {
                            GenrateCommand.GenerateRepositoryInterface(args[2]);
                        }
                        else if (args[1] == "sinterface" || args[1] == "si")
                        {
                            GenrateCommand.GenerateServiceInterface(args[2]);
                        }
                        else
                        {
                            Console.WriteLine($"Invalid command  {args[1]}");
                        }
                        break;

                    default:
                        Console.WriteLine($"Invalid command {args[0]}");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
