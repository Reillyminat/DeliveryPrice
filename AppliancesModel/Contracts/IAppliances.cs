using DeliveryServiceModel;
using System.Collections.Generic;

namespace AppliancesModel
{
    public interface IAppliances
    {
        ICollection<Product> Stock { get; set; }

        int Id { get; set; }
    }
}
