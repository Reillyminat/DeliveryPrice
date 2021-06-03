using AppliancesModel.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliancesModel.Models
{
    public class UserData:IUserData
    {
        public ICollection<User> Users { get; set; }
    }
}
