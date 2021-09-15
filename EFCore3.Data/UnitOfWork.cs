using DeliveryServiceModel;
using DeliveryServiceModel.Models;
using System;

namespace EFCore5.Data
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private DataContext db;
        private IRepository<User> userRepository;
        private IRepository<Order> orderRepository;
        private IRepository<Supplier> supplierRepository;
        private IRepository<Tariff> tariffRepository;
        private IRepository<Carrier> carrierRepository;
        private IRepository<Product> productRepository;

        public UnitOfWork(DataContext context,
                    IRepository<User> usersData,
                    IRepository<Order> ordersData,
                    IRepository<Supplier> suppliersData,
                    IRepository<Tariff> tariffsData,
                    IRepository<Carrier> carriersData,
                    IRepository<Product> productsData)
        {
            db = context;
            userRepository = usersData;
            orderRepository = ordersData;
            supplierRepository = suppliersData;
            tariffRepository = tariffsData;
            carrierRepository = carriersData;
            productRepository = productsData;
        }

        public IRepository<User> Users
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

        public IRepository<Order> Orders
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

        public IRepository<Supplier> Suppliers
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

        public IRepository<Tariff> Tariffs
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

        public IRepository<Carrier> Carriers
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

        public IRepository<Product> Products
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

        public Product ConvertViewModel(ProductViewModel product)
        {
            var convertedProduct = new Product
            {
                Name = product.Name,
                CategoryId = product.CategoryId,
                GuaranteeInMonths = product.GuaranteeInMonths,
                WidthInMeters = product.WidthInMeters,
                DepthInMeters = product.DepthInMeters,
                HeightInMeters = product.HeightInMeters,
                Amount = product.Amount,
                Price = product.Price,
                ProducingCountry = product.ProducingCountry,
                Suppliers=product.Suppliers
            };
            return convertedProduct;
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
