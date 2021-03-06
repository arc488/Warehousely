﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Warehousely.ViewModels
{
    public class ProductDetailViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int? Count { get; set; }
        public string SizeName { get; set; }
        public decimal? Price { get; set; }
        public byte[] ImageContent { get; set; }
    }
}
