using CurrencyConverterApp.Data.Models;

namespace CurrencyConverterApp.Data.Services
{
    public interface ICurrencyConverterService
    {
        /// <summary>
        /// Converts currency to specified currency
        /// </summary>
        decimal Convert(string from, string to, decimal amount);
    }

    public class CurrencyConverterService : ICurrencyConverterService
    {
        private List<Currency> m_currencies;

        public CurrencyConverterService()
        {
            m_currencies = new List<Currency>()
            {
                new Currency("DKK", 100),
                new Currency("EUR", 743.94m),
                new Currency("USD", 633.11m),
                new Currency("GBP", 852.85m),
                new Currency("SEK", 76.10m),
                new Currency("NOK", 78.40m),
                new Currency("JPY", 5.9740m),
            };
        }

        public decimal Convert(string from, string to, decimal amount)
        {
            var fromCurrency = m_currencies.Where(x => x.Symbol.Equals(from.ToUpper())).FirstOrDefault();
            var toCurrency = m_currencies.Where(x => x.Symbol.Equals(to.ToUpper())).FirstOrDefault();

            if (fromCurrency != null && toCurrency != null && amount > 0)
            {
                var result = fromCurrency.ExchangeRate / toCurrency.ExchangeRate * amount;
                return result;
            }

            throw new Exception($"The currency pair was not found");
        }

    }
}
