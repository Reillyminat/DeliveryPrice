using AppliancesModel.Data;
using System;
using System.Collections.Generic;

namespace AppliancesModel
{
    public class Program
    {
        static void Main(string[] args)
        {
            var stock = new StockData();
            stock.Stock = new List<Appliances>();
            var distribution = new AppliancesDistribution(stock);
            distribution.InitializeModel();
            var presenter = new ConsoleInputOutput();
            presenter.RunMenu(distribution);
        }
    }
}

