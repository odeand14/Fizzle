using System;
using System.Collections.Generic;
using Task2.Interfaces;
using Task2.Rules;
using Task2.Services;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            IFazzBazzService fazzBazzService = new FazzBazzService();

            fazzBazzService.AddRule(new ModuloRule("Fizz", 3));
            fazzBazzService.AddRule(new ModuloRule("Buzz", 5));

            fazzBazzService.Run(100);
            //azzBazzService.WriteToFile("FizzBuzz.txt");

            fazzBazzService.ClearRules();
            
            fazzBazzService.ReverseDirection();
            
            fazzBazzService.AddRule(new ModuloRule("Jazz", 9));
            fazzBazzService.AddRule(new ModuloRule("Fuzz", 4));
            //fazzBazzService.AddRule(new PrimeRule("Pazz"));
            
            fazzBazzService.Run(100);
            //fazzBazzService.WriteToFile("JazzFuzz");
            
            Console.ReadLine();

            var intCreator = new ThingCreator1();
            var stringCreator = new ThingCreator2();
            var tests = new List<Test>();
//TODO Follow this, 
            for (int i = 0; i < 100; i++)
            {
                tests.Add(i % 3 == 0 
                    ? stringCreator.FactoryMethod() 
                    : intCreator.FactoryMethod());
            }

            foreach (var test in tests)
            {
                Console.WriteLine(test.GetType().Name);
            }
        }
    }

    internal abstract class Creator
    {
        public abstract Test FactoryMethod();

    }
    
    class ThingCreator1 : Creator
    {
        public override Test FactoryMethod()
        {
            return new Thing1();
        }
    }   
    
    class ThingCreator2 : Creator
    {
        public override Test FactoryMethod()

        {
            return new Thing2();
        }
    }
    
    internal abstract class Test
    {
        
    }

    class Thing1 : Test
    {
        public int Num { set; get; }
    }

    class Thing2 : Test
    {
        public string Word { set; get; }
    }
}