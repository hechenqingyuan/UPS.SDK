using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.SDK.TNT
{
    public partial class TNTTimeInTransitEntity
    {
        public TNTTimeInTransitEntity()
        {
            Request = new JObject();
            Request.Add("RequestOption", "TNT");

            JObject TransactionReference = new JObject();
            TransactionReference.Add("CustomerContext", "CustomerContext");
            TransactionReference.Add("TransactionIdentifier", "");
            Request.Add("TransactionReference", TransactionReference);

            Pickup = new JObject();
            Pickup.Add("Date", DateTime.Now.ToString("yyyyMMdd"));
        }

        public JObject Request { get; set; }

        public TNTAddressEntity ShipFrom { get; set; }

        public TNTAddressEntity ShipTo { get; set; }

        public TNTShipmentWeightEntity ShipmentWeight { get; set; }

        public JObject Pickup { get; set; }

        public string MaximumListSize { get; set; }
    }
}
