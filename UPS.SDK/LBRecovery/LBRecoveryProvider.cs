using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.SDK.LBRecovery
{
    public partial class LBRecoveryProvider
    {
        public LBRecoveryProvider()
        {
        }

        private string ApiName = "/rest/LBRecovery ";

        public LabelRecoveryRequestEntity LabelRecoveryRequest { get; set; }

        public List<LBRecoverResultEntity> Execute(string ShipmentIdentificationNumber)
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

            root.Add("LabelRecoveryRequest", JObject.Parse(JsonHelper.SerializeObject(LabelRecoveryRequest)));

            returnValue = root.ToString();

            ITopClient client = new TopClientDefault();
            string content = client.Execute(this.ApiName, root);
            List<LBRecoverResultEntity> listResult = null;
            if (string.IsNullOrEmpty(content))
            {
                return listResult;
            }
            JObject jResult = JObject.Parse(content);
            JObject LabelRecoveryResponse = jResult["LabelRecoveryResponse"] as JObject;
            if (LabelRecoveryResponse == null)
            {
                return listResult;
            }
            JArray LabelResults = LabelRecoveryResponse["LabelResults"] as JArray;
            if (LabelResults == null)
            {
                return listResult;
            }

            foreach (JToken jtoken in LabelResults)
            {
                JObject item = jtoken as JObject;
                LBRecoverResultEntity entity = new LBRecoverResultEntity();
                entity.TrackingNumber = item["TrackingNumber"].Value<string>();
                JObject LabelImage = item["LabelImage"] as JObject;
                if (LabelImage != null)
                {
                    JObject LabelImageFormat = LabelImage["LabelImageFormat"] as JObject;
                    if (LabelImageFormat != null)
                    {
                        entity.LabelImageFormatCode = LabelImageFormat["Code"].Value<string>();
                    }
                    entity.LabelGraphicImage = LabelImage["GraphicImage"].Value<string>();
                    entity.LabelHTMLImage = LabelImage["HTMLImage"].Value<string>();
                    entity.LabelPDF417 = LabelImage["PDF417"].Value<string>();
                }
                JObject Receipt = item["Receipt"] as JObject;
                if (Receipt != null)
                {
                    entity.ReceiptHTMLImage = Receipt["HTMLImage"].Value<string>();
                }
                listResult.Add(entity);
            }
            return listResult;
        }

    }
}
