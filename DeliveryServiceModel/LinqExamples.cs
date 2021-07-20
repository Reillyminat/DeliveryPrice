using System;
using System.Linq;
namespace DeliveryServiceModel
{
    public class LinqExamples
    {
        private readonly TestData data;

        public LinqExamples(TestData sourceData)
        {
            data = sourceData;
            data.FillData();
        }

        public void QueryTask()
        {
            //Task 1
            Console.WriteLine("Task 1");
            var stockCollection = data.suppliers.SuppliersCollection.SelectMany(x => x.Stock);

            foreach (var appliance in stockCollection.OrderBy(x => x.Name).GroupBy(x => x.Name))
            {
                Console.WriteLine("Appliance: {0}. Total count: {1}", appliance.Key, appliance.Count());
            }

            //Task 2
            Console.WriteLine("\nTask 2");
            var stockCollectionsBySuppliers = data.suppliers.SuppliersCollection.Select(x => new { x.Stock, x.Region });

            foreach (var supplierStock in stockCollectionsBySuppliers)
            {
                Console.WriteLine("---Supplier: {0}", supplierStock.Region);

                foreach (var appliances in supplierStock.Stock.OrderBy(x => x.Name))
                {
                    Console.WriteLine(appliances.Name);
                }
            }

            //Task 3
            Console.WriteLine("\nTask 3");
            var stockCollectionBySuppliers = data.suppliers.SuppliersCollection.Select(x => new { x.Stock, x.Name });
            foreach (var supplier in stockCollectionBySuppliers)
            {
                Console.WriteLine("---Supplier {0} has such amount of goods in each appliance categories: ", supplier.Name);
                foreach (var appliance in supplier.Stock.GroupBy(x => x.Type))
                {
                    Console.WriteLine("Category {0}, total appliances amount: {1}\n", appliance.Key, appliance.Sum(x => x.Amount));
                }
            }

            //Task 4
            Console.WriteLine("\nTask 4");
            var suppliersByProductsCountDescend = data.suppliers.SuppliersCollection.Select(x => new { x.Stock, x.Name }).OrderByDescending(x => x.Stock.Count);

            foreach (var supplier in suppliersByProductsCountDescend)
            {
                Console.WriteLine("Supplier: {0}, appliances category count: {1}", supplier.Name, supplier.Stock.Count);
            }

            //Task 5
            Console.WriteLine("\nTask 5");
            var appliancesComparer = new AppliancesComparer();
            var suppliersCollection = data.suppliers.SuppliersCollection.Select(x => new { x.Stock, x.Name });
            var firstSupplier = suppliersCollection.Where(p => p.Name == "Rozetka").FirstOrDefault();
            var secondSupplier = suppliersCollection.Where(p => p.Name == "Foxtrot").FirstOrDefault();
            var intersectedAppliances = firstSupplier.Stock.Intersect(secondSupplier.Stock, appliancesComparer);
            Console.WriteLine("Supplier {0} and {1} has such the same products: ", firstSupplier.Name, secondSupplier.Name);

            foreach (var intersected in intersectedAppliances)
            {
                Console.WriteLine(intersected.Name);
            }

            //Task 6
            Console.WriteLine("\nTask 6");
            var exceptedAppliances = firstSupplier.Stock.Except(secondSupplier.Stock, appliancesComparer);
            Console.WriteLine("Supplier {0} has such unique products compare with {1}: ", firstSupplier.Name, secondSupplier.Name);

            foreach (var excepted in exceptedAppliances)
            {
                Console.WriteLine(excepted.Name);
            }
        }
    }
}
