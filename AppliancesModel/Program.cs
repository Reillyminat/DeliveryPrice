﻿using AppliancesModel.Contracts;
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

            container.Set<IUserData>(new UsersData(new List<User>()));
            var usersInfo = container.Get<IUserData>();
            usersInfo.Users = new List<User>();

            container.Set<IOrdersData>(new OrdersData(new List<Order>()));
            var ordersInfo = container.Get<IOrdersData>();
            ordersInfo.Order = new List<Order>();

            container.Set<IAppliancesDistribution>(new AppliancesDistribution(container.Get<IAppliances>()));
            var appliancesDistribution = container.Get<IAppliancesDistribution>();

            container.Set<ILogger>(new Logger());
            var logger = container.Get<ILogger>();

            container.Set<IOrderManager>(new OrderManager(container.Get<IOrdersData>()));
            container.Set<IUserManager>(new UserManager(container.Get<IUserData>()));
            container.Set<IOutputInputHandler>(new ConsoleInputOutput(container.Get<IAppliancesDistribution>(), container.Get<IOrderManager>(), container.Get<IUserManager>(), container.Get<ILogger>()));

            var presenter = container.Get<IOutputInputHandler>();
            presenter.RunMenu();
        }
    }
}