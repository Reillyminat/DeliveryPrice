using AppliancesModel.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
namespace AppliancesModel.Models
{
    public class OrderManager : IOrderManager
    {
        private readonly IDataSerialization dataSerializer;

        private readonly IOrdersData orders;

        public Order CurrentOrder { get; set; }

        public OrderManager(IOrdersData data, IDataSerialization serializer)
        {
            orders = data ?? throw new ArgumentNullException(nameof(data)); ;
            dataSerializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
            CurrentOrder = orders.Order.Count == 0 ? default : orders.Order.Last();
        }

        public Order CreateShoppingBasket(User person)
        {
            foreach (var order in orders.Orders)
            {
                if (order.Name == person.Name)
                {
                    return order;
                }
            }

            orders.Orders.Add(new Order() { Id = orders.Id++, Address = person.Address, Name = person.Name, Telephone = person.Telephone, Basket = new List<Appliance>(), Price = 0 });
            CurrentOrder = orders.Orders.Last();

            return CurrentOrder;
        }

        public void SetOrderData(string name, string address, string telephone)
        {
            orders.Orders.Add(new Order() { Id = orders.Id++, Address = address, Name = name, Telephone = telephone, Basket = new List<Appliance>(), Price = 0 });
            CurrentOrder = orders.Orders.Last();
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
            dataSerializer.SerializeToFile(ordersData);
        }
    }
}
