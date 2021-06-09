using AppliancesModel.Contracts;
using AppliancesModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppliancesModel
{
    public class AppliancesDistribution : IAppliancesDistribution
    {
        private readonly IAppliances stockContext;

        private readonly IDataSerialization dataSerializer;

        private readonly ICacheable cache;

        private readonly IConverterService converterService;

        public AppliancesDistribution(IAppliances stock, IDataSerialization serializer, IConverterService converterProvider)
        {
            try
            {
                stockContext = stock;
                dataSerializer = serializer;
                cache = new Cache(stockContext);
                converterService = converterProvider;
                converterService.GetExchengesRateAsync(new System.Threading.CancellationToken());
            }
            catch (NullReferenceException ex)
            {
                throw new Exception("Stock context is null", ex);
            }
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
            return stockContext.Stock.FirstOrDefault(x => x.Name == applianceName);
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

        public IEnumerable<Appliance> ShowStock(out List<int> stockSummary)
        {
            var stockNumbersDetail = cache.GetObject< IAppliances>(() => Console.WriteLine("Appliance distributor requested data.")).Stock;
            stockSummary = new List<int>() { 0, 0, 0 };

            foreach (var item in stockNumbersDetail)
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

        public void SaveStockState()
        {
            dataSerializer.SerializeToFile(stockContext);
        }
    }
}
