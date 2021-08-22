using DeliveryServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore5.Data
{
    public interface IUnitOfWork
    {
        void Save();
        IRepository<User> Users { get; }
        IRepository<Order> Orders { get; }
        IRepository<Supplier> Suppliers { get; }
        IRepository<Tariff> Tariffs { get; }
        IRepository<Carrier> Carriers { get; }
        IRepository<Product> Products { get; }
    }
}
