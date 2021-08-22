using System.ComponentModel.DataAnnotations.Schema;
﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
