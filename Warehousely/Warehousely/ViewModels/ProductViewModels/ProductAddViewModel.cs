using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Warehousely.ViewModels
{
    public class ProductAddViewModel
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please enter product name")]
        [Display(Name = "Name")]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [Display(Name = "Count")]
        [Required(ErrorMessage = "Please enter product amount")]
        [Range(0, 99, ErrorMessage = "Amount has to be 0-99")]
        public int? Count { get; set; }

        [Required(ErrorMessage = "Please select product size")]
        [Display(Name = "Size")]
        public int Size { get; set; }

        [Required(ErrorMessage = "Please enter product price")]
        [Display(Name = "Price")]
        public decimal? Price { get; set; }

        [Display(Name = "Image")]
        public byte[] Image { get; set; }
        public IEnumerable<Size> AllSizes { get; set; }
    }
}
