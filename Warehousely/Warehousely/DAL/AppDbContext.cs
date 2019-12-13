﻿using System;
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
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ImageFile> ImageFiles { get; set; }
        public DbSet<Size> Sizes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Size>()
                .HasData(new Size
                {
                    Id = 1,
                    Name = "375 ml Demi"
                });
            modelBuilder.Entity<Size>()
                .HasData(new Size
                {
                    Id = 2,
                    Name = "750 ml Standard"
                });
            modelBuilder.Entity<Size>()
                .HasData(new Size
                {
                    Id = 3,
                    Name = "1.5 L Magnum"
                });
        }
    }
}
