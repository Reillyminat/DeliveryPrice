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
        User GetUser(string name);

        IEnumerable<User> GetAllUsers();

        User AddUser(User user);

        User SetGuestUser(string name, string address, string telephone);

        void SaveUsersState();
    }
}
