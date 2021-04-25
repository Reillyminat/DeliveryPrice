using System;

namespace AppliancesModel
{
    public class ConsoleInputOutput : IOutputInputHandler
    {
        public void RunMenu(AppliancesDistribution distribution)
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
                        CheckAndBuy(distribution);
                        break;
                    case '2':
                        distribution.AddGoods();
                        break;
                    case '3':
                        distribution.ShowStock();
                        break;
                    case '4':
                        checkout = false;
                        break;
                    default:
                        Console.WriteLine("Error. Press key 1-3.");
                        break;
                }
            }
        }
        public void SelectApplianceToAdd(out int inputType, out int inputCount)
        {
            Console.WriteLine("Select appliance to add:\n" +
                "1. Washer.\n" +
                "2. Refrigerator.\n" +
                "3. Kitchen stove.");
            while (!int.TryParse(Console.ReadLine(), out inputType) && inputType > 0 && inputType < 4)
                Console.WriteLine("Input number 1-3!");

            Console.WriteLine("Input the number of such goods (different models).");
            while (!int.TryParse(Console.ReadLine(), out inputCount) && inputCount > 0 && inputCount < 100)
                Console.WriteLine("Input the number 1-100!");
        }

        public void SetApplianceProperties(out string name, out int guarantee, out Dimensions dimensions, out decimal price, out int amount, out string producingCountry)
        {
            Console.WriteLine("Input name:");
            name = Console.ReadLine();

            guarantee = CheckIntInput("Input guarantee:", 0, 60);

            Console.WriteLine("Input height, width, length separating each with enter:");
            dimensions = new Dimensions(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));

            amount = CheckIntInput("Input amount:", 0, 1000);
            price = CheckIntInput("Input price:", 0, 10000);

            Console.WriteLine("Input producing country:");
            producingCountry = Console.ReadLine();
        }

        public void SetWasherProperties(out int waterConsuming, out int maximumLoad)
        {
            waterConsuming = CheckIntInput("Input water consuming value:", 20, 60);
            maximumLoad = CheckIntInput("Input maximum load value:", 3, 10);
        }

        public void SetRefrigeratorProperties(out int totalVolume, out bool containsFreezer)
        {
            totalVolume = CheckIntInput("Input total volume value:", 100, 500);
            containsFreezer = CheckBoolInput("Input is it contains freezer (true/false):");
        }

        public void SetKitchenStoveProperties(out bool combinedGasElectric, out bool containsOven)
        {
            combinedGasElectric = CheckBoolInput("Input is it combines gas and electric (true/false):");
            containsOven = CheckBoolInput("Input is it contains oven (true/false):");
        }

        public void ShowStockNumbers(int washerCount, int refrigeratorCount, int kitchenStoveCount)
        {
            Console.WriteLine("Total {0} washers, {1} refrigerators, {2} kitchen stoves.", washerCount, refrigeratorCount, kitchenStoveCount);
        }

        public string GetApplianceName()
        {
            Console.WriteLine("Input appliance name you want to buy:");
            return Console.ReadLine();
        }

        private void CheckAndBuy(AppliancesDistribution distribution)
        {
            var order = distribution.MakeAnOrder();
            if (order == null)
                Console.WriteLine("Out of stock.");
            else
                Console.WriteLine("To pay {0}", order.Price);
        }
        private int CheckIntInput(string article, int lowerBound, int upperBound)
        {
            int input;

            Console.WriteLine(article);
            while (!int.TryParse(Console.ReadLine(), out input) && input > lowerBound && input < upperBound)
                Console.WriteLine("Input number {0} to {1}!", lowerBound, upperBound);
            return input;
        }

        private bool CheckBoolInput(string article)
        {
            bool input;

            Console.WriteLine(article);
            while (!bool.TryParse(Console.ReadLine(), out input))
                Console.WriteLine("Input true/false!");
            return input;
        }

    }
}
