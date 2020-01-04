using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.DAL;
using Warehousely.DAL.IRepositories;
using Warehousely.Models;
using Warehousely.ViewModels.OrderViewModels;

namespace Warehousely.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public OrderController(IOrderRepository orderRepository,
                               IOrderItemRepository orderItemRepository,
                               ICustomerRepository customerRepository,
                               IProductRepository productRepository,
                               IMapper mapper)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public IActionResult List()
        {
            var viewModel = new OrderListViewModel
            {
                Orders = _orderRepository.AllOrders
            };

            return View(viewModel);
        }

        public IActionResult Add()
        {
            var products = _productRepository.AllProducts.ToList();
            var orderItems = new List<OrderItemViewModel>();

            foreach (var product in products)
            {
                var orderItem = _mapper.Map<OrderItemViewModel>(product);
                orderItems.Add(orderItem);
            }

            var viewModel = new OrderViewModel
            {
                Customers = _customerRepository.AllCustomers.ToList(),
                OrderItems = orderItems
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(OrderViewModel viewModel)
        {
            var order = new Order { OrderItems = new List<OrderItem>() };
            var orderedProdcuts = viewModel.OrderItems.Where(c => c.Quantity != 0);

            foreach (var product in orderedProdcuts)
            {
                var orderItem = new OrderItem
                {
                    ProductId = product.Id,
                    Product = _productRepository.GetById(product.Id),
                    Quantity = product.Quantity
                };
                var createdOrder = _orderItemRepository.Create(orderItem);
                order.OrderItems.Add(createdOrder);
            }

            order.Customer = _customerRepository.GetById(viewModel.Customer);

            _orderRepository.Create(order);

            return RedirectToAction("List");
        }
    }
}
