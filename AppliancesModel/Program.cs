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

            var stockData = serializator.GetDeserializedDataOrDefault<Appliances>("Appliances.json");
            container.Set<IAppliances>(stockData == null ? new Appliances(new List<Appliance>()) : stockData);
            var stockInfo = container.Get<IAppliances>();

            //if (stockData == null)
              //  stockInfo.InitializeModel();

            var userData = serializator.GetDeserializedDataOrDefault<UsersData>("UsersData.json");
            container.Set<IUsersData>(userData == null ? new UsersData(new List<User>()) : userData);

            var ordersData = serializator.GetDeserializedDataOrDefault<OrdersData>("OrdersData.json");
            container.Set<IOrdersData>(ordersData == null ? new OrdersData(new List<Order>()) : ordersData);

            container.Set<ICacheable>(new Cache(container.Get<IAppliances>()));

            container.Set<IAppliancesDistribution>(new AppliancesDistribution(container.Get<IAppliances>(), container.Get<IDataSerialization>(), container.Get<ICacheable>()));
            var appliancesDistribution = container.Get<IAppliancesDistribution>();

            container.Set<ILogger>(new Logger());
            var logger = container.Get<ILogger>();

            container.Set<ICacheable>(new Cache(container.Get<IUsersData>()));

            container.Set<IOrderManager>(new OrderManager(container.Get<IOrdersData>(), container.Get<IDataSerialization>(), container.Get<ICacheable>()));
            container.Set<ICacheable>(new Cache(container.Get<IOrdersData>()));
            container.Set<IUserManager>(new UserManager(container.Get<IUsersData>(), container.Get<IDataSerialization>(), container.Get<ICacheable>()));

            container.Set<IOutputInputHandler>(new ConsoleInputOutput(container.Get<IAppliancesDistribution>(), container.Get<IOrderManager>(), container.Get<IUserManager>(), container.Get<ILogger>()));

            var presenter = container.Get<IOutputInputHandler>();
            presenter.RunMenu();
        }
    }
}