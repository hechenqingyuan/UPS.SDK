using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.SDK.City
{
    public partial class CityAddressEntity
    {
        public CityAddressEntity() { }

        public string City { get; set; }

        public string StateProvinceCode { get; set; }

        public string PostalCode { get; set; }
    }
}
