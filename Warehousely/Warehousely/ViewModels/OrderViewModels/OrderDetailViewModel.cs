using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.Models;

namespace Warehousely.ViewModels.OrderViewModels
{
    public class OrderDetailViewModel
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public List<OrderItemViewModel> OrderItems { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
