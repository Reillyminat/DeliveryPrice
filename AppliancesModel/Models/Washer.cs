using AppliancesModel.UI;

namespace AppliancesModel.Models
{
    public class Washer : Appliance
    {
        public int WaterConsuming { get; set; }

        public int MaximumLoad { get; set; }

        public Washer(int id) : base(id)
        {
            Type = AppliancesStock.Washer;
        }

        public Washer(int id, string name, int guarantee, Dimensions dimensions, decimal price,
            int amount, string producingCountry, int waterConsuming, int maximumLoad)
            : base(id, name, guarantee, dimensions, price, amount, producingCountry)
        {
            Type = AppliancesStock.Washer;
            WaterConsuming = waterConsuming;
            MaximumLoad = maximumLoad;
        }
    }
}
