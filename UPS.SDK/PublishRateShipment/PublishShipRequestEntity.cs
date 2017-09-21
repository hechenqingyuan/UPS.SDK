using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.SDK.PublishRateShipment
{
    public partial class PublishShipRequestEntity
    {
        public PublishShipRequestEntity()
        {
            LabelSpecification = new JObject();
            LabelSpecification.Add("HTTPUserAgent", "Mozilla/4.5");
            JObject LabelImageFormat = new JObject();
            LabelImageFormat.Add("Code", "GIF");
            LabelImageFormat.Add("Description", "GIF");
            LabelSpecification.Add("LabelImageFormat", LabelImageFormat);

            Request = new JObject();
            Request.Add("RequestOption", "validate");
            JObject TransactionReference = new JObject();
            TransactionReference.Add("CustomerContext", "");
            Request.Add("TransactionReference", TransactionReference);
        }

        public JObject Request { get; set; }

        public PShipmentEntity Shipment { get; set; }

        public JObject LabelSpecification { get; set; }
    }
}
