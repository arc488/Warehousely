using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.Models;
using Warehousely.ViewModels;
using Warehousely.ViewModels.CustomerViewModels;
using Warehousely.ViewModels.OrderViewModels;

namespace Warehousely
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<ProductAddViewModel, Product>().ForMember(p => p.Image, cfg => cfg.Ignore())
                                                     .ForMember(p => p.Size, cfg => cfg.Ignore());
            CreateMap<Product, ProductAddViewModel >().ForMember(p => p.Image, cfg => cfg.Ignore())
                                                       .ForMember(p => p.Size, cfg => cfg.Ignore());

            CreateMap<Product, ProductDetailViewModel>();

            CreateMap<Product, ProductEditViewModel>().ForMember(p => p.AllSizes, cfg => cfg.Ignore());

            CreateMap<ProductEditViewModel, Product>().ForMember(p => p.Size, cfg => cfg.Ignore())
                                                      .ForMember(p => p.Image, cfg => cfg.Ignore());

            CreateMap<CustumerViewModel, Customer>();
            CreateMap<Customer, CustumerViewModel>().IncludeMembers(c => c.Address);

            CreateMap<CustumerViewModel, Address>();
            CreateMap<Address, CustumerViewModel>();

            CreateMap<Product, OrderItemViewModel>();
            CreateMap<OrderItemViewModel, Product>();

            CreateMap<OrderItemViewModel, OrderItem>();
            CreateMap<OrderItem, OrderItemViewModel>();

            CreateMap<OrderDetailViewModel, Order>();
            CreateMap<Order, OrderDetailViewModel>();
        }
    }
}
