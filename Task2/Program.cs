using System;
using System.Linq;
using Task2.Interfaces;
using Task2.Rules;
using Task2.Services;

namespace Task2
{
    class Program
    {

        private static bool _running = true;
        static void Main(string[] args)
        {
            IFazzBazzService fazzBazzService = new FazzBazzService();

            fazzBazzService.AddRule(new ModuloRule("Fizz", 3));
            fazzBazzService.AddRule(new ModuloRule("Buzz", 5));
            fazzBazzService.Print(100);
            fazzBazzService.ClearRules();
            fazzBazzService.ReverseDirection();
            fazzBazzService.AddRule(new ModuloRule("Jazz", 9));
            fazzBazzService.AddRule(new ModuloRule("Fuzz", 4));
            fazzBazzService.Print(100);
            
            Console.WriteLine("Press any key for interactive FizzBuzz!");
            Console.ReadKey();
            fazzBazzService = new FazzBazzService();
            Console.WriteLine("\nWelcome to FizzBuzz, type 'fizz -h' for help.");
            
            var iType = typeof(IRules);
            var iTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => iType.IsAssignableFrom(p))
                .Select(u => u.Name).Where(n => n != iType.Name).ToList();
            
            while (_running)
            {
                Console.Write("~ ");
                var input = Console.ReadLine()?.Split(" ");
                string firstCheck;
                
                try
                {
                    firstCheck = input?[0] + " " + input[1];
                }
                catch (Exception)
                {
                    continue;
                }

                switch (firstCheck)
                {
                    case "fizz -h":
                    {
                        Console.WriteLine("\n*************-------FIZZFAZZFUZZBAZZ!-------**************\n" +
                                          "These are the common Fizz commands to use in various situations:\n\n" +
                                          "Usage: fizz [option] [argument]\n\n" + 
                                          "Options:\n" +
                                          "quit\tEnds the fizzgame, boo\n" +
                                          $"rule\tCreates new rule (possible rule arguments ({string.Join(", ", iTypes)})\n" +
                                          "reverse\tReverse direction of game.\n" +
                                          "clear\tClear all rules in place. If argument specified clears only rule with argument word\n" +
                                          "print \tPrints game, default is 1-100, for different amount add integer argument.\n" +
                                          "write\tWrites current setting to text-file, name can be added as argument.\n");
                        break;
                    }
                    case "fizz quit":
                    {
                        _running = false;
                        break;
                    }
                    case "fizz rule":
                    {
                        string flag;
                        try
                        {
                            flag = input[2];
                        }
                        catch (Exception)
                        {
                            Console.Write("Insert ruletype:");
                            flag = Console.ReadLine();
                            
                        }
                        switch (flag?.ToLower())
                        {
                            case "modulorule":
                            {
                                Console.Write("Insert replacer word: ");
                                var word = Console.ReadLine();
                                Console.Write("Insert modulo: ");
                                try
                                {
                                    var number = int.Parse(Console.ReadLine() ?? throw new Exception());
                                    fazzBazzService.AddRule(new ModuloRule(word, number));
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Failed to create rule with given parameters");
                                }
                                break;
                            }
                            case "primerule":
                            {
                                Console.Write("Insert replacer word: ");
                                var word = Console.ReadLine();
                                fazzBazzService.AddRule(new PrimeRule(word));
                                break;
                            }
                            default:
                                Console.WriteLine("Rule does not exist");
                                break;
                        }
                        
                        break;
                    }
                    case "fizz reverse":
                    {
                        fazzBazzService.ReverseDirection();
                        break;
                    }
                    case "fizz clear":
                    {
                        try
                        {
                            var flag = input[2];
                            fazzBazzService.ClearOneRule(flag);
                            Console.WriteLine($"Removed rule: {flag}");
                        }
                        catch (Exception)
                        {
                            fazzBazzService.ClearRules();
                            Console.WriteLine($"Removed all rules.");
                        }
                        break;
                    }
                    case "fizz print":
                    {
                        try
                        {
                            var flag = int.Parse(input[2]);
                            fazzBazzService.Print(flag);
                        }
                        catch (Exception)
                        {
                            fazzBazzService.Print(100);
                        }
                        break;
                    }
                    case "fizz write":
                    {
                        try
                        {
                            var flag = input[2];
                            fazzBazzService.WriteToFile(flag?.Trim());
                        }
                        catch (Exception)
                        {
                            Console.Write("Supply filename: ");
                            var name = Console.ReadLine();
                            fazzBazzService.WriteToFile(name?.Trim());
                        }
                        Console.WriteLine("File written to project bin.");
                        break;
                    }
                    default:
                        Console.WriteLine("Command not recognized. type 'fizz -h' for help");
                        break;
                        
                }
            }
        }
    }
}