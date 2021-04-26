using AppliancesModel.Contracts;
using AppliancesModel.Data;
using System.Collections.Generic;

namespace AppliancesModel
{
    public class Program
    {
        static void Main(string[] args)
        {
            var container = new ImplementationsContainer();

            container.Set<IStockData>(new StockData());
            var stockInfo = container.Get<IStockData>();
            stockInfo.Stock = new List<Appliances>();

            container.Set<IAppliancesDistribution>(new AppliancesDistribution(container.Get<IStockData>()));
            var appliancesDistribution = container.Get<IAppliancesDistribution>();
            appliancesDistribution.InitializeModel();

            container.Set<IOutputInputHandler>(new ConsoleInputOutput(container.Get<IAppliancesDistribution>()));
            var presenter = container.Get<IOutputInputHandler>();
            presenter.RunMenu(appliancesDistribution);
        }
    }
}