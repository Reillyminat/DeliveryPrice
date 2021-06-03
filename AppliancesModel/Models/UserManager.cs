using AppliancesModel.Contracts;
using System;

namespace AppliancesModel.Models
{
    public class UserManager : IUserManager
    {
        private readonly IUserData users;

        public UserManager(IUserData users)
        {
            try
            {
                this.users = users;
            }
            catch (NullReferenceException ex)
            {
                throw new Exception("UserData instance is null.", ex);
            }
        }

        public User AddUser(string name, string address, string telephone)
        {
            var person = GetUser(name);
            if (users.Users.Contains(person))
                return person;
            person = new User();
            person.Name = name;
            person.Address = address;
            person.Telephone = telephone;
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
            foreach (User person in users.Users)
                if (person.Name == name)
                    return person;
            return null;
        }
    }
}
