using AppliancesModel.Contracts;
using AppliancesModel.Models;
using System;
using System.Collections.Generic;

namespace AppliancesModel
{
    public class AppliancesDistribution : IAppliancesDistribution
    {
        private readonly IStockData stockContext;

        public AppliancesDistribution(IStockData stock)
        {
            try
            {
                stockContext = stock;
            }
            catch (NullReferenceException ex)
            {
                throw new Exception("Stock context is null", ex);
            }
        }

        public void InitializeModel()
        {
            if (stockContext.Stock.Count == 0)
            {
                for (int i = 1; i < 4; i++)
                    stockContext.Stock.Add(new Washer(stockContext.Id++, "Washer" + i, 12, new Dimensions(60 + i, 40 + i, 40 + i), 100 * i, i, "Germany", 30 + i, 5 + i));
                for (int i = 1; i < 4; i++)
                    stockContext.Stock.Add(new Refrigerator(stockContext.Id++, "Refrigerator" + i, 12, new Dimensions(80 + i, 60 + i, 40 + i), 100 * i, i, "Italy", 300 + i, true));
                for (int i = 1; i < 4; i++)
                    stockContext.Stock.Add(new KitchenStove(stockContext.Id++, "KitchenStove" + i, 12, new Dimensions(40 + i, 60 + i, 40 + i), 100 * i, i, "France", true, true));
            }
        }

        public int RefreshStock(Appliances goods, int count)
        {
            if (goods.Amount == count)
            {
                stockContext.Stock.Remove(goods);
                return goods.Amount;
            }
            else
            {
                goods.Amount -= count;
                return count;
            }
        }

        public Appliances CheckGoodsExistance(string applianceName)
        {
            foreach (Appliances goods in stockContext.Stock)
            {
                if (goods.Name == applianceName)
                    return goods;
            }
            return null;
        }

        public void AddGoods(int inputType, int inputCount)
        {
            for (int i = 0; i < inputCount; i++)
            {
                switch (inputType)
                {
                    case 1:
                        stockContext.Stock.Add(new Washer(stockContext.Id++));
                        break;
                    case 2:
                        stockContext.Stock.Add(new Refrigerator(stockContext.Id++));
                        break;
                    case 3:
                        stockContext.Stock.Add(new KitchenStove(stockContext.Id++));
                        break;
                }
            }
        }

        public IEnumerable<Appliances> ShowStock(out List<int> stockSummary)
        {
            var stockNumbersDetail = stockContext.Stock;
            stockSummary = new List<int>() { 0, 0, 0 };
            foreach (Appliances item in stockContext.Stock)
            {
                switch (item.Type)
                {
                    case AppliancesStock.Washer:
                        stockSummary[0]++;
                        break;
                    case AppliancesStock.Refrigerator:
                        stockSummary[1]++;
                        break;
                    case AppliancesStock.KitchenStove:
                        stockSummary[2]++;
                        break;
                }
            }
            return stockNumbersDetail;
        }
    }
}
