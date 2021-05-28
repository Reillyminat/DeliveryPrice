using AppliancesModel.Contracts;
using AppliancesModel.Models;
using System.Collections.Generic;
using System.Linq;

namespace AppliancesModel
{
    public class AppliancesDistribution : IAppliancesDistribution
    {
        private readonly IAppliances stockContext;

        public AppliancesDistribution(IAppliances stock)
        {
            stockContext = stock;
        }

        public int RefreshStock(Appliance goods, int count)
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

        public Appliance CheckGoodsExistance(string applianceName)
        {
            foreach (Appliance goods in stockContext.Stock)
            {
                if (goods.Name == applianceName)
                    return goods;
            }
            return null;
        }

        public IEnumerable<Appliance> AddGoods(int inputType, int inputCount)
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
            return stockContext.Stock.Where(s => s.Id > stockContext.Id - inputCount - 1);
        }

        public IEnumerable<Appliance> ShowStock(out List<int> stockSummary)
        {
            var stockNumbersDetail = stockContext.Stock;
            stockSummary = new List<int>() { 0, 0, 0 };
            foreach (Appliance item in stockContext.Stock)
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
