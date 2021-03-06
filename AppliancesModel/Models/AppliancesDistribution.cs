using AppliancesModel.Contracts;
using DeliveryServiceModel;
using DeliveryServiceModel.Models;
using EFCore5.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace AppliancesModel
{
    public class AppliancesDistribution : IAppliancesDistribution
    {
        private readonly IRepository<Product> _productRepository;

        private readonly IDataSerialization _dataSerializer;

        private readonly ICacheable _cache;

        private readonly IUnitOfWork _unitOfWork;

        public AppliancesDistribution(IRepository<Product> productContext, IDataSerialization serializer, ICacheable cacheProvider, IConverterService converterProvider, IUnitOfWork unitOfWork)
        {
            _productRepository = productContext ?? throw new ArgumentNullException(nameof(productContext));
            _dataSerializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
            _cache = cacheProvider ?? throw new ArgumentNullException(nameof(cacheProvider));
            converterProvider.GetExchengesRateAsync(new CancellationToken());
            _cache.SetInstance(_productRepository.GetAll().ToList());
            _unitOfWork = unitOfWork;
        }

        public Product RefreshStock(Product product)
        {
            var productToUpdate = _productRepository.Get(product.Id);
            productToUpdate.GuaranteeInMonths = product.GuaranteeInMonths;
            productToUpdate.Amount = product.Amount;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.DepthInMeters = product.DepthInMeters;
            productToUpdate.WidthInMeters = product.WidthInMeters;
            productToUpdate.HeightInMeters = product.HeightInMeters;
            productToUpdate.Name = product.Name;
            productToUpdate.Suppliers = product.Suppliers;
            productToUpdate.ProducingCountry = product.ProducingCountry;
            _productRepository.Update(productToUpdate);
            _unitOfWork.Save();

            return productToUpdate;
        }

        public Product CheckGoodsExistance(string applianceName)
        {
            return _productRepository.GetAll().FirstOrDefault(x => x.Name == applianceName);
        }

        public void AddGoods(IEnumerable<ProductViewModel> products)
        {
            foreach (var product in products)
            {
                _productRepository.Create(_unitOfWork.ConvertViewModel(product));
            }

            _unitOfWork.Save();
        }

        public void DeleteProduct(int id)
        {
            _productRepository.Delete(id);
            _unitOfWork.Save();
        }

        public IEnumerable<Product> GetStock()
        {
            var stockNumbersDetail = _cache.GetObject<List<Product>>(() => Console.WriteLine("Appliance distributor requested data."));

            return stockNumbersDetail;
        }

        public Product GetProduct(int id)
        {
            var stockNumbersDetail = _cache.GetObject<List<Product>>(() => Console.WriteLine("Appliance distributor requested data."));

            return stockNumbersDetail.FirstOrDefault(i=>i.Id==id);
        }

        public void SaveStockState()
        {
            _dataSerializer.SerializeAndSave(_productRepository);
        }
    }
}
