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
        private readonly ISizeRepository _sizeRepository;
        private readonly IImageFileRepository _imageFileRepository;

        public ProductController(
            IProductRepository productRepository,
            ISizeRepository sizeRepository,
            IImageFileRepository imageFileRepository)
        {
            _productRepository = productRepository;
            _sizeRepository = sizeRepository;
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
                Size = product.Size.Name,
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
            var productEditViewModel = new ProductEditViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Count = product.Count,
                Size = product.Size.Id,
                Image = product.Image.Content,
                AllSizes = _sizeRepository.AllSizes
            };

            return View(productEditViewModel);
        }

        [HttpPost]
        public IActionResult Edit(ProductEditViewModel model, IFormFile file)
        {
            if (!ModelState.IsValid) return View(_productRepository.GetById(model.Id));

            var product = new Product
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                Count = model.Count,
                Size = _sizeRepository.GetById(model.Size)
            };

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
            var model = new ProductAddViewModel();
            model.AllSizes = _sizeRepository.AllSizes;
            return View(model);
        }

        [HttpPost]
        public IActionResult AddProduct(ProductAddViewModel model, IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var imageFileId = _imageFileRepository.CreateImage(file);

            var product = new Product
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                Count = model.Count,
                Size = _sizeRepository.GetById(model.Size),
                Image = _imageFileRepository.GetById(imageFileId)
        };

            _productRepository.CreateProduct(product);
            ViewBag.Message = "Product Added Successfully";
            return RedirectToAction("AddProduct");
        }

        public IActionResult RemoveAll()
        {
            _productRepository.RemoveAll();
            return RedirectToAction("List");
        }
    }
}