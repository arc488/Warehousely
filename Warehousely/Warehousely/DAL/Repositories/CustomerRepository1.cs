using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.Models;

namespace Warehousely.DAL
{
    public class CustomerRepository1
    {
        private readonly AppDbContext _appDbContext;

        public CustomerRepository1(AppDbContext appDbContext)
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

        public void DeleteCustomer(Customer customer)
        {
            _appDbContext.Customers.Remove(customer);
            _appDbContext.SaveChanges();
        }

        public Customer GetById(int id)
        {
            var customer = _appDbContext.Customers
                           .Include(a => a.Address)
                           .FirstOrDefault<Customer>(c => c.CustomerId == id);
            return customer;
        }

        public void UpdateCustomer(Customer customer)
        {
            _appDbContext.Entry(customer).State = EntityState.Modified;
            _appDbContext.SaveChanges();
        }
    }
}
