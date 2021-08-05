using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryServiceModel
{
    [Table("Suppliers")]
    public class Supplier
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Region { get; set; }

        public ICollection<Product> Stock { get; set; }
    }
}
