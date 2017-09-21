using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.SDK.PublishRateShipment
{
    public class PShipmentEntity
    {
        public PShipmentEntity()
        {
            Description = "";

            PaymentInformation = new JObject();
            JObject ShipmentCharge = new JObject();
            ShipmentCharge.Add("Type", "01");
            JObject BillShipper = new JObject();
            BillShipper.Add("AccountNumber", ConfigurationManager.AppSettings["UPS_AccountNumber"]);
            ShipmentCharge.Add("BillShipper", BillShipper);
            PaymentInformation.Add("ShipmentCharge", ShipmentCharge);

            Service = new JObject();
            Service.Add("Code", "01");
            Service.Add("Description", "Express");
        }

        public string Description { get; set; }

        public PShipperAddressEntity Shipper { get; set; }

        public PShipperAddressEntity ShipTo { get; set; }

        public PShipperAddressEntity ShipFrom { get; set; }

        public JObject PaymentInformation { get; set; }

        public JObject Service { get; set; }

        public PPackageEntity Package { get; set; }

        
    }
}
