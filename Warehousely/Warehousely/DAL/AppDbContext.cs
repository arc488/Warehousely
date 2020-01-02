using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Warehousely.Models;

namespace Warehousely.DAL
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ImageFile> ImageFiles { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).DateModified = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).DateCreated = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Customer>()
            //    .HasOne(a => a.Address)
            //    .WithOne(a => a.Customer)
            //    .HasForeignKey<Address>(c => c.Id);

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
