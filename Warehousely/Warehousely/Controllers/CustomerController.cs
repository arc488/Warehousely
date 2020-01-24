﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Warehousely.Controllers.Helpers;
using Warehousely.DAL;
using Warehousely.DAL.IRepositories;
using Warehousely.Models;
using Warehousely.ViewModels.CustomerViewModels;

namespace Warehousely.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerRepository customerRepository,
                                  IAddressRepository addressRepository,
                                  IOrderRepository orderRepository,
                                  IMapper mapper)
        {
            _customerRepository = customerRepository;
            _addressRepository = addressRepository;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public IActionResult List()
        {
            var customers = _customerRepository.GetAll();
            return View(customers);
        }


        public IActionResult Add()
        {
            var model = new CustumerViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(CustumerViewModel model)
        {
            if (!ModelState.IsValid) return View();

            var customer = _mapper.Map<Customer>(model);
            var address = _mapper.Map<Address>(model);

            var addressEntry = _addressRepository.CreateAddress(address);
            if (addressEntry != null) customer.Address = addressEntry;

            _customerRepository.Add(customer);

            return RedirectToAction("List");
        }

        public IActionResult Detail(int id)
        {
            var viewModel = new CustumerViewModel();
            viewModel.IsReadonly = true;

            var customer = _customerRepository.GetById(id);

            viewModel = _mapper.Map<CustumerViewModel>(customer);
            _mapper.Map(customer.Address, viewModel);

            viewModel.Orders = _orderRepository.GetAll()
                              .Where(order => order.Customer.CustomerId == id)
                              .ToList();

            return View(viewModel);
        }

        public IActionResult Edit(int id)
        {
            return View(GenerateModel(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CustumerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(GenerateModel(model.CustomerId));
            }

            var customer = _mapper.Map<Customer>(model);
            var address = _mapper.Map<Address>(model);

            _customerRepository.Update(customer);
            _addressRepository.UpdateAddress(address);

            return RedirectToAction("List");
        }

        public CustumerViewModel GenerateModel(int id) {
            var viewModel = new CustomerHelpers().GenerateCustomerViewModel(_mapper, _customerRepository, id);
            return viewModel;
        }
    }
}