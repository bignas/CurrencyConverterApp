namespace CurrencyConverterApp.Data.Models
{
    public class Currency
    {
        public string Symbol { get; set; }
        public decimal ExchangeRate { get; set; }

        public Currency(string symbol, decimal exchangeRate)
        {
            Symbol = symbol;
            ExchangeRate = exchangeRate;
        }
    }
}
