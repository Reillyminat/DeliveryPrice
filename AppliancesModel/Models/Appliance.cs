namespace AppliancesModel
{
    public abstract class Appliance
    {
        public AppliancesStock Type { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Amount { get; set; }

        public int Guarantee { get; set; }

        public Dimensions Dimensions { get; set; }

        public decimal Price { get; set; }

        public string ProducingCountry { get; set; }

        public Appliance() { }

        public Appliance(int id)
        {
            Id = id;
        }

        public Appliance(
            int id,
            string name,
            int guarantee,
            Dimensions dimensions,
            decimal price,
            int amount,
            string producingCountry)
        {
            Id = id;
            Name = name;
            Guarantee = guarantee;
            Dimensions = dimensions;
            Price = price;
            Amount = amount;
            ProducingCountry = producingCountry;
        }
    }
}
