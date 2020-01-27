using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.DAL;

namespace Warehousely.Models
{
    public class Address : BaseEntity
    {
        public int AddressId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public State State { get; set; }
        public int Zip { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }

        
    }
}
