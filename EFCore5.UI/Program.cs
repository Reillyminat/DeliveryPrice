using DeliveryServiceModel;
using EFCore5.Data;
using Microsoft.EntityFrameworkCore;
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
            //consoleIO.DeleteByIdTestData();
            consoleIO.GetAndUpdateTestDataWithNoTracking();
        }
    }
}
