using System;
using System.Collections.Generic;

namespace AppliancesModel
{
    public class AppliancesDistribution
    {
        List<Appliances> complex;
        int id;
        IOutputInputHandler dataHandler;
        // Initial purchase of goods.
        public AppliancesDistribution()
        {
            dataHandler = new ConsoleInputOutput();
            id = 0;
            complex = new List<Appliances>();
            for (int i = 1; i < 4; i++)
                complex.Add(new Washer(id++, "Washer" + i, 12, new Dimensions(60 + i, 40 + i, 40 + i), 100 * i, "Germany", 30 + i, 5 + i));
            for (int i = 1; i < 4; i++)
                complex.Add(new Refrigerator(id++, "Refrigerator" + i, 12, new Dimensions(80 + i, 60 + i, 40 + i), 100 * i, "Italy", 300 + i, true));
            for (int i = 1; i < 4; i++)
                complex.Add(new KitchenStove(id++, "KitchenStove" + i, 12, new Dimensions(40 + i, 60 + i, 40 + i), 100 * i, "France", true, true));
        }

        public Appliances MakeAnOrder()
        {
            var applianceName = dataHandler.GetApplianceName();
            var order = complex.Find(i => i.Name == applianceName);
            if (order == null)
                return null;
            complex.Remove(order);
            return order;
        }

        public bool AddGoods()
        {
            var id = 0;
            int inputType, inputCount;

            dataHandler.SelectApplianceToAdd(out inputType, out inputCount);
            for (int i = 0; i < inputCount; i++)
            {
                switch (inputType)
                {
                    case 1:
                        complex.Add(new Washer(id++));
                        break;
                    case 2:
                        complex.Add(new Refrigerator(id++));
                        break;
                    case 3:
                        complex.Add(new KitchenStove(id++));
                        break;
                }
            }
            return true;
        }

        public void ShowStock()
        {
            int washerCount = 0, refrigeratorCount = 0, kitchenStoveCount = 0;

            foreach (Appliances item in complex)
            {
                Console.WriteLine(item.Name);
                switch (item.Type)
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
            dataHandler.ShowStockNumbers(washerCount, refrigeratorCount, kitchenStoveCount);
        }
    }
}
