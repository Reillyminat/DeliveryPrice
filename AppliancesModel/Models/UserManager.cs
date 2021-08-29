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
        private readonly IRepository<User> _userRepository;

        private readonly IDataSerialization dataSerializer;

        private readonly ICacheable _cache;

        public UserManager(IRepository<User> userContext, IDataSerialization serializer, ICacheable cacheProvider)
        {
            dataSerializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
            _cache = cacheProvider ?? throw new ArgumentNullException(nameof(cacheProvider));
            _userRepository = userContext ?? throw new ArgumentNullException(nameof(userContext));
            _cache.SetInstance(_userRepository.GetAll().ToList());
        }

        public User AddUser(User user)
        {
            var person = GetUser(user);

            if (person != null)
                return person;

            _userRepository.Create(user);

            return person;
        }

        public User EditUser(User user)
        {
            var foundedUser = _userRepository.Get(user.Id);
            foundedUser.Address = user.Address;
            foundedUser.Name = user.Name;
            foundedUser.Telephone = user.Telephone;
            foundedUser.Partonimic = user.Partonimic;
            foundedUser.SurName = user.SurName;
            _userRepository.Update(foundedUser);

            return foundedUser;
        }

        public void DeleteUser(User user)
        {
            _userRepository.Delete(user.Id);
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

        public User GetUser(User user)
        {
            var userCache = _cache.GetObject<List<User>>(() => Console.WriteLine("User manager requested data."));

            return userCache.FirstOrDefault(u => u.Id == user.Id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            var userCache = _cache.GetObject<IEnumerable<User>>(() => Console.WriteLine("User manager requested data."));

            return userCache;
        }

        public void SaveUsersState()
        {
            dataSerializer.SerializeAndSave(_userRepository);
        }

    }
}
