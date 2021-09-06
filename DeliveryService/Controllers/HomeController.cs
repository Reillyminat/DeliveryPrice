using AppliancesModel.Contracts;
using DeliveryService.API.Models;
using DeliveryServiceModel;
using EFCore5.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DeliveryService.API.Controllers
{
    [Route("mvc/Product")]
    public class HomeController : Controller
    {
        private readonly IAppliancesDistribution _productManager;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IAppliancesDistribution productManager, IUnitOfWork unitOfWork)
        {
            _productManager = productManager;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var stock = _productManager.GetStock();
            return View("Index", stock);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _productManager.GetProduct(id);
            if (product is not null)
            {
                return View("Edit", product);
            }
            else
            {
                return View("Error", id);
            }
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(ProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            _productManager.AddGoods(new List<Product> { ConvertViewModel(product) });
            _unitOfWork.Save();
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            _productManager.RefreshStock(product);
            _unitOfWork.Save();
            return View(product);
        }

        [HttpGet]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            _productManager.DeleteProduct(id);
            _unitOfWork.Save();
            return Index();
        }

        private Product ConvertViewModel(ProductViewModel product)
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
                ProducingCountry = product.ProducingCountry
            };
            return convertedProduct;
        }
    }
}
