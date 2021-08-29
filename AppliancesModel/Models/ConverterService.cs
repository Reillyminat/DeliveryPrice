using AppliancesModel.Contracts;
using DeliveryService.BLL.Contracts;
using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace AppliancesModel.Models
{
    public class ConverterService : IConverterService
    {
        private readonly ICurrencyConverter _currencyConverter;

        public ConverterService(ICurrencyConverter converter)
        {
            _currencyConverter = converter;
        }

        public async Task GetExchengesRateAsync(CancellationToken stopToken)
        {
            while (!stopToken.IsCancellationRequested)
            {
                CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-EN");
                var xml = XDocument.Load("https://api.privatbank.ua/p24api/pubinfo?exchange&coursid=11");

                _currencyConverter.USD = Convert.ToDecimal(xml.Elements("exchangerates").Elements("row").
                    FirstOrDefault(x => x.Element("exchangerate").Attribute("ccy").Value == "USD").Elements("exchangerate").
                    FirstOrDefault().Attribute("sale").Value);

                _currencyConverter.EUR = Convert.ToDecimal(xml.Elements("exchangerates").Elements("row").
                    FirstOrDefault(x => x.Element("exchangerate").Attribute("ccy").Value == "EUR").Elements("exchangerate").
                    FirstOrDefault().Attribute("sale").Value);

                await Task.Delay(12000, stopToken);
           }
        }
    }
}
