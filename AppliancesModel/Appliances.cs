namespace AppliancesModel
{
    public abstract class Appliances
    {
        public AppliancesStock Type { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Guarantee { get; set; }
        public Dimensions Dimensions { get; set; }
        public decimal Price { get; set; }
        public string ProducingCountry { get; set; }
        public IOutputInputHandler DataHandler { get; set; }
        public Appliances(int id)
        {
            string name, producingCountry;
            int guarantee;
            decimal price;
            Dimensions dimensions;

            DataHandler = new ConsoleInputOutput();
            DataHandler.SetApplianceProperties(out name, out guarantee, out dimensions, out price, out producingCountry);
            SetProperties();

            this.Id = id;
            this.Name = name;
            this.Guarantee = guarantee;
            this.Dimensions = dimensions;
            this.Price = price;
            this.ProducingCountry = producingCountry;
        }

        public Appliances(int id, string name, int guarantee, Dimensions dimensions, decimal price, string producingCountry)
        {
            this.Id = id;
            this.Name = name;
            this.Guarantee = guarantee;
            this.Dimensions = dimensions;
            this.Price = price;
            this.ProducingCountry = producingCountry;
        }

        public abstract void SetProperties();
    }
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
    public class KitchenStove : Appliances
    {
        bool combinedGasElectric;
        bool containsOven;
        public KitchenStove(int id) : base(id)
        {
            Type = AppliancesStock.KitchenStove;
        }
        public KitchenStove(int id, string name, int guarantee, Dimensions dimensions, decimal price,
            string producingCountry, bool combinedGasElectric, bool containsOven)
            : base(id, name, guarantee, dimensions, price, producingCountry)
        {
            Type = AppliancesStock.KitchenStove;
            this.combinedGasElectric = combinedGasElectric;
            this.containsOven = containsOven;
        }

        public override void SetProperties()
        {
            bool combinedGasElectric, containsOven;
            DataHandler.SetKitchenStoveProperties(out combinedGasElectric, out containsOven);
            this.combinedGasElectric = combinedGasElectric;
            this.containsOven = containsOven;
        }
    }
}
