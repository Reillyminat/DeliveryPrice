using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceModel
{
    public class Appliances
    {
        public ICollection<Product> Stock { get; set; }
    }
}
