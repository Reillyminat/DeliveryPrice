using DeliveryServiceModel;
using EFCore5.Data;
using System;
using System.Collections.Generic;
using System.Linq;

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
                    ProductTypeId = Categories.KitchenStove,Suppliers=new List<Supplier>{ new Supplier { Id=0} }
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
            var newUser = unitOfWork.Users.Get(2);
            newUser.FullName = "Алексов Николай Васильевич";
            unitOfWork.Users.Update(newUser);
            unitOfWork.Save();
        }

        public void GetByIdTestData()
        {
            var user = unitOfWork.Users.Get(2);
            Console.WriteLine("UserName: {0}, address: {1}, id: {2}, telephone: {3}", user.FullName, user.Address, user.Id, user.Telephone);
        }

        public void GetAllTestData()
        {
            Predicate<string> isKyivstar = delegate (string x) { return x.StartsWith("38097") || x.StartsWith("38067") || x.StartsWith("38068") || x.StartsWith("38096") || x.StartsWith("38098"); };
            var users = unitOfWork.Users.GetAll(isKyivstar);
            Console.WriteLine("Kyivstar users:");

            foreach (var user in users)
            {
                Console.WriteLine("User: {0}, telephone: {1}", user.FullName, user.Telephone);
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
            var users = unitOfWork.Users.GetAll(delegate (string x) { return true; });
            var testUser = users.FirstOrDefault();
            testUser.FullName = "Веселов Андрей Павлович";
            unitOfWork.Users.Update(testUser);
            unitOfWork.Save();
        }
    }
}
