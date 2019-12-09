using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Warehousely.DAL;
using Warehousely.Models;
using Warehousely.ViewModels;

namespace Warehousely.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IImageFileRepository _imageFileRepository;

        public ProductController(IProductRepository productRepository, IImageFileRepository imageFileRepository)
        {
            _productRepository = productRepository;
            _imageFileRepository = imageFileRepository;
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
                ImageString = product.ImageString,
                Image = product.Image.Content
            };

            return View(productDetailViewModel);
        }

        public IActionResult DeleteProduct(int id)
        {
            var product = _productRepository.GetById(id);
            if (product.Image != null) _imageFileRepository.DeleteImageFile(product.Image);
            if (product != null) _productRepository.DeleteProduct(product);
            ViewBag.Message = "Product deleted successfully";
            return RedirectToAction("List");
        }

        public IActionResult Edit(int id)
        {
            var product = _productRepository.GetById(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product, IFormFile file)
        {
            if (!ModelState.IsValid) return View(_productRepository.GetById(product.Id));

            if (file != null)
            {
                var imageFileId = _imageFileRepository.CreateImage(file);
                product.Image = _imageFileRepository.GetById(imageFileId);
            }

            _productRepository.UpdateProduct(product);
            return RedirectToAction("Edit", product.Id);
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product, IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var imageFileId = _imageFileRepository.CreateImage(file);

            product.Image = _imageFileRepository.GetById(imageFileId);

            _productRepository.CreateProduct(product);
            ViewBag.Message = "Product Added Successfully";
            return View();
        }
    }
}