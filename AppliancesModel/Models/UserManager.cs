using AppliancesModel.Contracts;
using DeliveryServiceModel;
using EFCore5.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppliancesModel.Models
{
    public class UserManager : IUserManager
    {
        private readonly IRepository<User> userRepository;

        private readonly IDataSerialization dataSerializer;

        private readonly ICacheable cache;

        public UserManager(IRepository<User> userContext, IDataSerialization serializer, ICacheable cacheProvider)
        {
            dataSerializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
            cache = cacheProvider ?? throw new ArgumentNullException(nameof(cacheProvider));
            userRepository = userContext ?? throw new ArgumentNullException(nameof(userContext));
        }

        public User AddUser(User user)
        {
            var person = GetUser(user.Name);

            if (person != null)
                return person;

            person = new User()
            {
                Address = user.Address,
                Name = user.Name,
                Telephone = user.Telephone,
                Partonimic = user.Partonimic,
                SurName = user.SurName
            };
            userRepository.Create(person);

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
            var userCache = cache.GetObject<List<User>>(() => Console.WriteLine("User manager requested data."));

            return userCache.FirstOrDefault(u => u.Name == name);
        }

        public IEnumerable<User> GetAllUsers()
        {
            var userCache = cache.GetObject<IEnumerable<User>>(() => Console.WriteLine("User manager requested data."));

            return userCache;
        }

        public void SaveUsersState()
        {
            dataSerializer.SerializeAndSave(userRepository);
        }
    }
}
