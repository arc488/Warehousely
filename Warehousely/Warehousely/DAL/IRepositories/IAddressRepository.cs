using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.Models;

namespace Warehousely.DAL.IRepositories
{
    public interface IAddressRepository
    {
        IEnumerable<Address> AllAddresses { get; }
        Address GetById(int id);
        Address CreateAddress(Address address);
    }
}
