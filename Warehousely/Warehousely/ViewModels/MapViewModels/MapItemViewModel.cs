using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.Models;

namespace Warehousely.ViewModels.MapViewModels
{
    public class MapItemViewModel
    {
        public bool IsReadonly { get; set; }

        public int CustomerId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int AddressId { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public State State { get; set; }

        public string Zip { get; set; }

        public double Lat { get; set; }

        public double Lng { get; set; }

        public IEnumerable<Order> Orders { get; set; }

        public string MapsContent { get; set; }
    }
}
