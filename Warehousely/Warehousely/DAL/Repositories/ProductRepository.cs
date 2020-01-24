using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.DAL.Repositories;
using Warehousely.Models;

namespace Warehousely.DAL
{
    public class ProductRepository : Repository<Product>, IProductRepository 
    {
        public ProductRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            
        }

        public override IEnumerable<Product> GetAll()
        {
            var entries = _appDbContext.Products
                           .Include(p => p.Size);

            return entries;
        }

        public override Product GetById(int id)
        {
            Product entry = _appDbContext.Products
                             .Include(p => p.Size)
                             .Include(p => p.Image)
                             .First(p => p.ProductId == id);

            return entry;
        }
    }
}
