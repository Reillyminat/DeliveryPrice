using System;

namespace AppliancesModel
{
    public class Program
    {
        public static void OrderProcessing(Appliances order)
        {
            Console.WriteLine("To pay {0}", order.Price);
        }
        public static void SelectAction(AppliancesDistribution distribution)
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
                        OrderProcessing(distribution.MakeAnOrder());
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
        static void Main(string[] args)
        {
            var startup = new AppliancesDistribution();
            SelectAction(startup);
        }
    }
}

