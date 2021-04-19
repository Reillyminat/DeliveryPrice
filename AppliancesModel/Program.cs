using System;
using System.Collections.Generic;

namespace AppliancesModel
{
    public class Program
    {  
        static void Main(string[] args)
        {
            var startup = new AppliancesDistribution();
            var owner = new User(0, true, new DateTime(1990, 04, 15), "Alex");
            startup.AddGoods(owner);
            startup.ShowStock();

            Console.WriteLine("\nInput name of product you want to buy:");
            var productName = Console.ReadLine();
            var orderPrice = startup.MakeAnOrder(productName, owner);

            if (orderPrice != 0)
                Console.WriteLine("To pay {0}.", orderPrice);
            else
                Console.WriteLine("Product out of stock.");

            startup.ShowStock();
        }
    }
}

