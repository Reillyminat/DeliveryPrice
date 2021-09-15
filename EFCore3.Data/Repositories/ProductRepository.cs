using DeliveryServiceModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCore5.Data
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly DataContext db;

        public ProductRepository(DataContext context)
        {
            db = context;
        }

        public void Create(Product item)
        {
            db.Products.Add(item);
        }

        public void Delete(int id)
        {
            var product = db.Products.Find(id);
            if (product is not null)
            {
                db.Products.Remove(product);
            }
        }

        public Product Get(int id)
        {
            return db.Products.Find(id);
        }

        public IEnumerable<Product> GetAllMatchingTheFilter(Predicate<string> predicate)
        {
            return ((IEnumerable<Product>)db.Products).Where(x => predicate(x.ProducingCountry));
        }

        public IEnumerable<Product> GetAll()
        {
            return db.Products.Include(s => s.Suppliers);
        }

        public void Update(Product item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}