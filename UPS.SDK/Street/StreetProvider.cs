using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.SDK.Street
{
    public partial class StreetProvider
    {
        public XAVRequestEntity XAVRequest { get; set; }

        private string ApiName = "/rest/XAV";

        public StreeResultEntity Execute()
        {
            string returnValue = string.Empty;
            string UPS_URL_RATE = ConfigurationManager.AppSettings["UPS_URL_RATE"];
            string UPS_UserName = ConfigurationManager.AppSettings["UPS_UserName"];
            string UPS_Password = ConfigurationManager.AppSettings["UPS_Password"];
            string UPS_Token = ConfigurationManager.AppSettings["UPS_Token"];

            JObject root = new JObject();

            JObject UPSSecurity = new JObject();
            JObject UsernameToken = new JObject();
            UsernameToken.Add("Username", UPS_UserName);
            UsernameToken.Add("Password", UPS_Password);
            JObject ServiceAccessToken = new JObject();
            ServiceAccessToken.Add("AccessLicenseNumber", UPS_Token);
            UPSSecurity.Add("UsernameToken", UsernameToken);
            UPSSecurity.Add("ServiceAccessToken", ServiceAccessToken);
            root.Add("UPSSecurity", UPSSecurity);

            root.Add("XAVRequest", JObject.Parse(JsonHelper.SerializeObject(XAVRequest)));
            returnValue = root.ToString();
            ITopClient client = new TopClientDefault();
            string content = client.Execute(this.ApiName, root);

            StreeResultEntity result = null;
            if (string.IsNullOrEmpty(content))
            {
                return result;
            }
            JObject jResult = JObject.Parse(content);
            JObject XAVResponse = jResult["XAVResponse"] as JObject;
            if (XAVResponse == null)
            {
                return result;
            }
            JObject Candidate= XAVResponse["Candidate"] as JObject;
            if (Candidate == null)
            {
                return result;
            }
            JObject AddressKeyFormat = Candidate["AddressKeyFormat"] as JObject;
            if (AddressKeyFormat != null)
            {
                result = new StreeResultEntity();
                result.AddressLine = AddressKeyFormat["AddressLine"].Value<string>();
                result.PoliticalDivision2 = AddressKeyFormat["PoliticalDivision2"].Value<string>();
                result.PoliticalDivision1 = AddressKeyFormat["PoliticalDivision1"].Value<string>();
                result.PostcodePrimaryLow = AddressKeyFormat["PostcodePrimaryLow"].Value<string>();
                result.PostcodeExtendedLow = AddressKeyFormat["PostcodeExtendedLow"].Value<string>();
                result.Region = AddressKeyFormat["Region"].Value<string>();
                result.CountryCode = AddressKeyFormat["CountryCode"].Value<string>();
            }
            return result;
        }
    }
}
