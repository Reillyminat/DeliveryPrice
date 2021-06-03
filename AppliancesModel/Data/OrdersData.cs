using AppliancesModel.Contracts;
using AppliancesModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliancesModel.Data
{
    public class OrdersData:IOrdersData
    {
        public ICollection<Order> Order { get; set; }
    }
}
