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
    }
}
