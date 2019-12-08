using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Warehousely.Models
{
    public class Product
    {
        [Key]
        [BindNever]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter product name")]
        [Display(Name = "Product name")]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [Display(Name = "Count")]
        [Required(ErrorMessage = "Please enter product amount")]
        [Range(0, 99, ErrorMessage = "Amount has to be 0-99")]
        public int? Count { get; set; }

        [Required(ErrorMessage = "Please select product size")]
        [Display(Name = "Size")]
        [StringLength(10, MinimumLength = 1)]
        public string Size { get; set; }

        [Required(ErrorMessage = "Please enter product price")]
        [Display(Name = "Price")]
        public decimal? Price { get; set; }
        
        [Display(Name = "Image String")]
        public string ImageString { get; set; }

        [Display(Name = "Image")]
        public ImageFile Image { get; set; }
    }
}
