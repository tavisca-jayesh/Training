using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OperatorOverloading.Model;
using System.IO;

namespace OperatorOverloading.UnitTesting
{
    [TestClass]
    public class CurrencyConversionTest
    {
        [TestMethod]
        public void ValidTest()
        {
            var money1 = new Money("100 USD");
            var money2 = money1.Convert("INR");

            Assert.IsTrue(money2.Amount == 6347.345);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void CurrencyNotFound()
        {
          var money1 = new Money("100 USD");
          var money2 = money1.Convert("YEN");
        }

        [TestMethod]
        [ExpectedException(typeof(SystemException))]
        public void CurrencyToConvertInvalid()
        {
            var money1 = new Money("100 USD");
            var money2 = money1.Convert("100");
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void InvalidLengthSourceCurrency()
        {
            var money1 = new Money("100 UD");
            var money2 = money1.Convert("INR");

            var money3 = new Money("100 USDF");
            var money4 = money3.Convert("INR");
        }

        [TestMethod]
        [ExpectedException(typeof(System.SystemException))]
        public void CurrencyToConvertNull()
        {
            var money1 = new Money("100 USD");
            var money2 = money1.Convert(null);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void SourceNull()
        {
            var money1 = new Money(null);
            var money2 = money1.Convert("INR");
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void MoneyObjectNull()
        {
            Money money1 = null;
            var money2 = money1.Convert("INR");
        }
    }
}
