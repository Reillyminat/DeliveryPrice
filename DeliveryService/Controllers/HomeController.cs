using AppliancesModel.Contracts;
using DeliveryService.BLL.Contracts;
using DeliveryServiceModel;
using DeliveryServiceModel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DeliveryService.API.Controllers
{
    [Route("mvc/Product")]
    public class HomeController : Controller
    {
        private readonly IAppliancesDistribution _productManager;
        private readonly ISupplierManager _supplierManager;

        public HomeController(IAppliancesDistribution productManager, ISupplierManager supplierManager)
        {
            _productManager = productManager;
            _supplierManager = supplierManager;
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
            ViewBag.Suppliers = _supplierManager.GetSuppliers().ToList();

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
            ViewBag.Suppliers = _supplierManager.GetSuppliers().ToList();
            return View();
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(ProductViewModel product, int[] selectedSuppliers)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            ViewBag.Suppliers = _supplierManager.GetSuppliers().ToList();
            product.Suppliers = _supplierManager.GetSuppliersByIds(selectedSuppliers);
            _productManager.AddGoods(new List<ProductViewModel> { product });
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Product product, int[] selectedSuppliers)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            ViewBag.Suppliers = _supplierManager.GetSuppliers().ToList();
            product.Suppliers = _supplierManager.GetSuppliersByIds(selectedSuppliers);
            _productManager.RefreshStock(product);
            return View(product);
        }

        [HttpGet]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            _productManager.DeleteProduct(id);
            return Index();
        }
    }
}
