using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceModel
{
    public class Supplier
    {
        public string Name { get; set; }

        public string Region { get; set; }

        public ICollection<Appliance> Stock { get; set; }
    }
}
