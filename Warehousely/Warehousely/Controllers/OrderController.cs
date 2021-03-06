﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.Controllers.Helpers;
using Warehousely.DAL;
using Warehousely.DAL.IRepositories;
using Warehousely.Models;
using Warehousely.ViewModels.OrderViewModels;

namespace Warehousely.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public OrderController(IOrderRepository orderRepository,
                               IOrderItemRepository orderItemRepository,
                               ICustomerRepository customerRepository,
                               IProductRepository productRepository,
                               IMapper mapper)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public IActionResult List()
        {
            var viewModel = new OrderListViewModel
            {
                Orders = _orderRepository.GetAll()
            };
            return View(viewModel);
        }

        public IActionResult Add()
        {
            var viewModel = GenerateModel();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(OrderAddViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
               return View(GenerateModel());
            };

            var order = _mapper.Map<OrderAddViewModel, Order>(viewModel);
            order.Customer = _customerRepository.GetById(viewModel.Customer);

            order.OrderItems = _mapper.Map<List<OrderItemViewModel>, List<OrderItem>>(viewModel.OrderItems);
            order.OrderItems.ForEach(o => o.Product = _productRepository.GetById(o.ProductId));

            _orderRepository.Add(order);

            return RedirectToAction("List");
        }

        public IActionResult Detail(int id)
        {
            var order = _orderRepository.GetById(id);
            var viewModel = _mapper.Map<Order, OrderDetailViewModel>(order);
            return View(viewModel);
        }

        public IActionResult Edit(int id)
        {
            var order = _orderRepository.GetById(id);
            var viewModel = _mapper.Map<OrderDetailViewModel>(order);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(OrderDetailViewModel viewModel)
        {
            var order = _mapper.Map<Order>(viewModel);
            //if this isn't done EF creates new products on save
            order.OrderItems.ForEach(o => o.Product = _productRepository.GetById(o.ProductId));
            _orderRepository.Update(order);

            return RedirectToAction("Detail", new { id = viewModel.OrderId });
        }

        public OrderAddViewModel GenerateModel()
        {
            var viewModel = new OrderHelpers().GenerateViewModel(_productRepository, _customerRepository, _mapper);
            return viewModel;
        }
    }
}
