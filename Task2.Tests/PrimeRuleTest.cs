using NUnit.Framework;
using Task2.Interfaces;
using Task2.Rules;

namespace Task2.Tests
{
    public class PrimeRuleTest
    {
        private IPrimeRule _primeRule;
        [SetUp]
        public void Setup()
        {
            _primeRule = new PrimeRule("Prime");
        }

        [Test]
        public void TestNotPrime()
        {
            var isPrime = _primeRule.CheckPrimeNumber(123);
            Assert.False(isPrime);
        }
        
        [Test]
        public void TestPrime()
        {
            var isPrime = _primeRule.CheckPrimeNumber(23);
            Assert.True(isPrime);
        }

        [Test]
        public void TestNotPrimeResult()
        {
            var primeResult = _primeRule.Run(4);
            Assert.AreEqual(primeResult, "");
        }
        
        [Test]
        public void TestPrimeResult()
        {
            var primeResult = _primeRule.Run(13);
            Assert.AreEqual(primeResult, "Prime");
        }
    }
}