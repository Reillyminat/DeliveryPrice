using DeliveryServiceModel;
using EFCore5.Data;
using System;
using System.Linq;

namespace EFCore5.UI
{
    class Program
    {
        private static DataContext context;
        static void Main(string[] args)
        {
            context = new DataContext();
            context.Database.EnsureCreated();
            var unitOfWork = new UnitOfWork(context);
            var consoleIO = new ConsoleIO(unitOfWork);
            consoleIO.FillTestData();
            consoleIO.GetAllTestData();
            consoleIO.GetByIdTestData();
            consoleIO.UpdateTestData();
            consoleIO.DeleteByIdTestData();
        }

        private static void AddUser()
        {
            var usr = new User() { FullName = "Петров Валерий Александрович", Telephone = "380671827384", Address = "г. Новомосковск, ул. Северная, д. 28, кв. 16" };
            context.Users.Add(usr);
            context.SaveChanges();
        }
        private static void GetUsers()
        {
            var users = context.Users.ToList();
            Console.WriteLine($"Total users {users.Count}");
            foreach(var user in users)
            {
                Console.WriteLine($"Name= {user.FullName}, Id={user.Id}");
            }
        }
    }
}
