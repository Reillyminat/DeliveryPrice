using System;

namespace AppliancesModel
{
    public class AppliancesDistribution
    {
        int id;
        IOutputInputHandler dataHandler;
        private readonly IStockData _stockContext;
        public AppliancesDistribution(IStockData stock)
        {
            dataHandler = new ConsoleInputOutput();
            id = 0;
            _stockContext = stock;
        }
        public void InitializeModel()
        {
            try
            {
                for (int i = 1; i < 4; i++)
                    _stockContext.Stock.Add(new Washer(id++, "Washer" + i, 12, new Dimensions(60 + i, 40 + i, 40 + i), 100 * i, i, "Germany", 30 + i, 5 + i));
                for (int i = 1; i < 4; i++)
                    _stockContext.Stock.Add(new Refrigerator(id++, "Refrigerator" + i, 12, new Dimensions(80 + i, 60 + i, 40 + i), 100 * i, i, "Italy", 300 + i, true));
                for (int i = 1; i < 4; i++)
                    _stockContext.Stock.Add(new KitchenStove(id++, "KitchenStove" + i, 12, new Dimensions(40 + i, 60 + i, 40 + i), 100 * i, i, "France", true, true));

            }
            catch (NullReferenceException)
            {

            }
        }
        public Appliances MakeAnOrder()
        {
            var applianceName = dataHandler.GetApplianceName();
            foreach (Appliances goods in _stockContext.Stock)
            {
                if (goods.Name == applianceName)
                    if (goods.Amount == 1)
                    {
                        _stockContext.Stock.Remove(goods);
                        return goods;
                    }
                    else
                    {
                        goods.Amount--;
                        return goods;
                    }
            }
            return null;
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
                        _stockContext.Stock.Add(new Washer(id++));
                        break;
                    case 2:
                        _stockContext.Stock.Add(new Refrigerator(id++));
                        break;
                    case 3:
                        _stockContext.Stock.Add(new KitchenStove(id++));
                        break;
                }
            }

            return true;
        }

        public void ShowStock()
        {
            int washerCount = 0, refrigeratorCount = 0, kitchenStoveCount = 0;

            foreach (Appliances item in _stockContext.Stock)
            {
                Console.WriteLine("{0}, stock: {1}", item.Name, item.Amount);
                switch (item.Type)
                {
                    case AppliancesStock.Washer:
                        washerCount += item.Amount;
                        break;
                    case AppliancesStock.Refrigerator:
                        refrigeratorCount += item.Amount;
                        break;
                    case AppliancesStock.KitchenStove:
                        kitchenStoveCount += item.Amount;
                        break;
                }
            }
            dataHandler.ShowStockNumbers(washerCount, refrigeratorCount, kitchenStoveCount);
        }
    }
}
