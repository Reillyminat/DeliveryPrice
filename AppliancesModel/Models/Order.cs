using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliancesModel.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public string Name { get; set; }

        public string Telephone { get; set; }

        public ICollection<Appliances> basket;

        public decimal Price { get; set; }

        public Order(int id, string address, string name, string telephone)
        {
            Id = id;
            Address = address;
            Name = name;
            Telephone = telephone;
            basket = new List<Appliances>();
            Price = 0;
        }
    }
}
