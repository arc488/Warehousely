using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.Models;

namespace Warehousely.DAL
{
    public interface IOrderRepository
    {
        IEnumerable<Order> AllOrders { get; } 
        Order GetById(int id);
        void Create(Order order);
        void Update(Order order);
    }
}
