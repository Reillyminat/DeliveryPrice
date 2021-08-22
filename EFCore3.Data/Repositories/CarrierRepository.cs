using DeliveryServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCore5.Data
{
    public class CarrierRepository : IRepository<Carrier>
    {
        private readonly DataContext db;

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
            if (carrier is not null)
            {
                db.Carriers.Remove(carrier);
            }
        }

        public Carrier Get(int id)
        {
            return db.Carriers.Find(id);
        }

        public IEnumerable<Carrier> GetAllMatchingTheFilter(Predicate<string> predicate)
        {
            return ((IEnumerable<Carrier>)db.Carriers).Where(x => predicate(x.Name));
        }

        public IEnumerable<Carrier> GetAll()
        {
            return db.Carriers;
        }

        public void Update(Carrier item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}