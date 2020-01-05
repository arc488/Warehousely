using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.DAL.IRepositories;
using Warehousely.Models;

namespace Warehousely.DAL.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly AppDbContext _appDbContext;

        public OrderItemRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<OrderItem> AllOrderItems => throw new NotImplementedException();

        public OrderItem Create(OrderItem orderItem)
        {
            var addedOrderItem = _appDbContext.OrderItems.Add(orderItem);
            _appDbContext.SaveChanges();
            return addedOrderItem.Entity;
        }

        public void Delete(OrderItem orderItem)
        {
            throw new NotImplementedException();
        }

        public OrderItem GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(OrderItem orderItem)
        {
            _appDbContext.Entry(orderItem).State = EntityState.Modified;
            _appDbContext.SaveChanges();
        }
    }
}
