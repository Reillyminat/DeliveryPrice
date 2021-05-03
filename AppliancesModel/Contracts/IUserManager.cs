using AppliancesModel.Models;
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

        User AddUser(string name, string address, string telephone);

        User SetGuestUser(string name, string address, string telephone);
    }
}
