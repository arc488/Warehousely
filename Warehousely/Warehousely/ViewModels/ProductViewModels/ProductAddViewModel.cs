using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.Models;

namespace Warehousely.ViewModels
{
    public class ProductAddViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Count { get; set; }
        public int Size { get; set; }
        public decimal? Price { get; set; }
        public byte[] Image { get; set; }
        public IEnumerable<Size> AllSizes { get; set; }
    }
}
