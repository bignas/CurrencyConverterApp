using CurrencyConverterApp.Data.Services;

namespace CurrencyConverterApp
{
    public class UserInterface
    {
        private ICurrencyConverterService m_currencyConverterService;

        public UserInterface(ICurrencyConverterService currencyConverterService)
        {
            m_currencyConverterService = currencyConverterService;
        }
        public void StartUI()
        {
            char[] seperators = { '/', ' ' };
            while (true)
            {
                var userInput = Console.ReadLine();
                var inputValues = userInput.Split(seperators);

                switch (inputValues[0].ToLower())
                {
                    case "exchange":
                        ExchangeCommand(inputValues);
                        break;
                    default:
                        Console.WriteLine("The command was not found");
                        break;
                };

                Console.WriteLine();
            }
        }

        private void ExchangeCommand(string[] convertionValues)
        {
            if (convertionValues.Length == 4 && Decimal.TryParse(convertionValues[3], out var amount))
            {
                try
                {
                    var convertedValue = m_currencyConverterService.Convert(convertionValues[1], convertionValues[2], amount);
                    Console.WriteLine(convertedValue.ToString("N4"));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Usage: Exchange <currency pair> <amount to exchange>");
            }
        }
    }
}
