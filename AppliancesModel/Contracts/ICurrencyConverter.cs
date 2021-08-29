using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.BLL.Contracts
{
    public interface ICurrencyConverter
    {
        decimal USD { get; set; }
        decimal ConvertToUSD(decimal priceUAH);

        decimal EUR { get; set; }
        decimal ConvertToEUR(decimal priceUAH);
    }
}
