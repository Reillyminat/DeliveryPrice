using DeliveryServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
namespace LINQTasks
{
    public class LinqExamples
    {
        private readonly TestData data;

        public LinqExamples(TestData sourceData)
        {
            data = sourceData;
            data.FillData();
        }

        public IEnumerable<Product> Task1()
        {
            return data.suppliers.SelectMany(x => x.Stock).OrderBy(x => x.Name).Distinct(new AppliancesComparer());
        }

        public object Task2()
        {
            return data.suppliers.SelectMany(x => x.Stock, (s, p) => new { Region = s.Region, Product = p.Name });
        }

        public object Task3()
        {
            return data.suppliers.
                SelectMany(x => x.Stock, (s, p) => new { SupplierName = s.Name, Product = p.CategoryId, Amount = p.Amount }).
                GroupBy(x => new { x.SupplierName, x.Product }).
                Select(g => new { Key = g.Key, Amount = g.Sum(s => s.Amount) });
        }

        public object Task4()
        {
            return data.suppliers.Select(x => new { x.Stock, x.Name }).OrderByDescending(x => x.Stock.Count);
        }

        public IEnumerable<Product> Task5()
        {
            var appliancesComparer = new AppliancesComparer();
            dynamic firstSupplier = GetSupplierByName("Rozetka");
            dynamic secondSupplier = GetSupplierByName("Foxtrot");
            var intersectedAppliances = ((ICollection<Product>)(firstSupplier.Stock)).Intersect((ICollection<Product>)secondSupplier.Stock, appliancesComparer);

            return intersectedAppliances;
        }

        public IEnumerable<Product> Task6()
        {
            var appliancesComparer = new AppliancesComparer();
            dynamic firstSupplier = GetSupplierByName("Rozetka");
            dynamic secondSupplier = GetSupplierByName("Foxtrot");
            var exceptedAppliances = ((ICollection<Product>)(firstSupplier.Stock)).Except((ICollection<Product>)secondSupplier.Stock, appliancesComparer);
            return exceptedAppliances;
        }

        public void QueryTask()
        {
            //Task 1
            Console.WriteLine("Task 1");

            foreach (var appliance in Task1())
            {
                Console.WriteLine("Appliance: {0}.", appliance.Name);
            }

            //Task 2
            Console.WriteLine("\nTask 2");

            foreach (var supplierStock in (dynamic)Task2())
            {
                Console.WriteLine("Supplier: {0}, product: {1}", supplierStock.Region, supplierStock.Product);
            }

            //Task 3
            Console.WriteLine("\nTask 3");

            foreach (var supplier in (dynamic)Task3())
            {
                Console.WriteLine("{0}, total amount {1} ", supplier.Key, supplier.Amount);
            }

            //Task 4
            Console.WriteLine("\nTask 4");

            foreach (var supplier in (dynamic)Task4())
            {
                Console.WriteLine("Supplier: {0}, appliances category count: {1}", supplier.Name, supplier.Stock.Count);
            }

            //Task 5
            Console.WriteLine("\nTask 5");
            dynamic firstSupplier = GetSupplierByName("Rozetka");
            dynamic secondSupplier = GetSupplierByName("Foxtrot");
            Console.WriteLine("Supplier {0} and {1} has such the same products: ", firstSupplier.Name, secondSupplier.Name);

            foreach (var intersected in Task5())
            {
                Console.WriteLine(intersected.Name);
            }

            //Task 6
            Console.WriteLine("\nTask 6");
            Console.WriteLine("Supplier {0} has such unique products compare with {1}: ", firstSupplier.Name, secondSupplier.Name);

            foreach (var excepted in Task6())
            {
                Console.WriteLine(excepted.Name);
            }
        }

        private object GetSupplierByName(string name)
        {
            var suppliersCollection = data.suppliers.Select(x => new { x.Stock, x.Name });
            return suppliersCollection.Where(p => p.Name == name).FirstOrDefault();
        }
    }
}
