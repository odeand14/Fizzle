namespace Task2.Interfaces
{
    public interface IModuloRule : IRules
    {
        bool CheckModulo(int number, int modulo);
    }
}