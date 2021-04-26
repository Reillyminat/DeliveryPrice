using AppliancesModel.UI;

namespace AppliancesModel.Models
{
    public class Washer : Appliances
    {
        private int waterConsuming;
        private int maximumLoad;
        public Washer(int id) : base(id)
        {
            Type = AppliancesStock.Washer;
        }

        public Washer(int id, string name, int guarantee, Dimensions dimensions, decimal price,
            int amount, string producingCountry, int waterConsuming, int maximumLoad)
            : base(id, name, guarantee, dimensions, price, amount, producingCountry)
        {
            Type = AppliancesStock.Washer;
            this.waterConsuming = waterConsuming;
            this.maximumLoad = maximumLoad;
        }

        public override void SetProperties()
        {
            int maximumLoad;
            PropertiesManager.SetWasherProperties(out waterConsuming, out maximumLoad);
        }
    }
}
