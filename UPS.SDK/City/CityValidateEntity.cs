using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.SDK.City
{
    public partial class CityValidateEntity
    {
        public CityValidateEntity()
        {
            Request = new JObject();
            Request.Add("RequestAction", "AV");

            JObject TransactionReference = new JObject();
            TransactionReference.Add("CustomerContext", "");
            Request.Add("TransactionReference", TransactionReference);
        }

        public CityAddressEntity Address { get; set; }

        public JObject Request { get; set; }

    }
}
