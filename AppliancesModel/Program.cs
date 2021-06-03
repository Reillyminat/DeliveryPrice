using AppliancesModel.Contracts;
using AppliancesModel.Data;
using AppliancesModel.Models;
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

            container.Set<IUserData>(new UserData());
            var usersInfo = container.Get<IUserData>();
            usersInfo.Users = new List<User>();

            container.Set<IOrdersData>(new OrdersData());
            var ordersInfo = container.Get<IOrdersData>();
            ordersInfo.Order = new List<Order>();

            container.Set<IAppliancesDistribution>(new AppliancesDistribution(container.Get<IStockData>()));
            var appliancesDistribution = container.Get<IAppliancesDistribution>();

            container.Set<IOrderManager>(new OrderManager(container.Get<IOrdersData>()));
            container.Set<IUserManager>(new UserManager(container.Get<IUserData>()));
            container.Set<IOutputInputHandler>(new ConsoleInputOutput(container.Get<IAppliancesDistribution>(), container.Get<IOrderManager>(), container.Get<IUserManager>()));

            var presenter = container.Get<IOutputInputHandler>();
            presenter.RunMenu();
        }
    }
}