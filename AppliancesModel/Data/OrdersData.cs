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
        public OrdersData(ICollection<Order> ordersInfo)
        {
            Orders = ordersInfo;
        }

        public ICollection<Order> Orders { get; set; }

        public int Id { get; set; }
    }
}
