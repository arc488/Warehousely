using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.DAL.Repositories;
using Warehousely.Models;

namespace Warehousely.DAL
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public override IEnumerable<Order> GetAll()
        {
            var entries = _appDbContext.Orders
                    .Include(order => order.OrderItems)
                    .Include(order => order.Customer)
                    .ToList();
           
            return entries;
        }
        
        public override Order GetById(int id)
        {
            Order entry = _appDbContext.Orders
                           .Include(o => o.OrderItems)
                             .ThenInclude(i => i.Product)
                           .Include(o => o.Customer)
                           .First(o => o.OrderId == id);
            return entry;

        }

    }
}
