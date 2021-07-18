using System;
using System.Collections.Generic;

namespace DeliveryServiceModel
{
    public class Order
    {
        public int Id { get; init; }

        public User User { get; set; }

        public ICollection<Appliance> Basket { get; set; }

        public decimal Price { get; set; }

        public DateTime TimeOfOrdering { get; set; }

        public DateTime TimeOfTaking { get; set; }
    }
}
