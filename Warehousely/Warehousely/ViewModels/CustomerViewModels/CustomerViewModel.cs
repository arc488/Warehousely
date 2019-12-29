using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.Models;

namespace Warehousely.ViewModels.CustomerViewModels
{
    public class CustumerViewModel
    {
        public bool IsReadonly { get; set; }

        public int Id { get; set; }

        [Required, StringLength(30)]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, Phone]
        public string Phone { get; set; }

        public int AddressId { get; set; }

        [Required, StringLength(30, MinimumLength = 5, ErrorMessage = "Address must be between 5 and 30 characters long")]
        [Display(Name = "Street Address")]
        public string Address1 { get; set; }

        [Display(Name = "Street Address")]
        public string Address2 { get; set; }

        [Required, StringLength(20, MinimumLength = 2, ErrorMessage = "City name must be between 2 and 20 characters long")]
        public string City { get; set; }

        [Required, StringLength(10, MinimumLength = 2)]
        public string State { get; set; }

        [Required, StringLength(8, MinimumLength = 5)]
        public string Zip { get; set; }

        public IEnumerable<Order> Orders { get; set; }
    }
}
