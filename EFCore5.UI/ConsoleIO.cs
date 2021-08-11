using DeliveryServiceModel;
using EFCore5.Data;
using System;
using System.Collections.Generic;

namespace EFCore5.UI
{
    public class ConsoleIO
    {
        private readonly UnitOfWork unitOfWork;

        public ConsoleIO(UnitOfWork unit)
        {
            unitOfWork = unit;
        }
        public void FillTestData()
        {
            var order = new Order
            {
                User = new User { Address = "г. Днепр, ул. Тарасова, д. 7, кв. 9", FullName = "Нуров Александр Александрович", Telephone = "380783423231" },
                Products = new List<Product> { new Product
                {
                    Amount = 14,
                    DepthInMeters = 1.2M,
                    HeightInMeters = 1.4M,
                    WidthInMeters = 0.9M,
                    GuaranteeInMonths = 6,
                    Name = "KitchenStove05",
                    Price = 300,
                    ProducingCountry = "USA",
                    ProductTypeId = Categories.KitchenStove
                } },
                Price = 0,
                TimeOfOrdering = new DateTime(2021, 9, 20, 12, 35, 44),
                TimeOfTaking = new DateTime(2021, 9, 23, 13, 35, 56),
                Carrier = new Carrier
                {
                    Name = "Nova Poshta",
                    Tarrifs = new List<Tariff> {
                        new Tariff() {
                            DestinationAddress = "г. Днепр, ул. Полевая, дом 6б",
                            Price = 150 }
                    }
                },
                Supplier = new Supplier
                {
                    Name = "Rozetka",
                    Region = "Dnipro",
                    Stock = new List<Product> { new Product
            {
                Amount = 12,
                DepthInMeters = 1.1M,
                HeightInMeters = 1.2M,
                WidthInMeters = 0.9M,
                GuaranteeInMonths = 12,
                Name = "KitchenStove04",
                Price = 300,
                ProducingCountry = "USA",
                ProductTypeId = Categories.KitchenStove
            },
                    new Product
            {
                Amount = 10,
                DepthInMeters = 1M,
                HeightInMeters = 1.3M,
                WidthInMeters = 0.8M,
                GuaranteeInMonths = 10,
                Name = "Washer567",
                Price = 200,
                ProducingCountry = "UA",
                ProductTypeId = Categories.Washer
            }}
                }
            };

            unitOfWork.Orders.Create(order);
            unitOfWork.Save();
        }

        public void UpdateTestData()
        {
            var newUser = new User { Id = 1, Address = "г. Днепр, ул. Тарасова, д. 7, кв. 9", FullName = "Нуров Александр Александрович", Telephone = "380783423234" };
            unitOfWork.Users.Update(newUser);
            unitOfWork.Save();
        }

        public void GetByIdTestData()
        {
            var user = unitOfWork.Users.Get(1);
            Console.WriteLine("UserName: {0}, address: {1}, id: {2}, telephone: {3}", user.FullName, user.Address, user.Id, user.Telephone);
        }

        public void GetAllTestData()
        {
            var products = unitOfWork.Products.GetAll();

            foreach (var product in products)
            {
                Console.WriteLine("Product: {0}, amount: {1}", product.Name, product.Amount);
            }
        }

        public void DeleteByIdTestData()
        {
            unitOfWork.Products.Delete(1);
            unitOfWork.Save();
        }
    }
}
