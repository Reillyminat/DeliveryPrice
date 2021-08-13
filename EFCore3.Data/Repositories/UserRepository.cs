using DeliveryServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCore5.Data
{
    public class UserRepository : IRepository<User>
    {
        private DataContext db;

        public UserRepository(DataContext context)
        {
            db = context;
        }

        public IEnumerable<User> GetAll(Predicate<string> predicate)
        {
            return ((IEnumerable<User>)db.Users).Where(x => predicate(x.Telephone));
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
            var foundedUser = db.Users.Find(user.Id);
            foundedUser.Address = user.Address;
            foundedUser.Telephone = user.Telephone;
            foundedUser.FullName = user.FullName;
        }

        public void Delete(int id)
        {
            var user = db.Users.Find(id);
            if (user != null)
                db.Users.Remove(user);
        }
    }
}
