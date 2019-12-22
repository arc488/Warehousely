using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehousely.DAL;
using Warehousely.Models;
using Warehousely.ViewModels.CustomerViewModels;

namespace Warehousely.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerRepository customerRepository,
                                  IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public IActionResult AddCustomer()
        {
            var model = new AddCustomerViewModel();
            return View(model);
        }

        public IActionResult List()
        {
            var customers = _customerRepository.AllCustomers;
            return View(customers);
        }

        [HttpPost]
        public IActionResult AddCustomer(AddCustomerViewModel model)
        {
            var customer = _mapper.Map<Customer>(model);
            _customerRepository.CreateCustomer(customer);
            return RedirectToAction("List");
        }
    }
}