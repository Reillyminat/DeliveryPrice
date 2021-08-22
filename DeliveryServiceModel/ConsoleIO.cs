using DeliveryServiceModel.Repo;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace DeliveryServiceModel
{
    public class ConsoleIO
    {
        private readonly IConfiguration configuration;
        private IRepository repository;
        public ConsoleIO(IConfiguration config)
        {
            configuration = config;
        }

        public void StartMenu()
        {
            var endToken = true;
            if (CheckIntInput("Choose dapper handler:\n" +
                "1. Dapper.\n" +
                "2. Dapper contrib.\n", 1, 2) == 1)
            {
                repository = new Repository(configuration.GetConnectionString("DefaultConnection"));
            }
            else
            {
                repository = new RepositoryContrib(configuration.GetConnectionString("DefaultConnection"));
            }
            do
            {
                switch (CheckIntInput("Choose DB action:\n" +
                    "1. Search product by id.\n" +
                    "2. Search order with products by id.\n" +
                    "3. Select products.\n" +
                    "4. Select order with products.\n" +
                    "5. Add product.\n" +
                    "6. Add order with products.\n" +
                    "7. Update product.\n" +
                    "8. Update order with products.\n" +
                    "9. Delete product.\n" +
                    "10. Delete order with products.\n" +
                    "11. Exit.\n", 1, 11))
                {
                    case 1:
                        Console.WriteLine("Product with name {0} has been found.\n", repository.GetProductById(4).Name);
                        break;
                    case 2:
                        var order = repository.GetOrderWithProductsById(5);
                        Console.WriteLine("Order with id {0} has been found. Contained products:", order.Id);

                        foreach (var product in order.Products)
                        {
                            Console.WriteLine(product.Name);
                        }

                        Console.WriteLine();
                        break;
                    case 3:
                        var productsList = repository.GetProducts();
                        Console.WriteLine("Products list:");

                        foreach (var product in productsList)
                        {
                            Console.WriteLine(product.Name);
                        }

                        Console.WriteLine();
                        break;
                    case 4:
                        var orderWithProducts = repository.GetOrdersWithProducts();
                        Console.WriteLine("Orders:");

                        foreach (var orders in orderWithProducts)
                        {
                            Console.WriteLine("Order id:{0}, total price:{1}, products count: {2}", orders.Id, orders.Price, orders.Products.Count);
                        }

                        Console.WriteLine();
                        break;
                    case 5:
                        var addedProductid = repository.AddProduct(new Product
                        {
                            Amount = 13,
                            DepthInMeters = 1,
                            HeightInMeters = 1.2M,
                            WidthInMeters = 0.9M,
                            GuaranteeInMonths = 6,
                            Name = "KitchenStove03",
                            Price = 300,
                            Id = 5,
                            ProducingCountry = "USA",
                            CategoryId = Category.KitchenStove
                        });
                        Console.WriteLine("Added product with id {0}.\n", addedProductid);
                        break;
                    case 6:
                        var addedOrderWithProducts = repository.AddOrderWithProducts(new Order
                        {
                            Id = 25,
                            User = new User { Id = 20, Address = "г. Днепр, ул. Тарасова, д. 7, кв. 9", Name = "Нуров Александр Александрович", Telephone = "380783423231" },
                            Products = new List<Product> { new Product
            {
                Amount = 14,
                DepthInMeters = 1.2M,
                HeightInMeters = 1.4M,
                WidthInMeters = 0.9M,
                GuaranteeInMonths = 6,
                Name = "KitchenStove05",
                Price = 300,
                Id = 5,
                ProducingCountry = "USA",
                CategoryId = Category.KitchenStove
            }},
                            Price = 0,
                            TimeOfOrdering = new DateTime(2021, 9, 20, 12, 35, 44),
                            TimeOfTaking = new DateTime(2021, 9, 23, 13, 35, 56)
                        });
                        Console.WriteLine("Added order with products id {0}.\n", addedOrderWithProducts);
                        break;
                    case 7:
                        var updatedProductId = repository.UpdateProduct(new Product
                        {
                            Amount = 3,
                            DepthInMeters = 1,
                            HeightInMeters = 1.2M,
                            WidthInMeters = 0.9M,
                            GuaranteeInMonths = 12,
                            Name = "KitchenStove9999",
                            Price = 300,
                            Id = 5,
                            ProducingCountry = "UA",
                            CategoryId = Category.KitchenStove
                        });
                        Console.WriteLine("Updated product with id {0}.\n", updatedProductId);
                        break;
                    case 8:
                        var updatedOrderWithProductsId = repository.UpdateOrderWithUser(new Order
                        {
                            Id = 24,
                            User = new User { Id = 15, Address = "г. Новомосковск, ул. Советская, 56б, кв. 16", Name = "Соблев Владимир Николаевич", Telephone = "380671827384" },
                            Products = new List<Product> { new Product
            {
                Amount = 12,
                DepthInMeters = 1.1M,
                HeightInMeters = 1.2M,
                WidthInMeters = 0.9M,
                GuaranteeInMonths = 12,
                Name = "KitchenStove04",
                Price = 300,
                Id = 5,
                ProducingCountry = "USA",
                CategoryId = Category.KitchenStove
            }},
                            Price = 0,
                            TimeOfOrdering = new DateTime(2021, 9, 20, 12, 35, 44),
                            TimeOfTaking = new DateTime(2021, 9, 29, 13, 35, 56)
                        });
                        Console.WriteLine("Updated order with products id {0}.\n", updatedOrderWithProductsId);
                        break;
                    case 9:
                        var deletedProductId = repository.DeleteProduct(new Product { Id = 3 });
                        Console.WriteLine("Deleted product with id {0}.\n", deletedProductId);
                        break;
                    case 10:
                        var deletedOrderWithProductsId = repository.DeleteOrderWithProducts(new Order { Id = 25, Products = new List<Product> { new Product { Id = 5 } } });
                        Console.WriteLine("Deleted order with id {0}.\n", deletedOrderWithProductsId);
                        break;
                    case 11:
                        endToken = false;
                        break;
                }
            } while (endToken);
        }

        public static int CheckIntInput(string article, int lowerBound, int upperBound)
        {
            int input;

            Console.WriteLine(article);

            do
            {
                Console.WriteLine("Input number {0} to {1}.", lowerBound, upperBound);
                int.TryParse(Console.ReadLine(), out input);
            } while (input < lowerBound || input > upperBound);

            return input;
        }
    }
}
