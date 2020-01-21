using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.Models;

namespace Warehousely.DAL
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> AllCustomers { get;  }
        //IEnumerable<Customer> 
        Customer GetById(int id);
        void CreateCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
    }
}
