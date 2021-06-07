using AppliancesModel.Contracts;
using System;
using System.Linq;
namespace AppliancesModel.Models
{
    public class OrderManager : IOrderManager
    {
        private readonly IOrdersData ordersData;

        private readonly IDataSerialization dataSerializer;

        private readonly ICacheable cache;

        public Order CurrentOrder { get; set; }

        public OrderManager(IOrdersData data, IDataSerialization serializer)
        {
            ordersData = data;
            cache = new Cache(ordersData);
            dataSerializer = serializer;
            CurrentOrder = ordersData.Order.Count == 0 ? default : ordersData.Order.Last();
        }

        public Order CreateShoppingBasket(User person)
        {
            var ordersCache = cache.GetObject<IOrdersData>(() => Console.WriteLine("Order manager requested data."));
            var result = ordersCache.Order.FirstOrDefault(n => n.Name == person.Name);
            
            if (result != null) {
                CurrentOrder = result;
                return result;
            }

            SetOrderData(person.Name, person.Address, person.Telephone);

            return CurrentOrder;
        }

        public void SetOrderData(string name, string address, string telephone)
        {
            ordersData.Order.Add(new Order(ordersData.Id++, address, name, telephone));
            CurrentOrder = ordersData.Order.Last();
        }

        public void AddItemToBasket(Appliance goods, int amount)
        {
            var isNew = true;
            CurrentOrder.Price += goods.Price * amount;

            foreach (var sample in CurrentOrder.basket)
            {
                if (sample.Id == goods.Id)
                {
                    sample.Amount += amount;
                    isNew = false;
                    break;
                }
            }

            if (isNew)
            {
                var orderedAppliance = XmlSerialization.CreateDeepCopy<Appliance>(goods);
                orderedAppliance.Amount = amount;
                CurrentOrder.basket.Add(orderedAppliance);
            }

        }

        public void SaveOrdersState()
        {
            dataSerializer.SerializeToFile(ordersData);
        }
    }
}
