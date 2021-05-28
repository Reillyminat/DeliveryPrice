using AppliancesModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliancesModel.Data
{
    public class Appliances : IAppliances
    {
        public Appliances(ICollection<Appliance> stockInfo)
        {
            Stock = stockInfo;
        }

        public ICollection<Appliance> Stock { get; set; }

        public int Id { get; set; }

        public void InitializeModel()
        {
            if (Stock.Count == 0)
            {
                for (int i = 1; i < 4; i++)
                    Stock.Add(new Washer(Id++, "Washer" + i, 12, new Dimensions(60 + i, 40 + i, 40 + i), 100 * i, i, "Germany", 30 + i, 5 + i));
                for (int i = 1; i < 4; i++)
                    Stock.Add(new Refrigerator(Id++, "Refrigerator" + i, 12, new Dimensions(80 + i, 60 + i, 40 + i), 100 * i, i, "Italy", 300 + i, true));
                for (int i = 1; i < 4; i++)
                    Stock.Add(new KitchenStove(Id++, "KitchenStove" + i, 12, new Dimensions(40 + i, 60 + i, 40 + i), 100 * i, i, "France", true, true));
            }
        }
    }
}
