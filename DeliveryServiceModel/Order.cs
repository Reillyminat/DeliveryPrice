using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace DeliveryServiceModel
{
    public class Order
    {
        [Key]
        public int Id { get; init; }

        public User User { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();

        public decimal Price { get; set; }

        public DateTime TimeOfOrdering { get; set; }

        public DateTime TimeOfTaking { get; set; }
    }
}
