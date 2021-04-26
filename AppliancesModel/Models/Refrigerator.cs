using AppliancesModel.UI;

namespace AppliancesModel.Models
{
    public class Refrigerator : Appliances
    {
        private int totalVolume;
        private bool containsFreezer;
        public Refrigerator(int id) : base(id)
        {
            Type = AppliancesStock.Refrigerator;
        }

        public Refrigerator(int id, string name, int guarantee, Dimensions dimensions, decimal price,
            int amount, string producingCountry, int totalVolume, bool containsFreezer)
            : base(id, name, guarantee, dimensions, price, amount, producingCountry)
        {
            Type = AppliancesStock.Refrigerator;
            this.totalVolume = totalVolume;
            this.containsFreezer = containsFreezer;
        }

        public override void SetProperties()
        {
            PropertiesManager.SetRefrigeratorProperties(out totalVolume, out containsFreezer);
        }
    }
}
