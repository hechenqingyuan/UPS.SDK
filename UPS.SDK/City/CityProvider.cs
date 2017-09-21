using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.SDK.City
{
    public partial class CityProvider
    {
        public CityProvider()
        {
        }

        public CityValidateEntity AddressValidationRequest { get; set; }

        private string ApiName = "/rest/AV";

        public List<AVRResultEntity> Execute()
        {
            string returnValue = string.Empty;
            string UPS_URL_RATE = ConfigurationManager.AppSettings["UPS_URL_RATE"];
            string UPS_UserName = ConfigurationManager.AppSettings["UPS_UserName"];
            string UPS_Password = ConfigurationManager.AppSettings["UPS_Password"];
            string UPS_Token = ConfigurationManager.AppSettings["UPS_Token"];

            JObject root = new JObject();

            JObject AccessRequest = new JObject();
            AccessRequest.Add("AccessLicenseNumber", UPS_Token);
            AccessRequest.Add("UserId", UPS_UserName);
            AccessRequest.Add("Password", UPS_Password);
            root.Add("AccessRequest", AccessRequest);

            root.Add("AddressValidationRequest", JObject.Parse(JsonHelper.SerializeObject(AddressValidationRequest)));

            returnValue = root.ToString();

            ITopClient client = new TopClientDefault();
            string content = client.Execute(this.ApiName, root);

            List<AVRResultEntity> listResult = null;
            if (string.IsNullOrEmpty(content))
            {
                return listResult;
            }
            JObject jResult = JObject.Parse(content);
            if (jResult == null)
            {
                return listResult;
            }
            JObject AddressValidationResponse = jResult["AddressValidationResponse"] as JObject;
            if (AddressValidationResponse == null)
            {
                return listResult;
            }

            JToken token = AddressValidationResponse.Value<JToken>("AddressValidationResult");
            if (token == null)
            {
                return listResult;
            }
            listResult = new List<AVRResultEntity>();

            Action<JToken> aciton = (JToken jResponse) => 
            {
                if (jResponse is JObject)
                {
                    JObject AVObject = jResponse as JObject;
                    AVRResultEntity result = new AVRResultEntity();
                    result.Rank = AVObject["Rank"].Value<string>();
                    result.Quality = AVObject["Quality"].Value<string>();
                    result.PostalCodeLowEnd = AVObject["PostalCodeLowEnd"].Value<string>();
                    result.PostalCodeHighEnd = AVObject["PostalCodeHighEnd"].Value<string>();
                    JObject Address = AVObject["Address"] as JObject;
                    if (Address != null)
                    {
                        result.City = Address["City"].Value<string>();
                        result.StateProvinceCode = Address["StateProvinceCode"].Value<string>();
                    }
                    listResult.Add(result);
                }
                else if (jResponse is JArray)
                {
                    foreach (var item in jResponse)
                    {
                        JObject AVObject = item as JObject;
                        AVRResultEntity result = new AVRResultEntity();
                        result.Rank = AVObject["Rank"].Value<string>();
                        result.Quality = AVObject["Quality"].Value<string>();
                        result.PostalCodeLowEnd = AVObject["PostalCodeLowEnd"].Value<string>();
                        result.PostalCodeHighEnd = AVObject["PostalCodeHighEnd"].Value<string>();
                        JObject Address = AVObject["Address"] as JObject;
                        if (Address != null)
                        {
                            result.City = Address["City"].Value<string>();
                            result.StateProvinceCode = Address["StateProvinceCode"].Value<string>();
                        }
                        listResult.Add(result);
                    }
                }
            };
            aciton(token);
            return listResult;
        }
    }
}
