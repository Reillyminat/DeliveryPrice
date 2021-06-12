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

            if (stockData == null)
                stockInfo.InitializeModel();

            var userData = serializator.GetDeserializedDataOrDefault<UsersData>("UsersData.json");
            container.Set<IUsersData>(userData == null ? new UsersData(new List<User>()) : userData);
            var usersInfo = container.Get<IUsersData>();

            var ordersData = serializator.GetDeserializedDataOrDefault<OrdersData>("OrdersData.json");
            container.Set<IOrdersData>(ordersData == null ? new OrdersData(new List<Order>()) : ordersData);
            var ordersInfo = container.Get<IOrdersData>();

            var currencyConverter = new CurrencyConverter();
            container.Set<IConverterService>(new ConverterService(currencyConverter));
            var converter = container.Get<IConverterService>();

            container.Set<IAppliancesDistribution>(new AppliancesDistribution(container.Get<IAppliances>(), container.Get<IDataSerialization>(), container.Get<IConverterService>()));
            var appliancesDistribution = container.Get<IAppliancesDistribution>();

            container.Set<ILogger>(new Logger());
            var logger = container.Get<ILogger>();

            container.Set<IOrderManager>(new OrderManager(container.Get<IOrdersData>(), container.Get<IDataSerialization>()));
            container.Set<IUserManager>(new UserManager(container.Get<IUsersData>(), container.Get<IDataSerialization>()));
            container.Set<IOutputInputHandler>(new ConsoleInputOutput(container.Get<IAppliancesDistribution>(), container.Get<IOrderManager>(), container.Get<IUserManager>(), container.Get<ILogger>(), currencyConverter));

            var presenter = container.Get<IOutputInputHandler>();
            presenter.RunMenu();
        }
    }
}