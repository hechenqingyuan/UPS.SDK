using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.SDK.LBRecovery
{
    public class LabelRecoveryRequestEntity
    {
        public LabelRecoveryRequestEntity()
        {
            Translate = new TranslateEntity();
            LabelSpecification = new JObject();

            JObject LabelImageFormat = new JObject();
            LabelImageFormat.Add("Code", "GIF");
            LabelSpecification.Add("LabelImageFormat", LabelImageFormat);
            LabelSpecification.Add("HTTPUserAgent", "Mozilla/4.5");
        }

        public JObject LabelSpecification { get; set; }

        public TranslateEntity Translate { get; set; }

        public string TrackingNumber { get; set; }
    }
}
