using System;
using System.Collections.Generic;

namespace AppliancesModel
{
    class Program
    {
        public class User
        {
            public string name { get; set; }
            int id;
            public bool administratorRights;
            public DateTime birthDate;
            public User(int id, bool administratorRoot, DateTime birthDate, string name)
            {
                this.id = id;
                this.name = name;
                this.administratorRights = administratorRoot;
                this.birthDate = birthDate;
            }
        }
        public class Dimensions
        {
            float height;
            float width;
            float length;

            public Dimensions(float height, float width, float length)
            {
                this.height = height;
                this.width = width;
                this.length = length;
            }
        }
        public class AppliancesDistribution
        {
            List<Appliances> complex;
            int id;
            DateTime blackFriday = new DateTime(2015, 11, 26);
            //initial purchase of goods
            public AppliancesDistribution()
            {
                id = 0;
                complex = new List<Appliances>();
                for (int i = 1; i < 4; i++)
                    complex.Add(new Washer(id++, "Washer" + i, 12, new Dimensions(60 + i, 40 + i, 40 + i), 100 * i, "Germany", 30 + i, 5 + i));
                for (int i = 1; i < 4; i++)
                    complex.Add(new Refrigerator(id++, "Refrigerator" + i, 12, new Dimensions(80 + i, 60 + i, 40 + i), 100 * i, "Italy", 300 + i, true));
                for (int i = 1; i < 4; i++)
                    complex.Add(new KitchenStove(id++, "KitchenStove" + i, 12, new Dimensions(40 + i, 60 + i, 40 + i), 100 * i, "France", true, true));
            }

            public decimal MakeAnOrder(string name, User person)
            {
                var order = complex.Find(i => i.name == name);
                if (order == null)
                    return 0;
                var percentOfTotalPrice = 1m;

                complex.Remove(order);
                if (DateTime.Today.Day == blackFriday.Day && DateTime.Today.Month == blackFriday.Month)
                    percentOfTotalPrice -= 0.15m;
                if (DateTime.Today.Day == person.birthDate.Day && DateTime.Today.Month == person.birthDate.Month)
                    percentOfTotalPrice -= 0.1m;
                return order.price * percentOfTotalPrice;
            }

            public bool AddGoods(User person)
            {
                int id = 0;
                if (person.administratorRights == true)
                {
                    Console.WriteLine("Welcome {0}!", person.name);
                    Console.WriteLine("Select appliance to add:\n" +
                        "1. Washer.\n" +
                        "2. Refrigerator.\n" +
                        "3. Kitchen stove.");
                    int inputType, inputCount;
                    while (!int.TryParse(Console.ReadLine(), out inputType) && inputType > 0 && inputType < 4)
                        Console.WriteLine("Input number 1-3!");

                    Console.WriteLine("Input the number number of such goods.");
                    while (!int.TryParse(Console.ReadLine(), out inputCount) && inputCount > 0 && inputCount < 100)
                        Console.WriteLine("Input the number 1-100!");
                    for (int i = 0; i < inputCount; i++)
                    {
                        Console.WriteLine("#{0}", i + 1);
                        switch (inputType)
                        {
                            case 1:
                                complex.Add(new Washer(id++));
                                ((Washer)complex[complex.Count - 1]).SetProperties();
                                break;
                            case 2:
                                complex.Add(new Refrigerator(id++));
                                ((Refrigerator)complex[complex.Count - 1]).SetProperties();
                                break;
                            case 3:
                                complex.Add(new KitchenStove(id++));
                                ((KitchenStove)complex[complex.Count - 1]).SetProperties();
                                break;
                        }
                    }
                    Console.WriteLine("Stock added.");
                    return true;
                }
                else
                {
                    Console.WriteLine("Insufficient rights.");
                    return false;
                }
            }

            public void ShowStock()
            {
                int washerCount = 0, refrigeratorCount = 0, kitchenStoveCount = 0;
                Console.WriteLine("\nGoods in stock:");
                foreach (Appliances item in complex)
                {
                    Console.WriteLine(item.name);
                    switch (item.type)
                    {
                        case AppliancesStock.Washer:
                            washerCount++;
                            break;
                        case AppliancesStock.Refrigerator:
                            refrigeratorCount++;
                            break;
                        case AppliancesStock.KitchenStove:
                            kitchenStoveCount++;
                            break;
                    }
                }
                Console.WriteLine("Total {0} washers, {1} refrigerators, {2} kitchen stoves.", washerCount, refrigeratorCount, kitchenStoveCount);
            }
        }

