using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.SDK.TNT
{
    public partial class TNTAddressEntity
    {
        public TNTAddressEntity() { }

        public TNTAddressItem Address { get; set; }
    }

    public partial class TNTAddressItem
    {
        public TNTAddressItem() { }

        public string StateProvinceCode { get; set; }

        public string CountryCode { get; set; }

        public string PostalCode { get; set; }
    }
}
