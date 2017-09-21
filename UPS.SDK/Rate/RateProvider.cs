using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.SDK.Rate
{
    /// <summary>
    /// 费用计算执行结果
    /// </summary>
    public partial class RateProvider
    {
        public RateProvider() { }

        private string ApiName = "/rest/Rate";

        public RateShipmentEntity Shipment { get; set; }

        /// <summary>
        /// 返回运单价
        /// </summary>
        /// <returns></returns>
        public RateResultEntity Execute()
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


            JObject RateRequest = new JObject();

            JObject Request = new JObject();
            JObject TransactionReference = new JObject();
            TransactionReference.Add("CustomerContext", "");
            Request.Add("RequestOption", "Rate");
            Request.Add("TransactionReference", TransactionReference);
            RateRequest.Add("Request", Request);

            string json = JsonHelper.SerializeObject(Shipment);
            RateRequest.Add("Shipment", JObject.Parse(json));
            root.Add("RateRequest", RateRequest);

            returnValue = root.ToString();

            ITopClient client = new TopClientDefault();
            string content = client.Execute(this.ApiName,root);

            RateResultEntity result = null;
            if (!string.IsNullOrEmpty(content))
            {
                JObject jResult = JObject.Parse(content);
                JObject RateResponse = jResult["RateResponse"] as JObject;
                if (RateResponse == null)
                {
                    return result;
                }
                JObject RatedShipment = RateResponse["RatedShipment"] as JObject;
                if (RatedShipment == null)
                {
                    return result;
                }
                result = new RateResultEntity();
                JObject TransportationCharges = RatedShipment["TransportationCharges"] as JObject;
                if (TransportationCharges != null)
                {
                    result.TransportationCharges = new RateCurrencyEntity();
                    result.TransportationCharges.CurrencyCode = TransportationCharges["CurrencyCode"].Value<string>();
                    result.TransportationCharges.MonetaryValue = TransportationCharges["MonetaryValue"].Value<double>();
                }

                JObject ServiceOptionsCharges = RatedShipment["ServiceOptionsCharges"] as JObject;
                if (ServiceOptionsCharges != null)
                {
                    result.ServiceOptionsCharges = new RateCurrencyEntity();
                    result.ServiceOptionsCharges.CurrencyCode = ServiceOptionsCharges["CurrencyCode"].Value<string>();
                    result.ServiceOptionsCharges.MonetaryValue = ServiceOptionsCharges["MonetaryValue"].Value<double>();
                }

                JObject TotalCharges = RatedShipment["TotalCharges"] as JObject;
                if (TotalCharges != null)
                {
                    result.TotalCharges = new RateCurrencyEntity();
                    result.TotalCharges.CurrencyCode = TotalCharges["CurrencyCode"].Value<string>();
                    result.TotalCharges.MonetaryValue = TotalCharges["MonetaryValue"].Value<double>();
                }

                JObject NegotiatedRateCharges = RatedShipment["NegotiatedRateCharges"] as JObject;
                if (NegotiatedRateCharges != null)
                {
                    result.NegotiatedRateCharges = new RateCurrencyEntity();
                    JObject NagTotalCharge = NegotiatedRateCharges["TotalCharge"] as JObject;
                    if (NagTotalCharge != null)
                    {
                        result.NegotiatedRateCharges.CurrencyCode = NagTotalCharge["CurrencyCode"].Value<string>();
                        result.NegotiatedRateCharges.MonetaryValue = NagTotalCharge["MonetaryValue"].Value<double>();
                    }
                }
            }
            return result;
        }
    }
}
