using DeliveryServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.BLL.Contracts
{
    public interface ISupplierManager
    {
        IEnumerable<Supplier> GetSuppliers();
        ICollection<Supplier> GetSuppliersByIds(int[] supplierIds);
    }
}
