using System.Linq;
using NUnit.Framework;
using Tasks.Interfaces;
using Tasks.Services;

namespace Task1.Tests
{
    public class Tests
    {
        private IFizzBuzzService _fizz;
        
        [SetUp]
        public void Setup()
        {
            _fizz = new FizzBuzzService();
        }

        [Test]
        public void TestNotDividable()
        {
            var modTest = _fizz.CheckNumber(123, 4);
            Assert.False(modTest);
        }
        
        [Test]
        public void TestDividable()
        {
            var modTest = _fizz.CheckNumber(85, 5);
            Assert.True(modTest);
        }
        
        [Test]
        public void TestRunTimes()
        {
            var count = _fizz.GetFizzBuzz(100).Count();
            Assert.AreEqual(100, count);
        }
    }
}