﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<IdentityUser> _userManager;

        public CustomerController(ICustomerRepository customerRepository,
                                  IAddressRepository addressRepository,
                                  IMapper mapper,
                                  UserManager<IdentityUser> userManager)
        {
            _customerRepository = customerRepository;
            _addressRepository = addressRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public IActionResult List()
        {
            var customers = _customerRepository.AllCustomers;
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
            _customerRepository.CreateCustomer(customer);
            return RedirectToAction("List");
        }

        public IActionResult Detail(int id)
        {
            var viewModel = new CustumerViewModel();
            var customer = _customerRepository.GetById(id);
            viewModel = _mapper.Map<CustumerViewModel>(customer);
            _mapper.Map(customer.Address, viewModel);
            viewModel.IsReadonly = true;

            return View(viewModel);
        }

        public IActionResult Edit(int id)
        {
            var customer = _customerRepository.GetById(id);
            var viewModel = _mapper.Map<CustumerViewModel>(customer);
            _mapper.Map(customer.Address, viewModel);

            viewModel.IsReadonly = false;

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CustumerViewModel model)
        {
            if (!ModelState.IsValid) return View();

            var customer = _mapper.Map<Customer>(model);
            var address = _mapper.Map<Address>(model);

            _customerRepository.UpdateCustomer(customer);
            _addressRepository.UpdateAddress(address);

            return RedirectToAction("List");
        }
    }
}