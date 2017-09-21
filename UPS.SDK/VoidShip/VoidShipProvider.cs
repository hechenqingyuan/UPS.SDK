using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.SDK.VoidShip
{
    public partial class VoidShipProvider
    {
        public VoidShipProvider()
        {
        }

        private string ApiName = "/rest/Void ";

        /// <summary>
        /// 作废发运单
        /// </summary>
        /// <param name="ShipmentIdentificationNumber"></param>
        /// <returns></returns>
        public VoidShipResultEntity Execute(string ShipmentIdentificationNumber)
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


            JObject VoidShipmentRequest = new JObject();

            JObject Request = new JObject();
            JObject TransactionReference = new JObject();
            TransactionReference.Add("CustomerContext","");
            Request.Add("TransactionReference", TransactionReference);
            VoidShipmentRequest.Add("Request", Request);

            JObject VoidShipment = new JObject();
            VoidShipment.Add("ShipmentIdentificationNumber", ShipmentIdentificationNumber);
            VoidShipmentRequest.Add("VoidShipment", VoidShipment);

            returnValue = root.ToString();

            ITopClient client = new TopClientDefault();
            string content = client.Execute(this.ApiName, root);
            VoidShipResultEntity result = null;
            if (string.IsNullOrEmpty(content))
            {
                return result;
            }
            JObject jResult = JObject.Parse(content);
            JObject VoidShipmentResponse = jResult["VoidShipmentResponse"] as JObject;
            if (VoidShipmentResponse == null)
            {
                return result;
            }
            JObject SummaryResult = VoidShipmentResponse["SummaryResult"] as JObject;
            if (SummaryResult == null)
            {
                return result;
            }
            JObject Status = SummaryResult["Status"] as JObject;
            if (Status == null)
            {
                return result;
            }
            result.Code = Status["Code"].Value<string>();
            result.Description = Status["Description"].Value<string>();
            return result;
        }
    }
}
