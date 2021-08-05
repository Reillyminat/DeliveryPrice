using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceModel
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string Address { get; set; }

        public string FullName { get; set; }

        public string Telephone { get; set; }
    }
}
