using DeliveryServiceModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCore5.Data
{
    public class ProductRepository : IRepository<Product>
    {

        private DataContext db;

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
            if (product != null)
                db.Products.Remove(product);
        }

        public Product Get(int id)
        {
            return db.Products.Find(id);
        }

        public IEnumerable<Product> GetAll(Predicate<string> predicate)
        {
            return db.Products;
        }

        public void Update(Product item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}