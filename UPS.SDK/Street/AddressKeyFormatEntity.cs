using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.SDK.Street
{
    public partial class AddressKeyFormatEntity
    {
        public AddressKeyFormatEntity() { }

        public string ConsigneeName { get; set; }

        public string BuildingName { get; set; }

        public string AddressLine { get; set; }

        public string PoliticalDivision2 { get; set; }

        public string PoliticalDivision1 { get; set; }

        public string PostcodePrimaryLow { get; set; }

        public string CountryCode { get; set; }
    }
}
