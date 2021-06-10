using AppliancesModel.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliancesModel.Models
{
    public class UsersData:IUserData
    {
        public UsersData(ICollection<User> usersInfo)
        {
            Users = usersInfo;
        }

        public ICollection<User> Users { get; set; }
    }
}
