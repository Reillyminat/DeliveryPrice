using AppliancesModel.Contracts;
using DeliveryServiceModel;
using EFCore5.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace AppliancesModel
{
    public class AppliancesDistribution : IAppliancesDistribution
    {
        private readonly IUnitOfWork unitOfWorkContext;

        private readonly IAppliances stockContext;

        private readonly IDataSerialization dataSerializer;

        private readonly ICacheable cache;

        public AppliancesDistribution(IAppliances stockContext, IUnitOfWork unitOfWork, IDataSerialization serializer, ICacheable cacheProvider, IConverterService converterProvider, CancellationToken cancellationToken)
        {
            unitOfWorkContext = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            dataSerializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
            cache = cacheProvider ?? throw new ArgumentNullException(nameof(cacheProvider));
            converterProvider.GetExchengesRateAsync(cancellationToken);
        }

        public int RefreshStock(Product goods, int count)
        {
            if (goods.Amount == count)
            {
                unitOfWorkContext.Products.Delete(goods.Id);
                return goods.Amount;
            }
            else
            {
                goods.Amount -= count;
                return count;
            }
        }

        public Product CheckGoodsExistance(string applianceName)
        {
            return unitOfWorkContext.Products.GetAll().FirstOrDefault(x => x.Name == applianceName);
        }

        public IEnumerable<Product> AddGoods(int inputType, int inputCount)
        {
            var addedProducts = new List<Product>();
            for (int i = 0; i < inputCount; i++)
            {
                addedProducts.Add(new Product());
                unitOfWorkContext.Products.Create(addedProducts[addedProducts.Count - 1]);
            }

            return addedProducts;
        }

        public IEnumerable<Product> GetStock(out List<int> stockSummary)
        {
            var stockNumbersDetail = cache.GetObject<List<Product>>(() => Console.WriteLine("Appliance distributor requested data."));
            stockSummary = new List<int>() { 0, 0, 0 };

            foreach (var item in stockNumbersDetail)
            {
                switch (item.CategoryId)
                {
                    case Category.Washer:
                        stockSummary[0]++;
                        break;
                    case Category.Refrigerator:
                        stockSummary[1]++;
                        break;
                    case Category.KitchenStove:
                        stockSummary[2]++;
                        break;
                }
            }

            return stockNumbersDetail;
        }

        public void SaveStockState()
        {
            dataSerializer.SerializeAndSave(unitOfWorkContext);
        }
    }
}
