﻿using AppliancesModel.Contracts;
using DeliveryServiceModel;
using DeliveryServiceModel.Models;
using EFCore5.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DeliveryService.API.Controllers
{
    [Route("mvc/Product")]
    public class HomeController : Controller
    {
        private readonly IAppliancesDistribution _productManager;

        public HomeController(IAppliancesDistribution productManager)
        {
            _productManager = productManager;
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

            _productManager.AddGoods(new List<ProductViewModel> { product });
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