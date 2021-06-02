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
}
