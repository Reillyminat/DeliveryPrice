using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceModel
{
    public class Product
    {
        public int Id { get; set; }

        public Category CategoryId { get; set; }

        public string Name { get; set; }

        public int Amount { get; set; }

        public int GuaranteeInMonths { get; set; }

        public decimal HeightInMeters { get; set; }

        public decimal WidthInMeters { get; set; }

        public decimal DepthInMeters { get; set; }

        public decimal Price { get; set; }

        public string ProducingCountry { get; set; }
    }
}
