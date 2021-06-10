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
            Order = ordersInfo;
        }

        public ICollection<Order> Order { get; set; }

        public int Id { get; set; }
    }
}
