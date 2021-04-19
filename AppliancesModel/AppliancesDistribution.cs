using System;
using System.Collections.Generic;

namespace AppliancesModel
{
    public class AppliancesDistribution
    {
        List<Appliances> complex;
        int id;
        DateTime blackFriday = new DateTime(2015, 11, 26);
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

        public decimal MakeAnOrder(string name, User person)
        {
            var order = complex.Find(i => i.Name == name);
            if (order == null)
                return 0;
            var percentOfTotalPrice = 1m;

            complex.Remove(order);
            if (DateTime.Today.Day == blackFriday.Day && DateTime.Today.Month == blackFriday.Month)
                percentOfTotalPrice -= 0.15m;
            if (DateTime.Today.Day == person.birthDate.Day && DateTime.Today.Month == person.birthDate.Month)
                percentOfTotalPrice -= 0.1m;
            return order.Price * percentOfTotalPrice;
        }

        public bool AddGoods(User person)
        {
            var id = 0;
            if (person.administratorRights == true)
            {
                int inputType, inputCount;

                dataHandler.SelectApplianceToAdd(out inputType, out inputCount, person.name);
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
                dataHandler.ShowStockRefresh();
                return true;
            }
            else
            {
                dataHandler.ShowRightsError();
                return false;
            }
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
