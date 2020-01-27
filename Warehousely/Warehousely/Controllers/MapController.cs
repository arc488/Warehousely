using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehousely.DAL;
using Warehousely.Models;
using Warehousely.ViewModels.MapViewModels;

namespace Warehousely.Controllers
{
    public class MapController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public MapController(ICustomerRepository customerRepository,
                             IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public IActionResult Map()
        {
            var customers = _customerRepository.GetAll();
            var mapItems = _mapper.Map<IEnumerable<Customer>, IEnumerable<MapItemViewModel>>(customers);
            return View(mapItems);
        }
    }
}