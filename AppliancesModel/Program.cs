using System;
using System.Collections.Generic;

namespace AppliancesModel
{
    public class Program
    {  
        static void Main(string[] args)
        {
            var startup = new AppliancesDistribution();
            startup.AddGoods();
            startup.ShowStock();

            Console.WriteLine("\nInput name of product you want to buy:");
            var productName = Console.ReadLine();
            var orderPrice = startup.MakeAnOrder(productName);

            if (orderPrice != 0)
                Console.WriteLine("To pay {0}.", orderPrice);
            else
                Console.WriteLine("Product out of stock.");

            startup.ShowStock();
        }
    }
}

