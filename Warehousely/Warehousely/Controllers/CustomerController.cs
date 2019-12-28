﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehousely.DAL;
using Warehousely.DAL.IRepositories;
using Warehousely.Models;
using Warehousely.ViewModels.CustomerViewModels;

namespace Warehousely.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerRepository customerRepository,
                                  IAddressRepository addressRepository,
                                  IMapper mapper)
        {
            _customerRepository = customerRepository;
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public IActionResult List()
        {
            var customers = _customerRepository.AllCustomers;
            return View(customers);
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Add()
        {
            var model = new AddCustomerViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(AddCustomerViewModel model)
        {
            if (!ModelState.IsValid) return View();

            var customer = _mapper.Map<Customer>(model);
            var address = _mapper.Map<Address>(model);

            var addressEntry = _addressRepository.CreateAddress(address);
            if (addressEntry != null) customer.Address = addressEntry;
            _customerRepository.CreateCustomer(customer);
            return RedirectToAction("List");
        }

        public IActionResult Detail(int id)
        {
            var viewModel = new CustomerDetailViewModel();
            var customer = _customerRepository.GetById(id);
            viewModel = _mapper.Map<CustomerDetailViewModel>(customer);
            _mapper.Map(customer.Address, viewModel);
            viewModel.IsReadonly = true;

            return View(viewModel);
        }
    }
}