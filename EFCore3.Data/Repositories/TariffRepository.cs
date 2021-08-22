using DeliveryServiceModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCore5.Data
{
    public class TariffRepository : IRepository<Tariff>
    {
        private readonly DataContext db;

        public TariffRepository(DataContext context)
        {
            db = context;
        }

        public void Create(Tariff item)
        {
            db.Tariffs.Add(item);
        }

        public void Delete(int id)
        {
            var tariff = db.Tariffs.Find(id);
            if (tariff is not null)
            {
                db.Tariffs.Remove(tariff);
            }
        }

        public Tariff Get(int id)
        {
            return db.Tariffs.Find(id);
        }

        public IEnumerable<Tariff> GetAllMatchingTheFilter(Predicate<string> predicate)
        {
            return ((IEnumerable<Tariff>)db.Tariffs).Where(x => predicate(x.DestinationAddress));
        }

        public IEnumerable<Tariff> GetAll()
        {
            return db.Tariffs;
        }

        public void Update(Tariff item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}