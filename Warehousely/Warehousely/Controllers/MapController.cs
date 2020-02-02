using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            foreach (var mapItem in mapItems)
            {  
                mapItem.MapsContent = String.Format(
                    //link to details
                    "<div class='infowindowlink'><a href='/Customer/Detail/{0}'>{1}</a></div>" + 
                    //address
                    "<div class='infowindowcontent'>{2} {3}</div>"
                    , mapItem.CustomerId, mapItem.Name, mapItem.Address1, mapItem.Address2);
            }
            return View(mapItems);
        }
    }
}