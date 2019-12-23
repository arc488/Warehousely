using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Warehousely.ViewModels.CustomerViewModels
{
    public class AddCustomerViewModel
    {
        [Required, StringLength(30)]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, Phone]
        public string Phone { get; set; }
        [Required, StringLength(30, MinimumLength = 5, ErrorMessage = "Address has to be between 5 and 30 characters long")]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        [Required, StringLength(20, MinimumLength = 2, ErrorMessage = "City name has to be between 2 and 20 characters long")]
        public string City { get; set; }
        [Required, StringLength(2, MinimumLength = 10)]
        public string State { get; set; }
        [Required, StringLength(8, ErrorMessage = "Zipcode cannot exceed 8 characters")]
        public string Zip { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
    }
}
