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
            CreateMap<ProductAddViewModel, Product>().ForMember(p => p.Image, cfg => cfg.Ignore())
                                                     .ForMember(p => p.Size, cfg => cfg.Ignore());
            CreateMap<Product, ProductAddViewModel > ().ForMember(p => p.Image, cfg => cfg.Ignore())
                                                       .ForMember(p => p.Size, cfg => cfg.Ignore());
            CreateMap<AddCustomerViewModel, Customer> ();
            CreateMap<Customer, AddCustomerViewModel > ();

            CreateMap<Product, ProductDetailViewModel>();

            CreateMap<Product, ProductEditViewModel>().ForMember(p => p.AllSizes, cfg => cfg.Ignore());

            CreateMap<ProductEditViewModel, Product>().ForMember(p => p.Size, cfg => cfg.Ignore())
                                                      .ForMember(p => p.Image, cfg => cfg.Ignore());
            CreateMap<AddCustomerViewModel, Customer>();
            CreateMap<AddCustomerViewModel, Address>();
        }
    }
}