        public abstract class Appliances
        {
            public AppliancesStock type { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public int guarantee { get; set; }
            public Dimensions dimensions { get; set; }
            public decimal price { get; set; }
            public string producingCountry { get; set; }
            public Appliances(int id)
            {
                this.id = id;

                Console.WriteLine("Input name:");
                this.name = Console.ReadLine();

                this.guarantee = CheckIntInput("Input guarantee:", 0, 60);

                Console.WriteLine("Input height, width, length separating each with enter:");
                this.dimensions = new Dimensions(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));

                this.price = CheckIntInput("Input price:", 0, 10000);

                Console.WriteLine("Input producing country:");
                this.producingCountry = Console.ReadLine();
            }

            public Appliances(int id, string name, int guarantee, Dimensions dimensions, decimal price, string producingCountry)
            {
                this.id = id;
                this.name = name;
                this.guarantee = guarantee;
                this.dimensions = dimensions;
                this.price = price;
                this.producingCountry = producingCountry;
            }

            public abstract void SetProperties();
        }

        public class Washer : Appliances
        {
            int waterConsuming;
            int maximumLoad;
            public Washer(int id) : base(id)
            {
                type = AppliancesStock.Washer;
            }

            public Washer(int id, string name, int guarantee, Dimensions dimensions, decimal price,
                string producingCountry, int waterConsuming, int maximumLoad)
                : base(id, name, guarantee, dimensions, price, producingCountry)
            {
                type = AppliancesStock.Washer;
                this.waterConsuming = waterConsuming;
                this.maximumLoad = maximumLoad;
            }

            public override void SetProperties()
            {
                this.waterConsuming = CheckIntInput("Input water consuming value:", 20, 60);
                this.maximumLoad = CheckIntInput("Input maximum load value:", 3, 10);
            }
        }

        public class Refrigerator : Appliances
        {
            int totalVolume;
            bool containsFreezer;
            public Refrigerator(int id) : base(id)
            {
                type = AppliancesStock.Refrigerator;
            }

            public Refrigerator(int id, string name, int guarantee, Dimensions dimensions, decimal price,
                string producingCountry, int totalVolume, bool containsFreezer)
                : base(id, name, guarantee, dimensions, price, producingCountry)
            {
                type = AppliancesStock.Refrigerator;
                this.totalVolume = totalVolume;
                this.containsFreezer = containsFreezer;
            }

            public override void SetProperties()
            {
                this.totalVolume = CheckIntInput("Input total volume value:", 100, 500);
                this.containsFreezer = CheckBoolInput("Input is it contains freezer (true/false):");
            }
        }
        public class KitchenStove : Appliances
        {
            bool combinedGasElectric;
            bool containsOven;
            public KitchenStove(int id) : base(id)
            {
                type = AppliancesStock.KitchenStove;
            }
            public KitchenStove(int id, string name, int guarantee, Dimensions dimensions, decimal price,
                string producingCountry, bool combinedGasElectric, bool containsOven)
                : base(id, name, guarantee, dimensions, price, producingCountry)
            {
                type = AppliancesStock.KitchenStove;
                this.combinedGasElectric = combinedGasElectric;
                this.containsOven = containsOven;
            }

            public override void SetProperties()
            {
                this.combinedGasElectric = CheckBoolInput("Input is it combines gas and electric (true/false):");
                this.containsOven = CheckBoolInput("Input is it contains oven (true/false):");
            }
        }

        public static int CheckIntInput(string article, int lowerBound, int upperBound)
        {
            int input;

            Console.WriteLine(article);
            while (!int.TryParse(Console.ReadLine(), out input) && input > lowerBound && input < upperBound)
                Console.WriteLine("Input number {0} to {1}!", lowerBound, upperBound);
            return input;
        }

        public enum AppliancesStock
        {
            Washer,
            Refrigerator,
            KitchenStove
        }
        public static bool CheckBoolInput(string article)
        {
            bool input;

            Console.WriteLine(article);
            while (!bool.TryParse(Console.ReadLine(), out input))
                Console.WriteLine("Input true/false!");
            return input;
        }

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

