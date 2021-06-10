using AppliancesModel.Contracts;
using System.Collections.Generic;
using System.Linq;
namespace AppliancesModel.Models
{
    public class OrderManager : IOrderManager
    {
        private IOrdersData orders;

        public Order CurrentOrder { get; set; }

        public OrderManager(IOrdersData ordersData)
        {
            orders = ordersData;
        }

        public Order CreateShoppingBasket(User person)
        {
            foreach (var order in orders.Order)
            {
                if (order.Name == person.Name)
                {
                    return order;
                }
            }

            orders.Order.Add(new Order() { Id = orders.Id++, Address = person.Address, Name = person.Name, Telephone = person.Telephone, Basket = new List<Appliance>(), Price = 0 });
            CurrentOrder = orders.Order.Last();

            return CurrentOrder;
        }

        public void SetOrderData(string name, string address, string telephone)
        {
            orders.Order.Add(new Order() { Id = orders.Id++, Address = address, Name = name, Telephone = telephone, Basket = new List<Appliance>(), Price = 0 });
            CurrentOrder = orders.Order.Last();
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
    }
}
