using AppliancesModel.Contracts;
using System;

namespace AppliancesModel.Models
{
    public class UserManager : IUserManager
    {
        private readonly IUsersData usersData;

        private readonly IDataSerialization dataSerializer;

        public UserManager(IUsersData users, IDataSerialization serializer)
        {
            try
            {
                usersData = users;
                dataSerializer = serializer;
            }
            catch (NullReferenceException ex)
            {
                throw new Exception("UserData instance is null.", ex);
            }
        }

        public User AddUser(string name, string address, string telephone)
        {
            var person = GetUser(name);
            if (usersData.Users.Contains(person))
                return person;
            person = new User();
            person.Name = name;
            person.Address = address;
            person.Telephone = telephone;
            usersData.Users.Add(person);
            return person;
        }

        public User SetGuestUser(string name, string address, string telephone)
        {
            var person = new User();
            person.Name = name;
            person.Address = address;
            person.Telephone = telephone;
            return person;
        }

        public User GetUser(string name)
        {
            foreach (User person in usersData.Users)
                if (person.Name == name)
                    return person;
            return null;
        }

        public void SaveUsersState()
        {
            dataSerializer.SerializeToFile(usersData);
        }
    }
}
