using EFCore5.Data;

namespace EFCore5.UI
{
    class Program
    {
        private static DataContext context;
        static void Main(string[] args)
        {
            context = new DataContext();
            context.Database.EnsureCreated();

            var unitOfWork = new UnitOfWork(context,
                new UserRepository(context),
                new OrderRepository(context),
                new SupplierRepository(context),
                new TariffRepository(context),
                new CarrierRepository(context),
                new ProductRepository(context));
            var consoleIO = new ConsoleIO(unitOfWork);
            consoleIO.FillTestData();
            consoleIO.GetAllTestData();
            consoleIO.GetByIdTestData();
            consoleIO.UpdateTestData();
            consoleIO.GetAndUpdateTestDataWithNoTracking();
        }
    }
}
