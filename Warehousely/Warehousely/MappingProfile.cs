﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.Models;
using Warehousely.ViewModels;
using Warehousely.ViewModels.CustomerViewModels;
using Warehousely.ViewModels.MapViewModels;
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

            CreateMap<CustomerViewModel, Customer>();
            CreateMap<Customer, CustomerViewModel>().IncludeMembers(c => c.Address);

            CreateMap<CustomerViewModel, Address>();
            CreateMap<Address, CustomerViewModel>();

            CreateMap<Product, OrderItemViewModel>();
            CreateMap<OrderItemViewModel, Product>();

            CreateMap<OrderDetailViewModel, Order>();
            CreateMap<Order, OrderDetailViewModel>();


            // Order

            CreateMap<OrderItemViewModel, OrderItem>();
            CreateMap<OrderItem, OrderItemViewModel>();

            CreateMap<Product, OrderItem>().ReverseMap();

            CreateMap<OrderDetailViewModel, Order>();
            CreateMap<Order, OrderDetailViewModel>();

            CreateMap<OrderAddViewModel, Order>()
                .ForMember(o => o.Customer, cfg => cfg.Ignore());
            CreateMap<Order, OrderAddViewModel>()
                .ForMember(o => o.Customer, cfg => cfg.Ignore());

            //ImageFile
            CreateMap<IFormFile, ImageFile>().ReverseMap();

            //Map
            CreateMap<Customer, MapItemViewModel>().IncludeMembers(c => c.Address).ReverseMap();
            CreateMap<Address, MapItemViewModel>().ReverseMap();
        }
    }
}
