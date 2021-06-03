using AppliancesModel.Contracts;
using System.Linq;
namespace AppliancesModel.Models
{
    public class OrderManager : IOrderManager
    {
        private IOrdersData ordersData;

        private int id;

        public Order CurrentOrder { get; set; }

        public OrderManager(IOrdersData ordersData)
        {
            id = 0;
            this.ordersData = ordersData;
        }

        public Order CreateShoppingBasket(User person)
        {
            foreach (Order order in ordersData.Order)
                if (order.Name == person.Name)
                    return order;
            ordersData.Order.Add(new Order(id++, person.Address, person.Name, person.Telephone));
            CurrentOrder = ordersData.Order.Last();
            return CurrentOrder;
        }

        public void SetOrderData(string name, string address, string telephone)
        {
            ordersData.Order.Add(new Order(id++, address, name, telephone));
            CurrentOrder = ordersData.Order.Last();
        }

        public void AddItemToBasket(Appliance goods, int amount)
        {
            var isNew = true;
            foreach (var sample in CurrentOrder.basket)
                if (sample.Id == goods.Id)
                {
                    sample.Amount += amount;
                    isNew = false;
                    break;
                }
            CurrentOrder.Price += goods.Price * amount;
            if (isNew)
            {
                var orderedAppliance = XmlSerialization.CreateDeepCopy<Appliance>(goods);
                orderedAppliance.Amount = amount;
                CurrentOrder.basket.Add(orderedAppliance);
            }

        }
    }
}
