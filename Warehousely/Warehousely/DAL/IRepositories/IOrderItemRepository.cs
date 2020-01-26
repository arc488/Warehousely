using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.Models;

namespace Warehousely.DAL.IRepositories
{
    public interface IOrderItemRepository : IRepository<OrderItem>
    {
        void AddRange(IEnumerable<OrderItem> entities);
        //OrderItem Add(OrderItem entity);
    }
}
