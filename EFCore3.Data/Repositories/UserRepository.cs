using DeliveryServiceModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCore5.Data
{
    public class UserRepository : IRepository<User>
    {
        private readonly DataContext db;

        public UserRepository(DataContext context)
        {
            db = context;
        }

        public IEnumerable<User> GetAllMatchingTheFilter(Predicate<string> predicate)
        {
            return ((IEnumerable<User>)db.Users).Where(x => predicate(x.Phone));
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public void Create(User user)
        {
            db.Users.Add(user);
        }

        public void Update(User user)
        {
            db.Entry(user).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var user = db.Users.Find(id);
            if (user is not null)
            {
                db.Users.Remove(user);
            }
        }
    }
}
