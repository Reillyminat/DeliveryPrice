﻿using AppliancesModel.Contracts;
using DeliveryServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
namespace AppliancesModel.Models
{
    public class OrderManager : IOrderManager
    {
        private readonly IOrdersData dataSource;

        private readonly IDataSerialization dataSerializer;

        private readonly ICacheable cache;

        public Order CurrentOrder { get; set; }

        public OrderManager(IOrdersData data, IDataSerialization serializer, ICacheable cacheProvider)
        {
            dataSource = data ?? throw new ArgumentNullException(nameof(data));
            dataSerializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
            CurrentOrder = dataSource.Orders.Count == 0 ? default : dataSource.Orders.Last();
            cache = cacheProvider ?? throw new ArgumentNullException(nameof(cacheProvider));
        }

        public Order CreateShoppingBasket(User person)
        {
            var ordersCache = cache.GetObject<IOrdersData>(() => Console.WriteLine("Order manager requested data."));
            var result = ordersCache.Orders.FirstOrDefault(n => n.User.Name == person.Name);

            if (result != null)
            {
                CurrentOrder = result;
                return result;
            }

            SetOrderData(person.Name, person.Address, person.Phone);

            return CurrentOrder;
        }

        public void SetOrderData(string name, string address, string phone)
        {
            dataSource.Orders.Add(new Order() { User = new User { Address = address, Name = name, Phone = phone }, Products = new List<Product>(), Price = 0 });
            CurrentOrder = dataSource.Orders.Last();
        }

        public void AddItemToBasket(Product product, int amount)
        {
            var isNew = true;

            foreach (var sample in CurrentOrder.Products)
            {
                if (sample.Id == product.Id)
                {
                    sample.Amount += amount;
                    isNew = false;
                    break;
                }
            }

            CurrentOrder.Price += product.Price * amount;

            if (isNew)
            {
                var orderedAppliance = XmlSerialization.CreateDeepCopy<Product>(product);
                orderedAppliance.Amount = amount;
                CurrentOrder.Products.Add(orderedAppliance);
            }

        }

        public void SaveOrdersState()
        {
            dataSerializer.SerializeAndSave(dataSource);
        }
    }
}
