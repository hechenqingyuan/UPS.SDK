using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.SDK.PublishRateShipment
{
    public partial class PAddressEntity
    {
        public PAddressEntity() {  }

        public string AddressLine { get; set; }

        public string City { get; set; }

        public string StateProvinceCode { get; set; }

        public string PostalCode { get; set; }

        public string CountryCode { get; set; }

    }
}
