using AppliancesModel.Contracts;
using DeliveryServiceModel;
using DeliveryServiceModel.Models;
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

        public ProductController(ILogger<ProductController> logger, IAppliancesDistribution productManager)
        {
            _logger = logger;
            _productManager = productManager;
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
        }

        [HttpPost]
        public void Post(IEnumerable<ProductViewModel> products)
        {
            _productManager.AddGoods(products);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _productManager.DeleteProduct(id);
        }
    }
}
