using AppliancesModel.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
namespace AppliancesModel.Models
{
    public class OrderManager : IOrderManager
    {
        private readonly IDataSerialization dataSerializer;

        private readonly IOrdersData dataSource;

        public Order CurrentOrder { get; set; }

        public OrderManager(IOrdersData data, IDataSerialization serializer)
        {
            dataSource = data ?? throw new ArgumentNullException(nameof(data));
            dataSerializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
            CurrentOrder = dataSource.Orders.Count == 0 ? default : dataSource.Orders.Last();
        }

        public Order CreateShoppingBasket(User person)
        {
            foreach (var order in dataSource.Orders)
            {
                if (order.Name == person.Name)
                {
                    return order;
                }
            }

            dataSource.Orders.Add(new Order() { Id = dataSource.Id++, Address = person.Address, Name = person.Name, Telephone = person.Telephone, Basket = new List<Appliance>(), Price = 0 });
            CurrentOrder = dataSource.Orders.Last();

            return CurrentOrder;
        }

        public void SetOrderData(string name, string address, string telephone)
        {
            dataSource.Orders.Add(new Order() { Id = dataSource.Id++, Address = address, Name = name, Telephone = telephone, Basket = new List<Appliance>(), Price = 0 });
            CurrentOrder = dataSource.Orders.Last();
        }

        public void AddItemToBasket(Appliance goods, int amount)
        {
            var isNew = true;

            foreach (var sample in CurrentOrder.Basket)
            {
                if (sample.Id == goods.Id)
                {
                    sample.Amount += amount;
                    isNew = false;
                    break;
                }
            }

            CurrentOrder.Price += goods.Price * amount;

            if (isNew)
            {
                var orderedAppliance = XmlSerialization.CreateDeepCopy<Appliance>(goods);
                orderedAppliance.Amount = amount;
                CurrentOrder.Basket.Add(orderedAppliance);
            }

        }

        public void SaveOrdersState()
        {
            dataSerializer.SerializeAndSave(dataSource);
        }
    }
}
