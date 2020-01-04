using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.Models;

namespace Warehousely.ViewModels.OrderViewModels
{
    public class OrderViewModel
    {
        public int Customer { get; set; }

        public List<OrderItemViewModel> OrderItems { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
    }
}
