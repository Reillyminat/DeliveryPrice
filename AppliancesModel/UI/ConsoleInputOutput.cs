using AppliancesModel.Contracts;
using AppliancesModel.Models;
using AppliancesModel.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace AppliancesModel
{
    public class ConsoleInputOutput : IOutputInputHandler
    {
        private readonly IAppliancesDistribution distribution;

        private readonly IOrderManager orderManager;

        private readonly IUserManager userManager;
        
        private readonly ILogger logger;
        private readonly CurrencyConverter currencyConverter;

        public ConsoleInputOutput(
            IAppliancesDistribution appliancesService, 
            IOrderManager order, 
            IUserManager user, 
            ILogger loggerProcessing, 
            CurrencyConverter converter)
        {
                distribution = appliancesService ?? throw new ArgumentNullException(nameof(appliancesService));
                orderManager = order ?? throw new ArgumentNullException(nameof(order));
                userManager = user ?? throw new ArgumentNullException(nameof(user));
                logger = loggerProcessing ?? throw new ArgumentNullException(nameof(loggerProcessing));
                currencyConverter = converter;
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
            var stock = distribution.GetStock(out stockSummary);
            Console.WriteLine("In stock:");
            foreach (var item in stock)
            {
                Console.WriteLine("{0}: {1} ", item.Name, item.Amount);
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
                    var orderAmount = InputValidator.CheckIntInput("", 1, order.Amount);
                    orderManager.CreateShoppingBasket(person);
                    orderManager.AddItemToBasket(order, distribution.RefreshStock(order, orderAmount));
                    ShowBasket(orderManager.CurrentOrder);
                    logger.AddLog(person.Name + " added to basket " + order.Type + ": " + order.Name);
                }
                else
                {
                    Console.WriteLine("Such goods not existance");
                }

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
            foreach (var goods in order.Basket)
            {
                Console.WriteLine("{0}, {1} x {2}", goods.Name, goods.Amount, goods.Price);
            }
            Console.WriteLine("\nTotal sum UAH: {0}, USD: {1}, EUR: {2}", order.Price, Math.Round(currencyConverter.ConvertToUSD(order.Price),2), Math.Round(currencyConverter.ConvertToEUR(order.Price),2));
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
            } while (!OrderValidator.IsTelephoneNumberValid(telephone));

            do
            {
                Console.WriteLine("Enter your address in format: ул. <Название>, д. <Номер>, кв. <Номер>\n");
                address = Console.ReadLine();
            } while (!OrderValidator.IsAddressValid(address));
        }

        private void SelectApplianceToAdd()
        {
            int inputType, inputCount;
            Console.WriteLine("Select appliance to add:\n" +
                "1. Washer.\n" +
                "2. Refrigerator.\n" +
                "3. Kitchen stove.");

            while (!int.TryParse(Console.ReadLine(), out inputType) && inputType > 0 && inputType < 4)
            {
                Console.WriteLine("Input number 1-3!");
            }

            Console.WriteLine("Input the number of such goods (different models).");

            while (!int.TryParse(Console.ReadLine(), out inputCount) && inputCount > 0 && inputCount < 100)
            {
                Console.WriteLine("Input the number 1-100!");
            }

            SetApplianceProperties(distribution.AddGoods(inputType, inputCount));
            distribution.AddGoods(inputType, inputCount);
            logger.AddLog(inputCount + " " + (AppliancesStock)inputType + " added to stock");
        }

        private void SetApplianceProperties(IEnumerable<Appliance> addedGoods)
        {
            foreach (var good in addedGoods)
            {
                Console.WriteLine("Input name:");
                good.Name = Console.ReadLine();

                good.Guarantee = InputValidator.CheckIntInput("Input guarantee:", 0, 60);

                Console.WriteLine("Input height, width, length separating each with enter:");
                good.Dimensions = new Dimensions(InputValidator.CheckIntInput("", 10, 300), InputValidator.CheckIntInput("", 10, 300),
                    InputValidator.CheckIntInput("", 10, 300));

                good.Amount = InputValidator.CheckIntInput("Input amount:", 0, 1000);
                good.Price = InputValidator.CheckIntInput("Input price:", 0, 10000);

                Console.WriteLine("Input producing country:");
                good.ProducingCountry = Console.ReadLine();

                switch (good.Type)
                {
                    case AppliancesStock.Washer:
                        SetWasherProperties((Washer)good);
                        break;
                    case AppliancesStock.Refrigerator:
                        SetRefrigeratorProperties((Refrigerator)good);
                        break;
                    case AppliancesStock.KitchenStove:
                        SetKitchenStoveProperties((KitchenStove)good);
                        break;
                }         
            }
        }

        private void SetWasherProperties(Washer newWasher)
        {
            newWasher.WaterConsuming = InputValidator.CheckIntInput("Input water consuming value:", 20, 60);
            newWasher.MaximumLoad = InputValidator.CheckIntInput("Input maximum load value:", 3, 10);
        }

        private void SetRefrigeratorProperties(Refrigerator newRefrigerator)
        {
            newRefrigerator.TotalVolume = InputValidator.CheckIntInput("Input total volume value:", 100, 500);
            newRefrigerator.ContainsFreezer = InputValidator.CheckBoolInput("Input is it contains freezer (true/false):");
        }

        private void SetKitchenStoveProperties(KitchenStove newKitchenStove)
        {
            newKitchenStove.CombinedGasElectric = InputValidator.CheckBoolInput("Input is it combines gas and electric (true/false):");
            newKitchenStove.ContainsOven = InputValidator.CheckBoolInput("Input is it contains oven (true/false):");
        }
            
    }
}