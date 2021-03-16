using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TransUnion;

namespace UnitTests
{
    [TestClass]
    public class AtmTests
    {
        [TestMethod]
        public void TestCase1_1()
        {
            var atm = new ATM11();
            var exchange = atm.Exchange(800);
            var expectedAmount = new Dictionary<double, int> {{200, 4}};

            CollectionAssert.AreEquivalent(exchange.ToList(), expectedAmount.ToList());
        }

        [TestMethod]
        public void TestCase1_1NotDivisibleAmount()
        {
            var atm = new ATM11();
            var exchange = atm.Exchange(700);
            var expectedAmount = new Dictionary<double, int> { { 200, 3 } };

            CollectionAssert.AreEquivalent(exchange.ToList(), expectedAmount.ToList());
        }


        [TestMethod]
        public void TestCase1_2()
        {
            var atm = new ATM12();
            var exchange = atm.Exchange(800);
            var expectedAmount = new Dictionary<double, int> { { 200, 4 } };

            CollectionAssert.AreEquivalent(exchange.ToList(), expectedAmount.ToList());
        }

        [TestMethod]
        public void TestCase1_2NotDivisibleAmount()
        {
            var atm = new ATM12();
            var exchange = atm.Exchange(700);
            var expectedAmount = new Dictionary<double, int> { { 200, 4 } };

            CollectionAssert.AreEquivalent(exchange.ToList(), expectedAmount.ToList());
        }

        [TestMethod]
        public void TestCase1_3()
        {
            var atm = new ATM13();
            var exchange = atm.Exchange(801);
            var expectedAmount = new Dictionary<double, int> { { 200, 4 }, {0.01, 100} };

            CollectionAssert.AreEquivalent(exchange.ToList(), expectedAmount.ToList());
        }

        [TestMethod]
        public void TestCase1_3NotDivisibleAmount()
        {
            var atm = new ATM13();
            var exchange = atm.Exchange(800.001);
            var expectedAmount = new Dictionary<double, int> { { 200, 4 }, { 0.01, 1 } };

            CollectionAssert.AreEquivalent(exchange.ToList(), expectedAmount.ToList());
        }

        [TestMethod]
        public void TestCase1_4()
        {
            var atm = new ATM14();
            var exchange = atm.Exchange(831);
            var expectedAmount = new Dictionary<double, int> { { 500, 1 }, { 200, 1 }, { 100, 1 }, { 20, 1 }, { 10, 1 }, { 1, 1 } };

            CollectionAssert.AreEquivalent(exchange.ToList(), expectedAmount.ToList());
        }

        [TestMethod]
        public void TestCase1_4NotDivisibleAmount()
        {
            var atm = new ATM14();
            var exchange = atm.Exchange(830.001);
            var expectedAmount = new Dictionary<double, int> { { 500, 1 }, { 200, 1 }, { 100, 1 }, { 20, 1 }, { 10, 1 },  { 0.01, 1 } };

            CollectionAssert.AreEquivalent(exchange.ToList(), expectedAmount.ToList());
        }


        //TODO Create ATM initializer to test with specific amounts of bills available instead of random 1-10 values
        [TestMethod]
        public void TestCase1_5()
        {
            var atm = new ATM15();
            var exchange = atm.Exchange(831);
            var expectedAmount = new Dictionary<double, int> { { 500, 1 }, { 200, 1 }, { 100, 1 }, { 20, 1 }, { 10, 1 }, { 1, 1 } };

            CollectionAssert.AreEquivalent(exchange.ToList(), expectedAmount.ToList());
        }

        [TestMethod]
        public void TestCase1_5NotAvailableAmount()
        {
            var atm = new ATM15();
            var exchange = atm.Exchange(9999.999);
            Assert.IsNull(exchange);
        }
    }
}
