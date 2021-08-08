using System.Collections.Generic;

namespace DeliveryServiceModel
{
    public class Supplier
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Region { get; set; }

        public ICollection<Product> Stock { get; set; }
    }
}
