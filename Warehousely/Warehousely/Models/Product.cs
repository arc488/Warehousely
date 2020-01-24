using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.DAL;

namespace Warehousely.Models
{
    public class Product : BaseEntity
    {
        [Key]
        public int ProductId { get; set; }

        public string Name { get; set; }

        public int? Count { get; set; }

        public Size Size { get; set; }

        public decimal? Price { get; set; }

        public ImageFile Image { get; set; }
    }
}
