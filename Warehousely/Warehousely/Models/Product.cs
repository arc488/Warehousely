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
        public int Id { get; set; }
        [Display(Name = "Product name")]
        public string Name { get; set; }
        [Display(Name = "Count")]
        public int Count { get; set; }
        [Display(Name = "Size")]
        public string Size { get; set; }
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        [Display(Name = "Image")]
        public string ImageString { get; set; }
    }
}
