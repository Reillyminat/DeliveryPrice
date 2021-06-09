using AppliancesModel.Contracts;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace AppliancesModel.Models
{
    public class ConverterService : IConverterService
    {
        private readonly CurrencyConverter currencyConverter;

        public ConverterService(CurrencyConverter converter)
        {
            currencyConverter = converter;
        }

        public async Task GetExchengesRateAsync(CancellationToken stopToken)
        {
            while (!stopToken.IsCancellationRequested)
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-EN");
                var xml = XDocument.Load("https://api.privatbank.ua/p24api/pubinfo?exchange&coursid=11");

                currencyConverter.USD = Convert.ToDecimal(xml.Elements("exchangerates").Elements("row").
                    FirstOrDefault(x => x.Element("exchangerate").Attribute("ccy").Value == "USD").Elements("exchangerate").
                    FirstOrDefault().Attribute("sale").Value);

                currencyConverter.EUR = Convert.ToDecimal(xml.Elements("exchangerates").Elements("row").
                    FirstOrDefault(x => x.Element("exchangerate").Attribute("ccy").Value == "EUR").Elements("exchangerate").
                    FirstOrDefault().Attribute("sale").Value);

                await Task.Delay(12000, stopToken);
           }
        }
    }
}
