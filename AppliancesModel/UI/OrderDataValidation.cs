using System;

namespace AppliancesModel.UI
{
    public static class OrderDataValidation
    {
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
