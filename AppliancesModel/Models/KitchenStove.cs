using AppliancesModel.UI;

namespace AppliancesModel.Models
{
    public class KitchenStove : Appliances
    {
        public bool CombinedGasElectric { get; set; }

        public bool ContainsOven { get; set; }

        public KitchenStove() { }

        public KitchenStove(int id) : base(id)
        {
            Type = AppliancesStock.KitchenStove;
        }

        public KitchenStove(int id, string name, int guarantee, Dimensions dimensions, decimal price,
            int amount, string producingCountry, bool combinedGasElectric, bool containsOven)
            : base(id, name, guarantee, dimensions, price, amount, producingCountry)
        {
            Type = AppliancesStock.KitchenStove;
            CombinedGasElectric = combinedGasElectric;
            ContainsOven = containsOven;
        }

        public override void SetProperties()
        {
            bool combinedGasElectric, containsOven;
            PropertiesManager.SetKitchenStoveProperties(out combinedGasElectric, out containsOven);
            CombinedGasElectric = combinedGasElectric;
            ContainsOven = containsOven;
        }
    }
}
