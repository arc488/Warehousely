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
                                               .Include(o => o.OrderItems)
                                               .Include(c => c.Customer);


        public Order GetById(int id)
        {
            var order = _appDbContext.Orders.FirstOrDefault<Order>(o => o.OrderId == id);
            return order;
        }
    }
}
