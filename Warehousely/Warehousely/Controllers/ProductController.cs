using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Warehousely.DAL;
using Warehousely.Models;
using Warehousely.ViewModels;

namespace Warehousely.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ISizeRepository _sizeRepository;
        private readonly IImageFileRepository _imageFileRepository;
        private readonly IMapper _mapper;

        #region Constructor
        public ProductController(
            IProductRepository productRepository,
            ISizeRepository sizeRepository,
            IImageFileRepository imageFileRepository,
            IMapper mapper
        )
        {
            _productRepository = productRepository;
            _sizeRepository = sizeRepository;
            _imageFileRepository = imageFileRepository;
            _mapper = mapper;
        } 
        #endregion

        public IActionResult List()
        {
            var products = _productRepository.AllProducts;

            return View(products);
        }

        public IActionResult Detail(int id)
        {
            var product = _productRepository.GetById(id);

            if (product == null) return NotFound();

            var viewModel = new ProductDetailViewModel();
            viewModel = _mapper.Map<ProductDetailViewModel>(product);

            return View(viewModel);
        }

        [ValidateAntiForgeryToken]
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

            var viewModel = new ProductEditViewModel();

            viewModel = _mapper.Map<ProductEditViewModel>(product);
            viewModel.AllSizes = _sizeRepository.AllSizes;

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductEditViewModel model, IFormFile file)
        {
            if (!ModelState.IsValid) return View(_productRepository.GetById(model.Id));

            var product = new Product();

            product = _mapper.Map<Product>(model);
            product.Size = _sizeRepository.GetById(model.SizeId);

            if (file != null)
            {
                var imageFileId = _imageFileRepository.CreateImage(file);
                product.Image = _imageFileRepository.GetById(imageFileId);
            }

            _productRepository.UpdateProduct(product);
            return RedirectToAction("Edit", product.Id);
        }

        public IActionResult Add()
        {
            var model = new ProductAddViewModel();
            model.AllSizes = _sizeRepository.AllSizes;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ProductAddViewModel model, IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var imageFileId = _imageFileRepository.CreateImage(file);
            var product = _mapper.Map<Product>(model);

            product.Size = _sizeRepository.GetById(model.Size);
            product.Image = _imageFileRepository.GetById(imageFileId);


            _productRepository.CreateProduct(product);
            ViewBag.Message = "Product Added Successfully";
            return RedirectToAction("Add");
        }

    }
}