using AppliancesModel.UI;

namespace AppliancesModel.Models
{
    public class KitchenStove : Appliances
    {
        private bool combinedGasElectric;
        private bool containsOven;
        public KitchenStove(int id) : base(id)
        {
            Type = AppliancesStock.KitchenStove;
        }
        public KitchenStove(int id, string name, int guarantee, Dimensions dimensions, decimal price,
            int amount, string producingCountry, bool combinedGasElectric, bool containsOven)
            : base(id, name, guarantee, dimensions, price, amount, producingCountry)
        {
            Type = AppliancesStock.KitchenStove;
            this.combinedGasElectric = combinedGasElectric;
            this.containsOven = containsOven;
        }

        public override void SetProperties()
        {
            PropertiesManager.SetKitchenStoveProperties(out combinedGasElectric, out containsOven);
        }
    }
}
