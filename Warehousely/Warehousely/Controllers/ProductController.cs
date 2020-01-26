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
            var products = _productRepository.GetAll();

            return View(products);
        }

        public IActionResult Detail(int id)
        {
            var product = _productRepository.GetById(id);
            var viewModel = _mapper.Map<ProductDetailViewModel>(product);

            return View(viewModel);
        }

        [ValidateAntiForgeryToken]
        public IActionResult DeleteProduct(int id)
        {
            //var product = _productRepository.GetById(id);
            //if (product.Image != null) _imageFileRepository.DeleteImageFile(product.Image);
            //if (product != null) _productRepository.Delete(product);
            return RedirectToAction("List");
        }

        public IActionResult Edit(int id)
        {
            var product = _productRepository.GetById(id);

            var viewModel = _mapper.Map<Product, ProductEditViewModel>(product);
            viewModel.AllSizes = _sizeRepository.GetAll();

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductEditViewModel model, IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Edit", new { id = model.ProductId });
            }

            Product product = _mapper.Map<Product>(model);
            product.Size = _sizeRepository.GetById(model.SizeId);

            if (file != null)
            {
                ImageFile imageFile = AddImage(file);
                product.Image = imageFile;
            }

            _productRepository.Update(product);

            return RedirectToAction("Edit", product.ProductId);
        }



        public IActionResult Add()
        {
            var viewModel = new ProductAddViewModel { AllSizes = _sizeRepository.GetAll() };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ProductAddViewModel viewModel, IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Product product = _mapper.Map<Product>(viewModel);
            product.Size = _sizeRepository.GetById(viewModel.Size);

            if (file != null)
            {
                ImageFile imageFile = AddImage(file);
                product.Image = imageFile;
            }
            _productRepository.Add(product);

            return RedirectToAction("List");
        }

        private ImageFile AddImage(IFormFile file)
        {
            var imageFile = _mapper.Map<IFormFile, ImageFile>(file);
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                imageFile.Content = ms.ToArray();
            }

            _imageFileRepository.Add(imageFile);

            return imageFile;
        }
    }
}