using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.SDK.Rate
{
    public partial class RatePackageEntity
    {
        public RatePackageEntity()
        {
            PackagingType = new JObject();
            PackagingType.Add("Code", "02");
            PackagingType.Add("Description", "Rate");
        }

        public JObject PackagingType { get; set; }

        public RateDimensionsEntity Dimensions { get; set; }

        public PackageWeightEntity PackageWeight { get; set; }

    }
}
