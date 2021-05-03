using AppliancesModel.Contracts;
using AppliancesModel.Models;
using System;

namespace AppliancesModel
{
    public class AppliancesDistribution : IAppliancesDistribution
    {
        private int id;
        private readonly IStockData stockContext;
        public AppliancesDistribution(IStockData stock)
        {
            try
            {
                id = 0;
                stockContext = stock;
            }
            catch (NullReferenceException ex)
            {
                throw new Exception("Stock context is null", ex);
            }
        }

        public void InitializeModel()
        {
            for (int i = 1; i < 4; i++)
                stockContext.Stock.Add(new Washer(id++, "Washer" + i, 12, new Dimensions(60 + i, 40 + i, 40 + i), 100 * i, i, "Germany", 30 + i, 5 + i));
            for (int i = 1; i < 4; i++)
                stockContext.Stock.Add(new Refrigerator(id++, "Refrigerator" + i, 12, new Dimensions(80 + i, 60 + i, 40 + i), 100 * i, i, "Italy", 300 + i, true));
            for (int i = 1; i < 4; i++)
                stockContext.Stock.Add(new KitchenStove(id++, "KitchenStove" + i, 12, new Dimensions(40 + i, 60 + i, 40 + i), 100 * i, i, "France", true, true));
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
                        stockContext.Stock.Add(new Washer(id++));
                        break;
                    case 2:
                        stockContext.Stock.Add(new Refrigerator(id++));
                        break;
                    case 3:
                        stockContext.Stock.Add(new KitchenStove(id++));
                        break;
                }
            }
        }

        public IStockData ShowStock()
        {
            return stockContext;
        }
    }
}
