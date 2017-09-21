using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.SDK.Street
{
    public partial class StreeResultEntity
    {
        public StreeResultEntity() { }

        public string AddressLine { get; set; }

        public string PoliticalDivision2 { get; set; }

        public string PoliticalDivision1 { get; set; }

        public string PostcodePrimaryLow { get; set; }

        public string PostcodeExtendedLow { get; set; }

        public string Region { get; set; }

        public string CountryCode { get; set; }
    }
}
