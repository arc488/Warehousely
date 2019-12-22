using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.Models;
using Warehousely.ViewModels;
using Warehousely.ViewModels.CustomerViewModels;

namespace Warehousely
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<ProductAddViewModel, Product> ();
            CreateMap<Product, ProductAddViewModel > ();
            CreateMap<AddCustomerViewModel, Customer> ();
            CreateMap<Customer, AddCustomerViewModel > ();
        }
    }
}
