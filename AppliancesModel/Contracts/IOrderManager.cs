using AppliancesModel.Models;
using DeliveryServiceModel;
using System.Collections.Generic;

namespace AppliancesModel.Contracts
{
    public interface IOrderManager
    {
        void CreateOrder(Order order);

        void UpdateOrder(Order order);

        Order GetOrder(int id);

        IEnumerable<Order> GetOrders();

        void DeleteOrder(int id);

        void SaveOrdersState();
    }
}
