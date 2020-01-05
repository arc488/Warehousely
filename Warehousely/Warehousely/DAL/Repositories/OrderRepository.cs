using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.Models;

namespace Warehousely.DAL
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;

        public OrderRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Create(Order order)
        {
            _appDbContext.Orders.Add(order);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<Order> AllOrders => _appDbContext.Orders
                                               .Include(order => order.OrderItems)
                                               .Include(order => order.Customer);


        public Order GetById(int id)
        {
            var order = _appDbContext.Orders
                        .Include(order => order.OrderItems)
                            .ThenInclude(item => item.Product)
                        .Include(order => order.Customer)
                        .FirstOrDefault<Order>(order => order.OrderId == id);
            return order;
        }

        public void Update(Order order)
        {
            _appDbContext.Entry(order).State = EntityState.Modified;
            _appDbContext.SaveChanges();
        }
    }
}
