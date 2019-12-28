using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.Models;

namespace Warehousely.DAL
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _appDbContext;

        public CustomerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Customer> AllCustomers => _appDbContext.Customers
                                                    .Include(a => a.Address);
        
        public void CreateCustomer(Customer customer)
        {
            _appDbContext.Customers.Add(customer);
            _appDbContext.SaveChanges();
        }

        public Customer GetById(int id)
        {
            var customer = _appDbContext.Customers.Include(a => a.Address).FirstOrDefault<Customer>(c => c.Id == id);
            return customer;
        }
    }
}
