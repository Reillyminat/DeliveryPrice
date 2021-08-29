using AppliancesModel.Contracts;
using DeliveryServiceModel;
using EFCore5.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace DeliveryService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IAppliancesDistribution _productManager;
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(ILogger<ProductController> logger, IAppliancesDistribution productManager, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _productManager = productManager;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productManager.GetStock();
        }

        [HttpPut]
        public void Put(Product product)
        {
            _productManager.RefreshStock(product);
            _unitOfWork.Save();
        }

        [HttpPost]
        public void Post(IEnumerable<Product> products)
        {
            _productManager.AddGoods(products);
            _unitOfWork.Save();
        }

        [HttpDelete]
        public void Delete(Product product)
        {
            _productManager.DeleteProduct(product);
            _unitOfWork.Save();
        }
    }
}
