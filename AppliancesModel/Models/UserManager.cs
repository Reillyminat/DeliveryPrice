using AppliancesModel.Contracts;
using System;
using System.Linq;

namespace AppliancesModel.Models
{
    public class UserManager : IUserManager
    {
        private readonly IUsersData usersData;

        private readonly IDataSerialization dataSerializer;

        private readonly ICacheable cache;

        public UserManager(IUsersData users, IDataSerialization serializer, ICacheable cacheProvider)
        {
            usersData = users ?? throw new ArgumentNullException(nameof(users));
            dataSerializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
            cache = cacheProvider;
        }

        public User AddUser(string name, string address, string telephone)
        {
            var usersCache = cache.GetObject<IUsersData>(() => Console.WriteLine("User manager requested data."));
            var person = GetUser(name);

            if (person != null)
                return person;

            person = new User()
            {
                Address = address,
                Name = name,
                Telephone = telephone
            };
            usersData.Users.Add(person);

            return person;
        }

        public User SetGuestUser(string name, string address, string telephone)
        {
            return new User()
            {
                Address = address,
                Name = name,
                Telephone = telephone
            };
        }

        public User GetUser(string name)
        {
            var userCache = cache.GetObject<IUsersData>(() => Console.WriteLine("User manager requested data."));

            return userCache.Users.FirstOrDefault(u => u.Name == name);
        }

        public void SaveUsersState()
        {
            dataSerializer.SerializeAndSave(usersData);
        }
    }
}
