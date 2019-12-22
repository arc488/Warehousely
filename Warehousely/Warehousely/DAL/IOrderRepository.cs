using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.Models;

namespace Warehousely.DAL
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrders();
        Order GetById(int id);
        void CreateOrder(Order Order);
    }
}
