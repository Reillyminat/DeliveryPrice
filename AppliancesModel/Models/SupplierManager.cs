using DeliveryService.BLL.Contracts;
using DeliveryServiceModel;
using EFCore5.Data;
using System.Collections.Generic;
using System.Linq;

namespace DeliveryService.BLL.Models
{
    public class SupplierManager : ISupplierManager
    {
        private readonly IRepository<Supplier> _supplierRepository;

        private readonly IUnitOfWork _unitOfWork;

        public SupplierManager(IUnitOfWork unitOfWork, IRepository<Supplier> supplierContext)
        {
            _supplierRepository = supplierContext;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Supplier> GetSuppliers()
        {
            return _supplierRepository.GetAll();
        }

        public ICollection<Supplier> GetSuppliersByIds(int[] supplierIds)
        {
            return _supplierRepository.GetAll().ToList().Where(s => supplierIds.Any(b => b == s.Id)).ToList();
        }
    }
}
