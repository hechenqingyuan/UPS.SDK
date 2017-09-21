using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.SDK.PublishRateShipment
{
    public class PPackageEntity
    {
        public PPackageEntity()
        {
            Packaging = new JObject();
            Packaging.Add("Code", "02");
            Packaging.Add("Description", "");
        }

        public string Description { get; set; }

        public JObject Packaging { get; set; }

        public PDimensionsEntity Dimensions { get; set; }

        public PPackageWeightEntity PackageWeight { get; set; }
    }
}
