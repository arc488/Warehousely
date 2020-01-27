using Geocoding;
using Geocoding.Google;
using Geocoding.Microsoft;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using Warehousely.Models;

namespace Warehousely.Controllers.Helpers
{
    public class MapHelpers
    {
        private readonly string _apiKey;

        public MapHelpers()
        {
            _apiKey = "AtRkaqdHNhM6763DTQzDhGNPmQFbts_k1Q2LysHL7J_4_rhxlvC8cpjpQ_bhQIsT";
        }

        public Dictionary<string, double> GetLatLong(Models.Address a)
        {

            string address = string.Format("{0}+{1}+{2}+{3}+{4}", a.Address1, a.Address2, a.City, a.State.ToString(), a.Zip);

            IGeocoder geocoder = new BingMapsGeocoder(_apiKey);
            IEnumerable<Geocoding.Address> addresses = geocoder.Geocode(address);

            var results = new Dictionary<string, double>();
            results.Add("lat", addresses.First().Coordinates.Latitude);
            results.Add("lng", addresses.First().Coordinates.Longitude);

            return results;

        }

       
    }
}
