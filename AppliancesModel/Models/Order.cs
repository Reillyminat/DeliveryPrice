using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliancesModel.Models
{
    public class Order
    {
        public int Id { get; init; }

        public string Address { get; init; }

        public string Name { get; init; }

        public string Telephone { get; set; }

        public ICollection<Appliance> Basket { get; set; }

        public decimal Price { get; set; }
    }
}
