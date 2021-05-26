using AppliancesModel.Contracts;
using AppliancesModel.UI;
using System;
using System.Collections.Generic;

namespace AppliancesModel
{
    public class ConsoleInputOutput : IOutputInputHandler
    {
        private readonly IAppliancesDistribution distribution;

        public ConsoleInputOutput(IAppliancesDistribution service)
        {
            try
            {
                distribution = service;
            }
            catch (NullReferenceException ex)
            {
                throw new Exception("Distribution service is null.", ex);
            }
        }
        public void RunMenu(IAppliancesDistribution distribution)
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
            foreach (Appliances item in stock)
            {
                Console.WriteLine("{0}: {1} ", item.Name, item.Amount);
            }
            Console.WriteLine("Total {0} washers, {1} refrigerators, {2} kitchen stoves.", stockSummary[0], stockSummary[1], stockSummary[2]);
        }

        private void CheckAndBuy()
        {
            Console.WriteLine("Input appliance name you want to buy:");
            var order = distribution.CheckGoodsExistance(Console.ReadLine());

            if (order != null)
            {
                Console.WriteLine("Input amount of goods you want to buy:");
                var orderAmount = PropertiesManager.CheckIntInput("", 1, order.Amount);
                Console.WriteLine("To pay {0}", distribution.RefreshStock(order, orderAmount)*order.Price);
            }
            else Console.WriteLine("Such goods not existance");
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
        }
    }
}
