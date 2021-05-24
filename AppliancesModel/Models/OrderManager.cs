﻿using AppliancesModel.Contracts;
using System.Linq;
namespace AppliancesModel.Models
{
    public class OrderManager : IOrderManager
    {
        private readonly IOrdersData ordersData;

        private readonly IDataSerialization dataSerializer;

        public Order CurrentOrder { get; set; }

        public OrderManager(IOrdersData data, IDataSerialization serializer)
        {
            ordersData = data;
            dataSerializer = serializer;
            CurrentOrder = ordersData.Order.Count == 0 ? default : ordersData.Order.Last();
        }

        public Order CreateShoppingBasket(User person)
        {
            foreach (Order order in ordersData.Order)
                if (order.Name == person.Name)
                    return order;
            ordersData.Order.Add(new Order(ordersData.Id++, person.Address, person.Name, person.Telephone));
            CurrentOrder = ordersData.Order.Last();
            return CurrentOrder;
        }

        public void SetOrderData(string name, string address, string telephone)
        {
            ordersData.Order.Add(new Order(ordersData.Id++, address, name, telephone));
            CurrentOrder = ordersData.Order.Last();
        }

        public void AddItemToBasket(Appliances goods, int amount)
        {
            var isNew = true;
            foreach (Appliances sample in CurrentOrder.basket)
                if (sample.Id == goods.Id)
                {
                    sample.Amount += amount;
                    isNew = false;
                    break;
                }
            CurrentOrder.Price += goods.Price * amount;
            if (isNew)
            {
                Appliances orderedAppliance = XmlSerialization.CreateDeepCopy<Appliances>(goods);
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
