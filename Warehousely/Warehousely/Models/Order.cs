using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.DAL;

namespace Warehousely.Models
{
    public class Order : BaseEntity
    {
        public int OrderId { get; set; }
        public Customer Customer { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
