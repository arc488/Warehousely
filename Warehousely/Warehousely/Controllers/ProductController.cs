using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Warehousely.DAL;
using Warehousely.Models;
using Warehousely.ViewModels;

namespace Warehousely.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public IActionResult List()
        {
            var products = _productRepository.AllProducts;

            return View(products);
        }

        public IActionResult Detail(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null) return NotFound();
            var productDetailViewModel = new ProductDetailViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Count = product.Count,
                Price = product.Price,
                Size = product.Size,
                ImageString = product.ImageString
            };

            return View(productDetailViewModel);
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _productRepository.CreateProduct(product);
            ViewBag.Message = "Product Added Successfully";
            return View();
        }
    }
}