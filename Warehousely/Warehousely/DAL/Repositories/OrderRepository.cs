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

        public void CreateOrder(Order Order)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> AllOrders => _appDbContext.Orders;


        public Order GetById(int id)
        {
            var order = _appDbContext.Orders.FirstOrDefault<Order>(o => o.Id == id);
            return order;
        }
    }
}
