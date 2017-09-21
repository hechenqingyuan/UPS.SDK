using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.SDK.Street
{
    public partial class XAVRequestEntity
    {
        public XAVRequestEntity()
        {
            MaximumListSize = "10";
            Request = new JObject();
            Request.Add("RequestOption", "1");

            JObject TransactionReference = new JObject();
            TransactionReference.Add("CustomerContext", "");
            Request.Add("TransactionReference", TransactionReference);
        }

        public AddressKeyFormatEntity AddressKeyFormat { get; set; }

        public string MaximumListSize { get; set; }

        public JObject Request { get; set; }

    }
}
