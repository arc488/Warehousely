using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.Models;

namespace Warehousely.DAL.IRepositories
{
    public interface IOrderItemRepository
    {
        OrderItem Create(OrderItem orderItem);
        OrderItem GetById(int id);
        IEnumerable<OrderItem> AllOrderItems { get; }
        void Update(OrderItem orderItem);
        void Delete(OrderItem orderItem);
    }
}
