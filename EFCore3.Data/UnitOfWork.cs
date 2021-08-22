using System;

namespace EFCore5.Data
{
    public class UnitOfWork : IDisposable
    {
        private readonly DataContext db;
        private UserRepository userRepository;
        private OrderRepository orderRepository;
        private SupplierRepository supplierRepository;
        private TariffRepository tariffRepository;
        private CarrierRepository carrierRepository;
        private ProductRepository productRepository;

        public UnitOfWork(DataContext context)
        {
            db = context;
        }

        public UserRepository Users
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(db);
                }
                return userRepository;
            }
        }

        public OrderRepository Orders
        {
            get
            {
                if (orderRepository == null)
                {
                    orderRepository = new OrderRepository(db);
                }
                return orderRepository;
            }
        }

        public SupplierRepository Suppliers
        {
            get
            {
                if (supplierRepository == null)
                {
                    supplierRepository = new SupplierRepository(db);
                }
                return supplierRepository;
            }
        }

        public TariffRepository Tariffs
        {
            get
            {
                if (tariffRepository == null)
                {
                    tariffRepository = new TariffRepository(db);
                }
                return tariffRepository;
            }
        }

        public CarrierRepository Carriers
        {
            get
            {
                if (carrierRepository == null)
                {
                    carrierRepository = new CarrierRepository(db);
                }
                return carrierRepository;
            }
        }

        public ProductRepository Products
        {
            get
            {
                if (productRepository == null)
                {
                    productRepository = new ProductRepository(db);
                }
                return productRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
