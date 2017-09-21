using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.SDK.PublishRateShipment
{
    public partial class PShipperAddressEntity
    {
        public PShipperAddressEntity() { }

        public string Name { get; set; }

        public string AttentionName { get; set; }

        public string TaxIdentificationNumber { get; set; }

        public PPhoneEntity Phone { get; set; }

        public string ShipperNumber { get; set; }

        public string FaxNumber { get; set; }

        public PAddressEntity Address { get; set; }
    }
}
