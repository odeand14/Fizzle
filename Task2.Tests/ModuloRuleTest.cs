using NUnit.Framework;
using Task2.Interfaces;
using Task2.Rules;

namespace Task2.Tests
{
    public class ModuloRuleTest
    {
        private ModuloRule _moduloRule;
        
        [SetUp]
        public void Setup()
        {
            _moduloRule = new ModuloRule("Test", 13);
        }
        
        [Test]
        public void TestNotDividable()
        {
            var modTest = _moduloRule.CheckModulo(123, 4);
            Assert.False(modTest);
        }
        
        [Test]
        public void TestDividable()
        {
            var modTest = _moduloRule.CheckModulo(42, 7);
            Assert.True(modTest);
        }

        [Test]
        public void TestNotDividableResult()
        {
            var modTest = _moduloRule.Run(4);
            Assert.AreEqual(modTest, "");
        }
        
        [Test]
        public void TestDividableResult()
        {
            var modTest = _moduloRule.Run(26);
            Assert.AreEqual(modTest, "Test");
        }
        
    }
}