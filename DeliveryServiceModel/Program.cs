using Microsoft.Extensions.Configuration;
using System.IO;

namespace DeliveryServiceModel
{
    public class Program
    {
        static void Main(string[] args)
        {/*
            var example = new LinqExamples(new TestData());
            example.QueryTask();*/

            var configuration = Initialize();
            var IOLayer = new ConsoleIO(configuration);
            IOLayer.StartMenu();
        }

        private static IConfiguration Initialize()
        {
            var builder = new ConfigurationBuilder().
                SetBasePath(Directory.GetCurrentDirectory()).
                AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }
    }
}
