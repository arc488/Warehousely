using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.Models;

namespace Warehousely.ViewModels.CustomerViewModels
{
    public class CustomerDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public Address Address { get; set; }

        public IEnumerable<Order> Orders { get; set; }
    }
}
