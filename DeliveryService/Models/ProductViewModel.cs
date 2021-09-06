using DeliveryServiceModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.API.Models
{
    public class ProductViewModel
    {
        public Category CategoryId { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 50 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указано количество")]
        [Range(0, 10000, ErrorMessage = "Недопустимое количество")]
        public int Amount { get; set; }

        [Range(0, 120, ErrorMessage = "Недопустимое количество")]
        public int GuaranteeInMonths { get; set; }

        [Range(0, 10, ErrorMessage = "Недопустимое количество")]
        public decimal HeightInMeters { get; set; }

        [Range(0, 10, ErrorMessage = "Недопустимое количество")]
        public decimal WidthInMeters { get; set; }

        [Range(0, 10, ErrorMessage = "Недопустимое количество")]
        public decimal DepthInMeters { get; set; }

        [Required(ErrorMessage = "Не указана цена")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Не указана страна производства")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 50 символов")]
        public string ProducingCountry { get; set; }

        public ICollection<int> Suppliers { get; set; }
    }
}
