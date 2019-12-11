using System;
using Tasks.Interfaces;
using Tasks.Services;

namespace Tasks
{
    class Program
    {
        private static void Main(string[] args)
        {
            IFizzBuzzService fizzBuzzService = new FizzBuzzService();

            foreach (var result in fizzBuzzService.GetFizzBuzz(100))
            {
                Console.WriteLine(result);
            }
            Console.ReadLine();
        }
    }
}