using CurrencyConverterApp.Data.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CurrencyConverterApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
            {
                services.AddSingleton<UserInterface>();
                services.AddSingleton<ICurrencyConverterService, CurrencyConverterService>();
            }).Build();

            var UI = ActivatorUtilities.CreateInstance<UserInterface>(host.Services);
            UI.StartUI();
        }
    }
}