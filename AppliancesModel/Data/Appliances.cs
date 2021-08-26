using AppliancesModel.Models;
using DeliveryServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliancesModel.Data
{
    public class Appliances : IAppliances
    {
        public Appliances(ICollection<Product> stockInfo)
        {
            Stock = stockInfo;
        }

        public ICollection<Product> Stock { get; set; }

        public int Id { get; set; }
    }
}
