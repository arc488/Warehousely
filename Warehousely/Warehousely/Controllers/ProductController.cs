using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Warehousely.DAL;

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
            Debug.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
            foreach (var product in products)
            {
                Debug.WriteLine(product.Name);
            }
            return View(products);
        }
    }
}