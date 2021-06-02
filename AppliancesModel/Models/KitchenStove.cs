namespace AppliancesModel.Models
{
    public class KitchenStove : Appliance
    {
        public bool CombinedGasElectric { get; set; }

        public bool ContainsOven { get; set; }

        public KitchenStove(int id) : base(id)
        {
            Type = AppliancesStock.KitchenStove;
        }

        public KitchenStove(
            int id,
            string name,
            int guarantee,
            Dimensions dimensions,
            decimal price,
            int amount,
            string producingCountry,
            bool combinedGasElectric,
            bool containsOven)
            : base(id, name, guarantee, dimensions, price, amount, producingCountry)
        {
            Type = AppliancesStock.KitchenStove;
            CombinedGasElectric = combinedGasElectric;
            ContainsOven = containsOven;
        }
    }
}
