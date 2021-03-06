using DeliveryService.BLL.Contracts;

namespace AppliancesModel
{
    public class CurrencyConverter : ICurrencyConverter
    {
        public decimal USD { get; set; }
        public decimal ConvertToUSD(decimal priceUAH) => priceUAH / USD;

        public decimal EUR { get; set; }
        public decimal ConvertToEUR(decimal priceUAH) => priceUAH / EUR;

    }
}
