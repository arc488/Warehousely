using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.DAL;
using Warehousely.ViewModels.OrderViewModels;

namespace Warehousely.Controllers.Helpers
{   
    public class OrderHelpers
    {

        public OrderAddViewModel GenerateViewModel(IProductRepository productRepository,
                            ICustomerRepository customerRepository,
                            IMapper mapper)
        {
            var products = productRepository.GetAll();
            var orderItems = new List<OrderItemViewModel>();

            foreach (var product in products)
            {
                var orderItem = mapper.Map<OrderItemViewModel>(product);
                orderItem.Product = product;
                orderItems.Add(orderItem);
            }

            var viewModel = new OrderAddViewModel
            {
                Customers = customerRepository.GetAll().ToList(),
                OrderItems = orderItems,
                DeliveryDate = DateTime.Today.AddDays(1)
            };
            
            return viewModel;
        }
    }
}
