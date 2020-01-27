using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.Controllers.Helpers;
using Warehousely.Models;

namespace Warehousely.Helpers
{
    public class AddressHelpers
    {
        public Address AddCoordinates(Address address)
        {
            var coordinates = new MapHelpers().GetLatLong(address);
            address.Lat = coordinates["lat"];
            address.Lng = coordinates["lng"];
            return address;
        }
    }
}
