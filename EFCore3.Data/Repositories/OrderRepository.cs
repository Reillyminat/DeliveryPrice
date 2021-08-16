using DeliveryServiceModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace EFCore5.Data
{
    public class OrderRepository : IRepository<Order>
    {
        private DataContext db;

        public OrderRepository(DataContext context)
        {
            db = context;
        }

        public IEnumerable<Order> GetAll(Predicate<string> predicate)
        {
            return db.Orders;
        }

        public Order Get(int id)
        {
            return db.Orders.Find(id);
        }

        public void Create(Order order)
        {
            db.Orders.Add(order);
        }

        public void Update(Order order)
        {
            db.Entry(order).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var order = db.Orders.Find(id);
            if (order != null)
                db.Orders.Remove(order);
        }
    }

}
