using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OperatorOverloading.Model;
using System.IO;
using System.Configuration;

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

            string filePath = ConfigurationManager.AppSettings["Path"];
            string json = System.IO.File.ReadAllText(filePath);
            int indexSource = json.IndexOf("USDINR");
            int indexStart = json.IndexOf(':', indexSource) + 1;
            int indexEnd = json.IndexOf(',', indexStart);
            string value = json.Substring(indexStart, indexEnd - indexStart);
            double checkValue;
            double.TryParse(value, out checkValue);
            Assert.IsTrue(money2.Amount == checkValue * money1.Amount);
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

    }
}
