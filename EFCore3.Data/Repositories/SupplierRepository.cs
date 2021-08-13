using DeliveryServiceModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace EFCore5.Data
{
    public class SupplierRepository : IRepository<Supplier>
    {
        private DataContext db;

        public SupplierRepository(DataContext context)
        {
            db = context;
        }

        public void Create(Supplier item)
        {
            db.Suppliers.Add(item);
        }

        public void Delete(int id)
        {
            var supplier = db.Suppliers.Find(id);
            if (supplier != null)
                db.Suppliers.Remove(supplier);
        }

        public Supplier Get(int id)
        {
            return db.Suppliers.Find(id);
        }

        public IEnumerable<Supplier> GetAll(Predicate<string> predicate)
        {
            return db.Suppliers;
        }

        public void Update(Supplier item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}