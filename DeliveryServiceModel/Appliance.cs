using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceModel
{
    public class Appliance
    {
        public Categories Type { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Amount { get; set; }

        public int Guarantee { get; set; }

        public Dimensions Dimensions { get; set; }

        public decimal Price { get; set; }

        public string ProducingCountry { get; set; }
    }
}
