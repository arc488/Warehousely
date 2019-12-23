using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.DAL.IRepositories;
using Warehousely.Models;

namespace Warehousely.DAL.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext _appDbContext;

        public AddressRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Address> AllAddresses => _appDbContext.Addresses;

        public Address CreateAddress(Address address)
        {
            _appDbContext.Addresses.Add(address);
            _appDbContext.SaveChanges();
            return address;
        }

        public Address GetById(int id)
        {
            var address = _appDbContext.Addresses.FirstOrDefault<Address>(a => a.Id == id);
            return address;
        }
    }
}
