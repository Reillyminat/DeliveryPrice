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

            container.Set<IStockData>(new StockData());
            var stockInfo = container.Get<IStockData>();
            stockInfo.Stock = new List<Appliances>();

            container.Set<IUserData>(new UserData());
            var usersInfo = container.Get<IUserData>();
            usersInfo.Users = new List<User>();

            container.Set<IOrdersData>(new OrdersData());
            var ordersInfo = container.Get<IOrdersData>();
            ordersInfo.Order = new List<Order>();

            container.Set<IAppliancesDistribution>(new AppliancesDistribution(container.Get<IStockData>()));
            var appliancesDistribution = container.Get<IAppliancesDistribution>();
            appliancesDistribution.InitializeModel();

            container.Set<IOrderManager>(new OrderManager(container.Get<IOrdersData>()));
            container.Set<IUserManager>(new UserManager(container.Get<IUserData>()));
            container.Set<IOutputInputHandler>(new ConsoleInputOutput(container.Get<IAppliancesDistribution>(), container.Get<IOrderManager>(), container.Get<IUserManager>()));

            var presenter = container.Get<IOutputInputHandler>();
            presenter.RunMenu();
        }
    }
}