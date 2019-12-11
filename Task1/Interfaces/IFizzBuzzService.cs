using System.Collections.Generic;

namespace Tasks.Interfaces
{
    public interface IFizzBuzzService
    {
        IEnumerable<string> GetFizzBuzz(int i);
        bool CheckNumber(int number, int modulo);
    }
}