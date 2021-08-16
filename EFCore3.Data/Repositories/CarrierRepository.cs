using DeliveryServiceModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace EFCore5.Data
{
    public class CarrierRepository : IRepository<Carrier>
    {
        private DataContext db;

        public CarrierRepository(DataContext context)
        {
            db = context;
        }
        public void Create(Carrier item)
        {
            db.Carriers.Add(item);
        }

        public void Delete(int id)
        {
            var carrier = db.Carriers.Find(id);
            if (carrier != null)
                db.Carriers.Remove(carrier);
        }

        public Carrier Get(int id)
        {
            return db.Carriers.Find(id);
        }

        public IEnumerable<Carrier> GetAll(Predicate<string> predicate)
        {
            return db.Carriers;
        }

        public void Update(Carrier item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}