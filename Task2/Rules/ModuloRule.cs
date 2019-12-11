using System;
using Task2.Interfaces;

namespace Task2.Rules
{
    public class ModuloRule : IModuloRule
    {
        private readonly string _word;
        private readonly int _modulo;
        public ModuloRule(string word, int modulo)
        {
            this._word = word;
            this._modulo = modulo;
        }

        public string Run(int i)
        {
            return CheckModulo(i, _modulo) ? _word : "";
        }

        public bool CheckModulo(int number, int modulo)
        {
            return number % modulo == 0;
        }
    }
}