using AppliancesModel.Contracts;
using AppliancesModel.Models;
using AppliancesModel.UI;
using System;
using System.Collections.Generic;

namespace AppliancesModel
{
    public class ConsoleInputOutput : IOutputInputHandler
    {
        private readonly IAppliancesDistribution distribution;
        private readonly IOrderManager orderManager;
        private readonly IUserManager userManager;
        private readonly ILogger logger;

        public ConsoleInputOutput(IAppliancesDistribution service, IOrderManager order, IUserManager user, ILogger loggerProcessing)
        {
            try
            {
                distribution = service;
                orderManager = order;
                userManager = user;
                logger = loggerProcessing;
            }
            catch (NullReferenceException ex)
            {
                throw new Exception("Console IO got null reference", ex);
            }
        }

        public void RunMenu()
        {
            var checkout = true;
            while (checkout)
            {
                Console.WriteLine("Select action:\n" +
                    "1. Make an order.\n" +
                    "2. Add an appliance.\n" +
                    "3. Show stock.\n" +
                    "4. Exit.\n");
                var input = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (input)
                {
                    case '1':
                        CheckAndBuy();
                        break;
                    case '2':
                        SelectApplianceToAdd();
                        break;
                    case '3':
                        ShowStockNumbers();
                        break;
                    case '4':
                        checkout = false;
                        orderManager.SaveOrdersState();
                        distribution.SaveStockState();
                        userManager.SaveUsersState();
                        logger.Dispose();
                        break;
                    default:
                        Console.WriteLine("Error. Press key 1-4.");
                        break;
                }
            }
        }

        private void ShowStockNumbers()
        {
            List<int> stockSummary;
            var stock = distribution.ShowStock(out stockSummary);
            Console.WriteLine("In stock:");
            foreach (Appliance item in stock)
            {
                Console.WriteLine("{0}: {1} ",item.Name,item.Amount);
            }
            Console.WriteLine("Total {0} washers, {1} refrigerators, {2} kitchen stoves.", stockSummary[0], stockSummary[1], stockSummary[2]);
        }

        private void CheckAndBuy()
        {
            char input;
            User person = CheckUser();
            do
            {
                Console.WriteLine("Input appliance name you want to buy:");
                var order = distribution.CheckGoodsExistance(Console.ReadLine());

                if (order != null)
                {
                    Console.WriteLine("Input amount of goods you want to buy:");
                    var orderAmount = PropertiesManager.CheckIntInput("", 1, order.Amount);
                    orderManager.CreateShoppingBasket(person);
                    orderManager.AddItemToBasket(order, distribution.RefreshStock(order, orderAmount));
                    ShowBasket(orderManager.CurrentOrder);
                    logger.AddLog(person.Name + " added to basket " + order.Type + ": " + order.Name);
                }
                else Console.WriteLine("Such goods not existance");

                Console.WriteLine("Do you want more goods? Type 'y' or 'n'.");
                while (true)
                {
                    input = Console.ReadKey().KeyChar;
                    if (input != 'y' || input != 'n')
                        break;
                }
            } while (input != 'n');
        }

        private void ShowBasket(Order order)
        {
            foreach (Appliance goods in order.basket)
            {
                Console.WriteLine("{0}, {1} x {2}", goods.Name, goods.Amount, goods.Price);
            }
            Console.WriteLine("\nTotal sum {0}", order.Price);
        }

        private User CheckUser()
        {
            while (true)
            {
                Console.WriteLine("Select action:\n" +
                    "1. Log in.\n" +
                    "2. Register.\n" +
                    "3. Continue as guest.\n");
                var input = Console.ReadKey().KeyChar;
                Console.WriteLine();
                string name, telephone, address;
                switch (input)
                {
                    case '1':
                        Console.WriteLine("Enter your name:\n");
                        name = Console.ReadLine();
                        var customer = userManager.GetUser(name);
                        if (customer == null)
                        {
                            Console.WriteLine("Such user not existance.");
                            break;
                        }
                        return customer;
                    case '2':
                        InputOrderData(out name, out telephone, out address);
                        logger.AddLog(name + " registered");
                        return userManager.AddUser(name, address, telephone);
                    case '3':
                        InputOrderData(out name, out telephone, out address);
                        return userManager.SetGuestUser(name, address, telephone);
                    default:
                        Console.WriteLine("Error. Press key 1-3.");
                        break;
                }
            }
        }

        private void InputOrderData(out string name, out string telephone, out string address)
        {
            Console.WriteLine("Enter your name:\n");
            name = Console.ReadLine();

            do
            {
                Console.WriteLine("Enter your telephone number:\n");
                telephone = Console.ReadLine();
            } while (!OrderDataValidation.IsTelephoneNumberValid(telephone));

            do
            {
                Console.WriteLine("Enter your address in format: ул. <Название>, д. <Номер>, кв. <Номер>\n");
                address = Console.ReadLine();
            } while (!OrderDataValidation.IsAddressValid(address));
        }

        private void SelectApplianceToAdd()
        {
            int inputType, inputCount;
            Console.WriteLine("Select appliance to add:\n" +
                "1. Washer.\n" +
                "2. Refrigerator.\n" +
                "3. Kitchen stove.");
            while (!int.TryParse(Console.ReadLine(), out inputType) && inputType > 0 && inputType < 4)
                Console.WriteLine("Input number 1-3!");

            Console.WriteLine("Input the number of such goods (different models).");
            while (!int.TryParse(Console.ReadLine(), out inputCount) && inputCount > 0 && inputCount < 100)
                Console.WriteLine("Input the number 1-100!");
            distribution.AddGoods(inputType, inputCount);
            logger.AddLog(inputCount + " " + (AppliancesStock)inputType + " added to stock");
        }
    }
}
