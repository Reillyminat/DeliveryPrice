﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceModel
{
    public class Carrier
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Tariff> Tarrifs { get; set; }
    }
}
