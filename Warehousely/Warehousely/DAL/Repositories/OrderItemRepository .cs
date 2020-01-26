using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.DAL.IRepositories;
using Warehousely.Models;

namespace Warehousely.DAL.Repositories
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public void AddRange(IEnumerable<OrderItem> entities)
        {
            _appDbContext.AddRange(entities);
            _appDbContext.SaveChanges();
        }

        //OrderItem IOrderItemRepository.Add(OrderItem entity)
        //{
        //    _appDbContext.Add(entity);
        //    _appDbContext.SaveChanges();
        //    return entity;
        //}
    }
}
