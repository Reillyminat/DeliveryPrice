using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliancesModel
{
    public class KitchenStove : Appliances
    {
        bool combinedGasElectric;
        bool containsOven;
        public KitchenStove(int id) : base(id)
        {
            Type = AppliancesStock.KitchenStove;
        }
        public KitchenStove(int id, string name, int guarantee, Dimensions dimensions, decimal price,
            string producingCountry, bool combinedGasElectric, bool containsOven)
            : base(id, name, guarantee, dimensions, price, producingCountry)
        {
            Type = AppliancesStock.KitchenStove;
            this.combinedGasElectric = combinedGasElectric;
            this.containsOven = containsOven;
        }

        public override void SetProperties()
        {
            bool combinedGasElectric, containsOven;
            DataHandler.SetKitchenStoveProperties(out combinedGasElectric, out containsOven);
            this.combinedGasElectric = combinedGasElectric;
            this.containsOven = containsOven;
        }
    }
}
