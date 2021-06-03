using AppliancesModel.Contracts;
using System.Linq;

namespace AppliancesModel.Models
{
    public class UserManager : IUserManager
    {
        private readonly IUserData users;

        public UserManager(IUserData usersData)
        {
            users = usersData;
        }

        public User AddUser(string name, string address, string telephone)
        {
            var person = GetUser(name);

            if (users.Users.Contains(person))
                return person;

            return new User() { Name = name, Address = address, Telephone = telephone };
        }

        public User SetGuestUser(string name, string address, string telephone)
        {
            return new User() { Name = name, Address = address, Telephone = telephone };
        }

        public User GetUser(string name)
        {
            return users.Users.FirstOrDefault(n => n.Name == name);
        }
    }
}
