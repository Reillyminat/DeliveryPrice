using AppliancesModel.UI;

namespace AppliancesModel.Models
{
    public class Refrigerator : Appliance
    {
        public int TotalVolume { get; set; }

        public bool ContainsFreezer { get; set; }

        public Refrigerator(int id) : base(id)
        {
            Type = AppliancesStock.Refrigerator;
        }

        public Refrigerator(int id, string name, int guarantee, Dimensions dimensions, decimal price,
            int amount, string producingCountry, int totalVolume, bool containsFreezer)
            : base(id, name, guarantee, dimensions, price, amount, producingCountry)
        {
            Type = AppliancesStock.Refrigerator;
            TotalVolume = totalVolume;
            ContainsFreezer = containsFreezer;
        }
    }
}
