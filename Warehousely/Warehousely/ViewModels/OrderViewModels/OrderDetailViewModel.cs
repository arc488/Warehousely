using Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.DAL;
using Warehousely.Models;

namespace Warehousely.ViewModels.OrderViewModels
{
    public class OrderDetailViewModel : BaseEntity
    {
        public int OrderId { get; set; }
        public Customer Customer { get; set; }
        public List<OrderItemViewModel> OrderItems { get; set; }

        [Required]
        [DisplayName("Delivery Date")]
        [DataType(DataType.Date)]
        [DateIsTodayOrFuture]
        public DateTime DeliveryDate { get; set; }


    }
}
