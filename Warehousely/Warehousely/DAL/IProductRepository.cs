﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.Models;

namespace Warehousely.DAL
{
    public interface IProductRepository
    {
        void CreateProduct(Product product);
        IEnumerable<Product> AllProducts { get; }
    }
}