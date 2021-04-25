using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliancesModel.Data
{
    public class StockData : IStockData
    {
        public ICollection<Appliances> Stock { get; set; }
    }
}
