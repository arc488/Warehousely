using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehousely.ViewModels
{
    public class ProductDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Count { get; set; }
        public string Size { get; set; }
        public decimal? Price { get; set; }
        public string ImageString { get; set; }
        public string Image { get; set; }
    }
}
