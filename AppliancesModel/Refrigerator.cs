using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliancesModel
{
    public class Refrigerator : Appliances
    {
        int totalVolume;
        bool containsFreezer;
        public Refrigerator(int id) : base(id)
        {
            Type = AppliancesStock.Refrigerator;
        }

        public Refrigerator(int id, string name, int guarantee, Dimensions dimensions, decimal price,
            string producingCountry, int totalVolume, bool containsFreezer)
            : base(id, name, guarantee, dimensions, price, producingCountry)
        {
            Type = AppliancesStock.Refrigerator;
            this.totalVolume = totalVolume;
            this.containsFreezer = containsFreezer;
        }

        public override void SetProperties()
        {
            int totalVolume;
            bool containsFreezer;
            DataHandler.SetRefrigeratorProperties(out totalVolume, out containsFreezer);
            this.totalVolume = totalVolume;
            this.containsFreezer = containsFreezer;
        }
    }
}
