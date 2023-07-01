namespace MyCliApp
{
    class Program
    {
        static void Main(string[] args)
        {
            switch (args[0])
            {
                case "add":
                    AddCommand.Add(args);
                    break;

                case "generate":
                case "g":
                    if ( args[1] == "class" || args[1] == "c")
                    {
                        GenrateCommand.GenerateClass(args[2]);
                    }
                      else if( args[1] == "rclass" || args[1] == "rc")
                    {
                        GenrateCommand.GenerateRepositoryClass(args[2]);
                    }
                      else if( args[1] == "sclass" || args[1] == "sc")
                    {
                        GenrateCommand.GenerateServiceClass(args[2]);
                    }
                    else if( args[1] == "interface" || args[1] == "i")
                    {
                        GenrateCommand.GenerateInterface(args[2]);
                    }
                      else if( args[1] == "rinterface" || args[1] == "ri")
                    {
                        GenrateCommand.GenerateRepositoryInterface(args[2]);
                    }
                      else if( args[1] == "sinterface" || args[1] == "si")
                    {
                        GenrateCommand.GenerateServiceInterface(args[2]);
                    }
                    else
                    {
                        Console.WriteLine("Provide class name or interface name");
                    }
                    break;

                default:
                    Console.WriteLine("Invalid command");
                    break;
            }
        }
    }
}
