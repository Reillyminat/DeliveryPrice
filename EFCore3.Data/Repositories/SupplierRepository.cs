using DeliveryServiceModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCore5.Data
{
    public class SupplierRepository : IRepository<Supplier>
    {
        private readonly DataContext db;

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
            {
                db.Suppliers.Remove(supplier);
            }
        }

        public Supplier Get(int id)
        {
            return db.Suppliers.Find(id);
        }

        public IEnumerable<Supplier> GetAllMatchingTheFilter(Predicate<string> predicate)
        {
            return ((IEnumerable<Supplier>)db.Suppliers).Where(x => predicate(x.Name));
        }

        public IEnumerable<Supplier> GetAll()
        {
            return db.Suppliers.AsNoTracking();
        }

        public void Update(Supplier item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}