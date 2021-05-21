using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliancesModel
{
    public class Washer : Appliances
    {
        int waterConsuming;
        int maximumLoad;
        public Washer(int id) : base(id)
        {
            Type = AppliancesStock.Washer;
        }

        public Washer(int id, string name, int guarantee, Dimensions dimensions, decimal price,
            string producingCountry, int waterConsuming, int maximumLoad)
            : base(id, name, guarantee, dimensions, price, producingCountry)
        {
            Type = AppliancesStock.Washer;
            this.waterConsuming = waterConsuming;
            this.maximumLoad = maximumLoad;
        }

        public override void SetProperties()
        {
            int waterConsuming, maximumLoad;
            DataHandler.SetWasherProperties(out waterConsuming, out maximumLoad);
            this.waterConsuming = waterConsuming;
            this.maximumLoad = maximumLoad;
        }
    }
}
