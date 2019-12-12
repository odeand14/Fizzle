using System.Collections.Generic;

namespace Task2.Interfaces
{
    public interface IFazzBazzService
    {
        IEnumerable<string> GetFazzBazz(int i);
        void WriteToFile(string fileName);
        void AddRule(IRules rule);
        void ClearRules();
        void ClearOneRule(string word);
        void ReverseDirection();
        void Print(int times);
    }
}