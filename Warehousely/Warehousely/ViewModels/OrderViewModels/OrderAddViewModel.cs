using Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.Models;

namespace Warehousely.ViewModels.OrderViewModels
{
    public class OrderAddViewModel
    {
        public int Customer { get; set; }

        public List<OrderItemViewModel> OrderItems { get; set; }
        public IEnumerable<Customer> Customers { get; set; }

        [DisplayName("Delivery Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DateIsTodayOrFuture]
        public DateTime DeliveryDate { get; set; }

    }
}
