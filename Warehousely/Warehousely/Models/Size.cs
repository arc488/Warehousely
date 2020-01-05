﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.DAL;

namespace Warehousely.Models
{
    public class Size : BaseEntity
    {
        [Key]
        public int SizeId { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
