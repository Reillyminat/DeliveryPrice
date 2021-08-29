using AppliancesModel.Models;
using DeliveryServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliancesModel.Contracts
{
    public interface IUserManager
    {
        User GetUser(User user);

        IEnumerable<User> GetAllUsers();

        User AddUser(User user);

        User EditUser(User user);

        void DeleteUser(User user);

        User SetGuestUser(string name, string address, string telephone);

        void SaveUsersState();
    }
}
