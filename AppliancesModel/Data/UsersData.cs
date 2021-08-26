using AppliancesModel.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliancesModel.Models
{
    public class UsersData:IUsersData
    {
        public UsersData(ICollection<DeliveryServiceModel.User> usersInfo)
        {
            Users = usersInfo;
        }
        
        public ICollection<DeliveryServiceModel.User> Users { get; set; }
    }
}
