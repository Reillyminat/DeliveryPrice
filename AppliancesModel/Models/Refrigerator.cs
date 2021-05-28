﻿using AppliancesModel.UI;

namespace AppliancesModel.Models
{
    public class Refrigerator : Appliances
    {
        public int TotalVolume;
        public bool ContainsFreezer;
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

        public override void SetProperties()
        {
            int totalVolume;
            bool containsFreezer;
            PropertiesManager.SetRefrigeratorProperties(out totalVolume, out containsFreezer);
            TotalVolume = totalVolume;
            ContainsFreezer = containsFreezer;
        }
    }
}