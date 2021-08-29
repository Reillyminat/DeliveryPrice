using AppliancesModel.Contracts;
using DeliveryServiceModel;
using EFCore5.Data;
using System;
using System.Collections.Generic;
using System.Linq;
namespace AppliancesModel.Models
{
    public class OrderManager : IOrderManager
    {
        private readonly IRepository<Order> _orderRepository;

        private readonly IDataSerialization _dataSerializer;

        private readonly ICacheable _cache;

        public OrderManager(IRepository<Order> data, IDataSerialization serializer, ICacheable cacheProvider)
        {
            _orderRepository = data ?? throw new ArgumentNullException(nameof(data));
            _dataSerializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
            _cache = cacheProvider ?? throw new ArgumentNullException(nameof(cacheProvider));
            _cache.SetInstance(_orderRepository.GetAll().ToList());
        }

        public void CreateOrder(Order order)
        {
            _orderRepository.Create(order);
        }

        public void UpdateOrder(Order order)
        {
            var updatedOrder = GetOrder(order.Id);
            updatedOrder.CarrierId = order.CarrierId;
            updatedOrder.Carrier = order.Carrier;
            updatedOrder.Price = order.Price;
            updatedOrder.Products = order.Products;
            updatedOrder.StatusId = order.StatusId;
            updatedOrder.TimeOfOrdering = order.TimeOfOrdering;
            updatedOrder.TimeOfTaking = order.TimeOfTaking;
            updatedOrder.User = order.User;
            updatedOrder.UserId = order.UserId;
            updatedOrder.Supplier = order.Supplier;
            updatedOrder.SupplierId = order.SupplierId;

            _orderRepository.Update(order);
        }

        public IEnumerable<Order> GetOrders()
        {
            var ordersCache = _cache.GetObject<IEnumerable<Order>>(() => Console.WriteLine("Order manager requested data."));

            return ordersCache;
        }

        public Order GetOrder(int id)
        {
            var ordersCache = _cache.GetObject<List<Order>>(() => Console.WriteLine("Order manager requested data."));

            return ordersCache.FirstOrDefault(o => o.Id == id);
        }

        public void DeleteOrder(int id)
        {
            _orderRepository.Delete(id);
        }

        public void SaveOrdersState()
        {
            _dataSerializer.SerializeAndSave(_orderRepository);
        }
    }
}
