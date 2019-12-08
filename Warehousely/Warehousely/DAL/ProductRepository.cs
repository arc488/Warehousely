using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.Models;

namespace Warehousely.DAL
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            
        }

        public void CreateProduct(Product product)
        {
            Debug.WriteLine("Create product product id is: " + product.Image.Id);
            _appDbContext.Products.Add(product);
            _appDbContext.SaveChanges();
        }

        public Product GetById(int id)
        {
            return _appDbContext.Products.Include(i => i.Image).FirstOrDefault<Product>(p => p.Id == id);
        }

        public IEnumerable<Product> AllProducts => _appDbContext.Products;

    }
}
