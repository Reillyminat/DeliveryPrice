using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DeliveryServiceModel.Repo
{
    public class RepositoryContrib : IRepository
    {
        private IDbConnection db;

        public RepositoryContrib(string connectionString)
        {
            db = new SqlConnection(connectionString);
            db.Open();
        }

        public int AddProduct(Product product)
        {
            db.Insert<Product>(product);
            return product.ProductId;
        }

        public int DeleteProduct(Product product)
        {
            db.Delete<Product>(product);
            return product.ProductId;
        }

        public Product GetProductById(int id)
        {
            return db.Get<Product>(id);
        }

        public List<Order> GetOrdersWithProducts()
        {
            return db.GetAll<Order>().ToList();
        }

        public int UpdateProduct(Product supplier)
        {
            db.Update<Product>(supplier);
            return supplier.ProductId;
        }

        public Order GetOrderWithProductsById(int id)
        {
            return db.Get<Order>(id);
        }

        public List<Product> GetProducts()
        {
            return db.GetAll<Product>().ToList();
        }

        public int DeleteOrderWithProducts(Order order)
        {
            foreach (var product in order.Products)
            {
                db.Delete(new OrderProduct{ ProductId = product.ProductId, Id=order.Id });
            }

            db.Delete(order);
            return order.Id;
        }

        public int AddOrderWithProducts(Order order)
        {
            db.Insert<Order>(order);

            foreach (var product in order.Products)
            {
                db.Insert(new OrderProduct { ProductId = product.ProductId, Id = order.Id });
            }

            return order.Id;
        }

        public int UpdateOrderWithUser(Order order)
        {
            foreach (var product in order.Products)
            {
                db.Update(new OrderProduct { ProductId = product.ProductId, Id = order.Id });
            }

            db.Update(order);
            return order.Id;
        }
    }
}
