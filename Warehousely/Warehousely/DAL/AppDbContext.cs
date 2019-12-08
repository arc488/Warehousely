using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Warehousely.Models;

namespace Warehousely.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ImageFile> ImageFiles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
                .HasData(new Product
                {
                    Count = 5,
                    Id = 1,
                    ImageString = "NoString",
                    Name = "FirstWine",
                    Price = 10.88M,
                    Size = "1L"
                });

        }
    }
}
