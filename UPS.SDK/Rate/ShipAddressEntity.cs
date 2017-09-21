using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.SDK.Rate
{
    public partial class ShipAddressEntity
    {
        public ShipAddressEntity() { }

        public string Name { get; set; }

        public string ShipperNumber { get; set; }

        public AddressItemEntity Address { get; set; }
    }

    public partial class AddressItemEntity
    {
        public AddressItemEntity() { }

        public string City { get; set; }

        public string StateProvinceCode { get; set; }

        public string PostalCode { get; set; }

        public string CountryCode { get; set; }
       
        public List<string> AddressLine { get; set; }
    }
}
