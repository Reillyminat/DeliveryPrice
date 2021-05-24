using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliancesModel.Data
{
    public class StockData : IStockData
    {
        public StockData(ICollection<Appliances> stockInfo) {
            Stock = stockInfo;
        }

        public ICollection<Appliances> Stock { get; set; }

        public int Id { get; set; }
    }
}
