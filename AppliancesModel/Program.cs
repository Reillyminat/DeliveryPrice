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

            container.Set<IDataSerialization>(new DataSerialization());
            var serializator = container.Get<IDataSerialization>();

            var stockData = serializator.DeserializeFromFileOrDefault<Appliances>("Appliances.json");
            container.Set<IAppliances>(stockData == null ? new Appliances(new List<Appliance>()) : stockData);
            var stockInfo = container.Get<IAppliances>();
            if (stockData == null)
                stockInfo.InitializeModel();

            var userData = serializator.DeserializeFromFileOrDefault<UsersData>("UsersData.json");
            container.Set<IUsersData>(userData == null ? new UsersData(new List<User>()) : userData);
            var usersInfo = container.Get<IUsersData>();

            var ordersData = serializator.DeserializeFromFileOrDefault<OrdersData>("OrdersData.json");
            container.Set<IOrdersData>(ordersData == null ? new OrdersData(new List<Order>()) : ordersData);
            var ordersInfo = container.Get<IOrdersData>();

            container.Set<IAppliancesDistribution>(new AppliancesDistribution(container.Get<IAppliances>(), container.Get<IDataSerialization>()));
            var appliancesDistribution = container.Get<IAppliancesDistribution>();

            container.Set<ILogger>(new Logger());
            var logger = container.Get<ILogger>();

            container.Set<IOrderManager>(new OrderManager(container.Get<IOrdersData>(), container.Get<IDataSerialization>()));
            container.Set<IUserManager>(new UserManager(container.Get<IUsersData>(), container.Get<IDataSerialization>()));
            container.Set<IOutputInputHandler>(new ConsoleInputOutput(container.Get<IAppliancesDistribution>(), container.Get<IOrderManager>(), container.Get<IUserManager>(), container.Get<ILogger>()));

            var presenter = container.Get<IOutputInputHandler>();
            presenter.RunMenu();
        }
    }
}