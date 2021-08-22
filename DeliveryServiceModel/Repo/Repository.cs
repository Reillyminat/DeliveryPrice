using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DeliveryServiceModel.Repo
{
    public class Repository : IRepository
    {
        private IDbConnection db;

        public Repository(string connectionString)
        {
            db = new SqlConnection(connectionString);
        }

        public int AddProduct(Product product)
        {
            var sql = "INSERT INTO Products VALUES (@Name, @GuaranteeInMonths, @HeightInMeters," +
       " @WidthInMeters, @DepthInMeters, @Price, @Amount, " +
       "@ProducingCountry, @ProductTypeId, @Description)";
            var t = db.Query(sql, new
            {
                Id = product.Id,
                Name = product.Name,
                Amount = product.Amount,
                GuaranteeInMonths = product.GuaranteeInMonths,
                DepthInMeters = product.DepthInMeters,
                WidthInMeters = product.WidthInMeters,
                HeightInMeters = product.HeightInMeters,
                Price = product.Price,
                ProductTypeId = product.CategoryId,
                ProducingCountry = product.ProducingCountry,
                Description = ""
            });
            return product.Id;
        }

        public int AddOrderWithProducts(Order order)
        {
            var sqlOrder = "SET IDENTITY_INSERT Orders ON; INSERT INTO Orders (Id, UserId, TimeOfOrdering, TimeOfTaking, Price) VALUES (@Id, @UserId, @TimeOfOrdering, @TimeOfTaking, @Price)";
            var sqlOrderProducts = "INSERT INTO OrderProducts VALUES (@ProductId, @Id)";


            foreach (var product in order.Products)
            {
                order.Price += product.Price;
            }

            db.Query(sqlOrder, new
            {
                Id = order.Id,
                TimeOfOrdering = order.TimeOfOrdering,
                TimeOfTaking = order.TimeOfTaking,
                Price = order.Price,
                UserId = order.User.Id
            });

            foreach (var product in order.Products)
            {
                db.Query(sqlOrderProducts, new
                {
                    Id = order.Id,
                    ProductId = product.Id
                });
            }
            return order.Id;
        }

        public int DeleteProduct(Product product)
        {
            var sql = "DELETE FROM Products WHERE ProductId=@Id";
            db.Query<Product>(sql, new { Id = product.Id });

            return product.Id;
        }

        public int DeleteOrderWithProducts(Order order)
        {
            var sql = "DELETE FROM OrderProducts WHERE Id=@Id; DELETE FROM Orders WHERE Id=@Id";
            db.Query(sql, new { Id = order.Id });

            return order.Id;
        }

        public List<Order> GetOrdersWithProducts()
        {
            var sql = "SELECT * FROM Orders " +
"JOIN OrderProducts ON OrderProducts.Id = Orders.Id " +
"JOIN Products ON OrderProducts.ProductId = Products.ProductId " +
"JOIN Users ON Users.UserId=Orders.UserId";
            var dictionary = new Dictionary<int, Order>();
            var multires = db.Query<Order, Product, User, Order>(sql,
                (order, product, user) =>
                {
                    Order ord;
                    if (!dictionary.TryGetValue(order.Id, out ord))
                    {
                        ord = order;
                        dictionary.Add(ord.Id, ord);
                    }
                    ord.Products.Add(product);
                    ord.User = user;
                    return ord;
                },
                splitOn: "Id,UserId").
                Distinct().
                ToList();

            return multires;
        }

        public Order GetOrderWithProductsById(int id)
        {
            return GetOrdersWithProducts().Where(p => p.Id == id).FirstOrDefault();
        }

        public Product GetProductById(int id)
        {
            var sql = "SELECT * FROM Products WHERE ProductId=@Id";
            return db.Query<Product>(sql, new { Id = id }).SingleOrDefault();
        }

        public int UpdateProduct(Product product)
        {
            var sql = "UPDATE Products SET Name = @Name, Amount=@Amount, GuaranteeInMonths=@GuaranteeInMonths, " +
                "DepthInMeters=@DepthInMeters, WidthInMeters=@WidthInMeters, HeightInMeters=@HeightInMeters, Price = @Price," +
                "ProductTypeId=@ProductTypeId, ProducingCountry=@ProducingCountry WHERE ProductId = @Id";
            db.Query<Product>(sql, new
            {
                Id = product.Id,
                Name = product.Name,
                Amount = product.Amount,
                GuaranteeInMonths = product.GuaranteeInMonths,
                DepthInMeters = product.DepthInMeters,
                WidthInMeters = product.WidthInMeters,
                HeightInMeters = product.HeightInMeters,
                Price = product.Price,
                ProductTypeId = product.CategoryId,
                ProducingCountry = product.ProducingCountry
            }).SingleOrDefault();

            return product.Id;
        }

        public int UpdateOrderWithUser(Order order)
        {
            var sqlOrder = "SET IDENTITY_INSERT Orders ON; UPDATE Orders SET UserId=@UserId, TimeOfOrdering=@TimeOfOrdering, TimeOfTaking=@TimeOfTaking, Price=@Price WHERE Id=@Id";
            var sqlUser = "UPDATE Users SET UserId=@UserId, Address=@Address, FullName=@FullName, Telephone=@Telephone WHERE UserId=@UserId";

            order.Price = 0;
            foreach (var product in order.Products)
            {
                order.Price += product.Price;
            }

            db.Query(sqlOrder, new
            {
                Id = order.Id,
                TimeOfOrdering = order.TimeOfOrdering,
                TimeOfTaking = order.TimeOfTaking,
                Price = order.Price,
                UserId = order.User.Id
            });

            db.Query(sqlUser, new
            {
                UserId = order.User.Id,
                Address = order.User.Address,
                FullName = order.User.Name,
                Telephone = order.User.Telephone
            });

            return order.Id;
        }

        public List<Product> GetProducts()
        {
            var sql = "SELECT * FROM Products";
            return db.Query<Product>(sql, null).ToList();
        }
    }
}