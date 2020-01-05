﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.Models;

namespace Warehousely.ViewModels
{
    public class ProductEditViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int? Count { get; set; }
        public int SizeId { get; set; }
        public decimal? Price { get; set; }
        public byte[] ImageContent { get; set; }
        public IEnumerable<Size> AllSizes { get; set; }
    }
}
