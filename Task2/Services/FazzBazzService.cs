using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Task2.Interfaces;

namespace Task2.Services
{
    public class FazzBazzService : IFazzBazzService
    {
        private readonly List<IRules> _rules;
        private readonly List<string> _currentList;
        private bool _clockWise;
        public FazzBazzService()
        {
            _rules = new List<IRules>();
            _currentList = new List<string>();
            _clockWise = true;
        }
        
        public IEnumerable<string> GetFazzBazz(int i)
        {
            var fazzBazz = new List<string>();
            _currentList.Clear();
            
            for (int j = 1; j <= i; j++)
            {
                var number = _clockWise ? j : i + 1 - j;
                var str = _rules.Aggregate("", (current, rule) => current + rule.Run(number));

                if (str.Length == 0)
                {
                    str += number;
                }

                fazzBazz.Add(str);
            }

            _currentList.AddRange(fazzBazz);
            return fazzBazz;
        }

        public void AddRule(IRules rule)
        {
            _rules.Add(rule);
        }

        public void ClearRules()
        {
            _rules.Clear();
        }

        public void ClearOneRule(string word)
        {
            var rule = _rules.FirstOrDefault(s => s.GetWord() == word);
            _rules.Remove(rule);
        }

        public void ReverseDirection()
        {
            _clockWise = !_clockWise;
        }
        
        public void WriteToFile(string fileName)
        {
            var name = fileName;
            if (!name.EndsWith(".txt"))
            {
                name += ".txt";
            }
            using TextWriter writer = File.CreateText($"./{name}");
            foreach (var line in _currentList)
            {
                writer.WriteLine(line);
            }
        }

        public void Print(int times)
        {
            Console.WriteLine("---START---");
            foreach (var result in GetFazzBazz(times))
            {
                Console.WriteLine(result);
            }
            Console.WriteLine("---END---");
        }
    }
}