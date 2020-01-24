using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.DAL.Repositories;
using Warehousely.Models;

namespace Warehousely.DAL
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public override IEnumerable<Customer> GetAll()
        {
            var entries = _appDbContext.Customers
                           .Include(a => a.Address)
                           .ToList();

            return entries;
        }

        public override Customer GetById(int id)
        {
            Customer entry = _appDbContext.Customers
                              .Include(c => c.Address)
                              .First(c => c.CustomerId == id);
            return entry;
        }
    }
}
