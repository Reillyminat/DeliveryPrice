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

            container.Set<IAppliances>(new Appliances(new List<Appliance>()));
            var stockInfo = container.Get<IAppliances>();
            stockInfo.InitializeModel();

            container.Set<IAppliancesDistribution>(new AppliancesDistribution(container.Get<IAppliances>()));
            var appliancesDistribution = container.Get<IAppliancesDistribution>();

            container.Set<IOutputInputHandler>(new ConsoleInputOutput(container.Get<IAppliancesDistribution>()));
            var presenter = container.Get<IOutputInputHandler>();
            presenter.RunMenu(appliancesDistribution);
        }
    }
}