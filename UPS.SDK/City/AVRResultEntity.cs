using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.SDK.City
{
    public partial class AVRResultEntity
    {
        public AVRResultEntity() { }

        public string Rank { get; set; }

        public string Quality { get; set; }

        public string PostalCodeLowEnd { get; set; }

        public string PostalCodeHighEnd { get; set; }

        public string City { get; set; }

        public string StateProvinceCode { get; set; }
    }
}
