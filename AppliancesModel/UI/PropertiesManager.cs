using System;

namespace AppliancesModel.UI
{
    public static class PropertiesManager
    {
        public static void SetApplianceProperties(out string name, out int guarantee, out Dimensions dimensions, out decimal price, out int amount, out string producingCountry)
        {
            Console.WriteLine("Input appliance name:");
            name = Console.ReadLine();

            guarantee = CheckIntInput("Input guarantee:", 0, 60);

            Console.WriteLine("Input height, width, length separating each with enter:");
            dimensions = new Dimensions(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));

            amount = CheckIntInput("Input amount:", 0, 1000);
            price = CheckIntInput("Input price:", 0, 10000);

            Console.WriteLine("Input producing country:");
            producingCountry = Console.ReadLine();
        }

        public static void SetWasherProperties(out int waterConsuming, out int maximumLoad)
        {
            waterConsuming = CheckIntInput("Input water consuming value:", 20, 60);
            maximumLoad = CheckIntInput("Input maximum load value:", 3, 10);
        }

        public static void SetRefrigeratorProperties(out int totalVolume, out bool containsFreezer)
        {
            totalVolume = CheckIntInput("Input total volume value:", 100, 500);
            containsFreezer = CheckBoolInput("Input is it contains freezer (true/false):");
        }

        public static void SetKitchenStoveProperties(out bool combinedGasElectric, out bool containsOven)
        {
            combinedGasElectric = CheckBoolInput("Input is it combines gas and electric (true/false):");
            containsOven = CheckBoolInput("Input is it contains oven (true/false):");
        }
        public static int CheckIntInput(string article, int lowerBound, int upperBound)
        {
            int input;

            Console.WriteLine(article);
            do
            {
            Console.WriteLine("Input number {0} to {1}.", lowerBound, upperBound);
                int.TryParse(Console.ReadLine(), out input);
            }
            while (input < lowerBound || input > upperBound);

            return input;
        }

        public static bool CheckBoolInput(string article)
        {
            bool input;

            Console.WriteLine(article);
            while (!bool.TryParse(Console.ReadLine(), out input))
                Console.WriteLine("Input true/false!");
            return input;
        }
    }
}
