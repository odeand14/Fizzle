using System;
using System.Linq;
using NUnit.Framework;
using Task2.Interfaces;
using Task2.Rules;
using Task2.Services;

namespace Task2.Tests
{
    public class Tests
    {
        private IFazzBazzService _fazzBazz;
        private const int ListLength = 10;
        
        [SetUp]
        public void Setup()
        {
            _fazzBazz = new FazzBazzService();
        }

        [Test]
        public void TestGetFazzBazz()
        {
            var list = _fazzBazz.GetFazzBazz(ListLength).ToList();
            CollectionAssert.AllItemsAreUnique(list);
            CollectionAssert.AllItemsAreInstancesOfType(list, typeof(string));
            Assert.AreEqual(10, list.Count);
        }

        [Test]
        public void TestFileWrite()
        {
            _fazzBazz.Run(ListLength);
            _fazzBazz.WriteToFile("Test");
            FileAssert.Exists("Test.txt");
        }

        [Test]
        public void TestClearRules()
        {
            var initialList = _fazzBazz.GetFazzBazz(ListLength).ToList();
            
            CollectionAssert.AllItemsAreUnique(initialList.Last());
            
            _fazzBazz.AddRule(new ModuloRule("Test", 2));
            _fazzBazz.AddRule(new PrimeRule("Prime"));
            var updatedList = _fazzBazz.GetFazzBazz(ListLength).ToList();
            
            CollectionAssert.Contains(updatedList, "Test");
            CollectionAssert.Contains(updatedList, "Prime");
            
            _fazzBazz.ClearRules();

            updatedList = _fazzBazz.GetFazzBazz(ListLength).ToList();
            
            CollectionAssert.DoesNotContain(updatedList,"Test");
            CollectionAssert.DoesNotContain(updatedList, "Prime");
        }
        [Test]
        public void TestReverseDirection()
        {

            var initialList = _fazzBazz.GetFazzBazz(ListLength).ToList();
            
            Assert.AreEqual("1", initialList.First());
            
            _fazzBazz.ReverseDirection();

            var listReversed = _fazzBazz.GetFazzBazz(ListLength).ToList();
            
            Assert.AreEqual("10", listReversed.First());
            
            CollectionAssert.AreEquivalent( initialList, listReversed);
        }
        
        [Test]
        public void TestAddRule()
        {
            var listA = _fazzBazz.GetFazzBazz(ListLength).ToList();
            
            CollectionAssert.DoesNotContain(listA, "Test");
            
            _fazzBazz.AddRule(new ModuloRule("Test", 2));

            var listB = _fazzBazz.GetFazzBazz(ListLength).ToList();
            
            CollectionAssert.Contains(listB, "Test");
            CollectionAssert.AreNotEquivalent(listA, listB);
        }
        
    }
}