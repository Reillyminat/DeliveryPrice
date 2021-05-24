using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliancesModel
{
    public interface IStockData
    {
        ICollection<Appliances> Stock { get; set; }

        public int Id { get; set; }
    }
}
