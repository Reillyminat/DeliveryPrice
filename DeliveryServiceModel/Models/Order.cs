using System;
using System.Collections.Generic;

namespace DeliveryServiceModel
{
    public class Order
    {
        public int Id { get; init; }

        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();

        public decimal Price { get; set; }

        public DateTime TimeOfOrdering { get; set; }

        public DateTime TimeOfTaking { get; set; }

        public int CarrierId { get; set; }

        public Carrier Carrier { get; set; }

        public int SupplierId { get; set; }

        public Supplier Supplier { get; set; }

        public DeliveryStatus StatusId { get; set; }
    }
}
