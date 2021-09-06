using DeliveryServiceModel;
using EFCore5.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCore5.UI
{
    public class ConsoleIO
    {
        private readonly IUnitOfWork unitOfWork;

        public ConsoleIO(IUnitOfWork unit)
        {
            unitOfWork = unit;
        }
        public void FillTestData()
        {
            var user = new User { Address = "г. Харьков, ул. Напольная, д. 13, кв. 2", Name = "Александр", SurName = "Корев", Partonimic = "Петрович", Phone = "380783456231" };

            var order = new Order
            {
                User = new User { Address = "г. Днепр, ул. Тарасова, д. 7, кв. 9", Name = "Александр", SurName = "Нуров", Partonimic = "Александрович", Phone = "380783423231" },
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
                    CategoryId = Category.KitchenStove,Suppliers=new List<Supplier>{ new Supplier { Id=0} }
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
                CategoryId = Category.KitchenStove
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
                CategoryId = Category.Washer
            }}
                }
            };
            unitOfWork.Orders.Create(order);
            unitOfWork.Save();
        }

        public void UpdateTestData()
        {
            var user = unitOfWork.Users.Get(1);
            user.Phone = "380783423234";
            unitOfWork.Users.Update(user);
            unitOfWork.Save();
        }

        public void GetByIdTestData()
        {
            var user = unitOfWork.Users.Get(1);
            Console.WriteLine("UserName: {0}, address: {1}, id: {2}, telephone: {3}", user.Name + " " + user.SurName, user.Address, user.Id, user.Phone);
        }

        public void GetAllTestData()
        {
            Predicate<string> isKyivstar = delegate (string x) { return x.StartsWith("38097") || x.StartsWith("38067") || x.StartsWith("38068") || x.StartsWith("38096") || x.StartsWith("38098"); };
            var users = unitOfWork.Users.GetAllMatchingTheFilter(isKyivstar);
            Console.WriteLine("Kyivstar users:");

            foreach (var user in users)
            {
                Console.WriteLine("User: {0}, telephone: {1}", user.Name + " " + user.SurName, user.Phone);
            }
        }

        public void DeleteByIdTestData()
        {
            unitOfWork.Orders.Delete(1);
            unitOfWork.Carriers.Delete(1);
            unitOfWork.Save();
        }

        public void GetAndUpdateTestDataWithNoTracking()
        {
            var users = unitOfWork.Users.GetAllMatchingTheFilter(delegate (string x) { return true; });
            var testUser = users.FirstOrDefault();
            testUser.Name = "Веселов Андрей Павлович";
            unitOfWork.Users.Update(testUser);
            unitOfWork.Save();
        }
    }
}
