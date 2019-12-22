using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehousely.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IdentityUser CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
