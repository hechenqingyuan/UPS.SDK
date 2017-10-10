using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.SDK.Rate
{
    public partial class RateShipmentEntity
    {
        public RateShipmentEntity()
        {
            //Service = new JObject();
            //Service.Add("Code", "03");
            //Service.Add("Description", "ServiceCodeDescription");

            ShipmentRatingOptions = new JObject();
            ShipmentRatingOptions.Add("NegotiatedRatesIndicator","");
        }

        public ShipAddressEntity Shipper { get; set; }

        public ShipAddressEntity ShipTo { get; set; }

        public ShipAddressEntity ShipFrom { get; set; }

        public RatePackageEntity Package { get; set; }

        public JObject ShipmentRatingOptions { get; set; }

        public RateServiceEntity Service { get; set; }


        //public JObject Service { get; set; }

        /// <summary>
        /// 参考服务编码
        /// </summary>
        //public string ServiceCode { get; set; }
    }
}
