using CurrencyConverterApp.Data.Services;
using NUnit.Framework;
using System;

namespace CurrencyConverterAppUT
{
    public class CurrencyConverterServiceUT
    {
        [Test]
        public void should_return_converted_value()
        {
            var currencyConverter = new CurrencyConverterService();

            var result = currencyConverter.Convert("eur", "dkk", 100);

            Assert.AreEqual(743.94m, result);
        }

        [Test]
        public void should_throw_exception()
        {
            var currencyConverter = new CurrencyConverterService();

            Assert.Throws<Exception>(
                () => currencyConverter.Convert("euras", "dkk", 100),
                "The currency pair was not found");
        }
    }
}