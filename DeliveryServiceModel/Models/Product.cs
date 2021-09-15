using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DeliveryServiceModel
{
    public class Product
    {
        public int Id { get; set; }

        public Category CategoryId { get; set; }

        [Required(ErrorMessage = "Undefined name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "String length should be in range 2 to 50 symbols")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Undefined amount")]
        [Range(0, 10000, ErrorMessage = "Unacceptable amount")]
        public int Amount { get; set; }

        [Range(0, 120, ErrorMessage = "Unacceptable amount")]
        public int GuaranteeInMonths { get; set; }

        [Range(0, 10, ErrorMessage = "Unacceptable amount")]
        public decimal HeightInMeters { get; set; }

        [Range(0, 10, ErrorMessage = "Unacceptable amount")]
        public decimal WidthInMeters { get; set; }

        [Range(0, 10, ErrorMessage = "Unacceptable amount")]
        public decimal DepthInMeters { get; set; }

        [Required(ErrorMessage = "Undefined price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Undefined producing country")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "String length should be in range 2 to 50 symbols")]
        public string ProducingCountry { get; set; }

        [Required]
        public ICollection<Supplier> Suppliers { get; set; }
    }
}
