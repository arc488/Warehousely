using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Warehousely
{
    public class ProductViewModel
    {
        public IEnumerable<Product> Products { get; set; }
    }
}
