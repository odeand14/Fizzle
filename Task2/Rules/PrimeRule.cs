using System;
using Task2.Interfaces;

namespace Task2.Rules
{
    public class PrimeRule : IPrimeRule
    {
        private readonly string _word;
        public PrimeRule(string word)
        {
            this._word = word;
        }

        public string Run(int i)
        {
            return CheckPrimeNumber(i) ? _word : "";
        }

        public bool CheckPrimeNumber(int number)
        {
            if (number < 2)
            {
                return false;
            }
            var m = number /2;    
            for(int i = 2; i <= m; i++)    
            {    
                if(number % i == 0)
                {
                    return false;
                }    
            }
            return true;
        }
    }
}