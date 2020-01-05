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
            _appDbContext.Products.Add(product);
            _appDbContext.SaveChanges();
        }

        public Product GetById(int id)
        {
            return _appDbContext.Products
                .Include(i => i.Image)
                .Include(s => s.Size)
                .FirstOrDefault<Product>(p => p.ProductId == id);
        }

        public void DeleteProduct(Product product)
        {
            _appDbContext.Products.Remove(product);
            _appDbContext.SaveChanges();

        }

        public void UpdateProduct(Product product)
        {
            _appDbContext.Entry(product).State = EntityState.Modified;
            _appDbContext.SaveChanges();
        }

        public void RemoveAll()
        {
            foreach (var entry in _appDbContext.Products)
            {
                _appDbContext.Products.Remove(entry);
            }
            _appDbContext.SaveChanges();
        }

        public IEnumerable<Product> AllProducts => _appDbContext.Products;

    }
}
