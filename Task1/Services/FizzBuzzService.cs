using System.Collections.Generic;
using Tasks.Interfaces;

namespace Tasks.Services
{
    public class FizzBuzzService : IFizzBuzzService
    {
        public IEnumerable<string> GetFizzBuzz(int i)
        {
            var fizzBuzz = new List<string>();
            
            for (int j = 1; j <= i; j++)
            {
                var str = "";
                
                if (CheckNumber(j, 3))
                {
                    str += "Fizz";
                }

                if (CheckNumber(j, 5))
                {
                    str += "Buzz";
                }

                if (str.Length == 0)
                {
                    str += j;
                }

                fizzBuzz.Add(str);
            }

            return fizzBuzz;
        }
        public bool CheckNumber(int number, int modulo)
        {
            return number % modulo == 0;
        }


    }
}