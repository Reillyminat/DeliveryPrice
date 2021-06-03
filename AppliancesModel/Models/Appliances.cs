using AppliancesModel.UI;

namespace AppliancesModel
{
    public abstract class Appliances
    {
        public AppliancesStock Type { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public int Guarantee { get; set; }
        public Dimensions Dimensions { get; set; }
        public decimal Price { get; set; }
        public string ProducingCountry { get; set; }
        public Appliances() { }
        public Appliances(int id)
        {
            string name, producingCountry;
            int guarantee, amount;
            decimal price;
            Dimensions dimensions;

            PropertiesManager.SetApplianceProperties(out name, out guarantee, out dimensions, out price, out amount, out producingCountry);
            SetProperties();

            Id = id;
            Name = name;
            Guarantee = guarantee;
            Dimensions = dimensions;
            Price = price;
            Amount = amount;
            ProducingCountry = producingCountry;
        }

        public Appliances(int id, string name, int guarantee, Dimensions dimensions, decimal price, int amount, string producingCountry)
        {
            Id = id;
            Name = name;
            Guarantee = guarantee;
            Dimensions = dimensions;
            Price = price;
            Amount = amount;
            ProducingCountry = producingCountry;
        }

        public abstract void SetProperties();
    }
}
