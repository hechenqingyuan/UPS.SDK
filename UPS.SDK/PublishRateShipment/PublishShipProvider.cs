using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.SDK.PublishRateShipment
{
    public partial class PublishShipProvider
    {
        public PublishShipProvider() { }

        public PublishShipRequestEntity ShipmentRequest { get; set; }

        private string ApiName = "/rest/Ship";

        public object Execute()
        {
            string returnValue = string.Empty;
            string UPS_URL_RATE = ConfigurationManager.AppSettings["UPS_URL_RATE"];
            string UPS_UserName = ConfigurationManager.AppSettings["UPS_UserName"];
            string UPS_Password = ConfigurationManager.AppSettings["UPS_Password"];
            string UPS_Token = ConfigurationManager.AppSettings["UPS_Token"];
            string UPS_AccountNumber = ConfigurationManager.AppSettings["UPS_AccountNumber"];

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

            root.Add("ShipmentRequest", JObject.Parse(JsonHelper.SerializeObject(ShipmentRequest)));
            returnValue = root.ToString();
            ITopClient client = new TopClientDefault();
            string content = client.Execute(this.ApiName, root);

            PublishResultEntity result = null;
            if (string.IsNullOrEmpty(content))
            {
                return result;
            }
            JObject jResult = JObject.Parse(content);
            JObject ShipmentResponse = jResult["ShipmentResponse"] as JObject;
            if (ShipmentResponse == null)
            {
                return result;
            }
            JObject ShipmentResults= ShipmentResponse["ShipmentResults"] as JObject;
            if (ShipmentResults == null)
            {
                return result;
            }
            result = new PublishResultEntity();
            JObject ShipmentCharges = ShipmentResults["ShipmentCharges"] as JObject;
            if (ShipmentCharges != null)
            {
                JObject TransportationCharges = ShipmentCharges["TransportationCharges"] as JObject;
                if (TransportationCharges != null)
                {
                    result.TransportationCurrencyCode = TransportationCharges["CurrencyCode"].Value<string>();
                    result.TransportationMonetaryValue = TransportationCharges["MonetaryValue"].Value<string>();
                }

                JObject ServiceOptionsCharges = ShipmentCharges["TransportationCharges"] as JObject;
                if (ServiceOptionsCharges != null)
                {
                    result.ServiceOptionsCurrencyCode = ServiceOptionsCharges["CurrencyCode"].Value<string>();
                    result.ServiceOptionsMonetaryValue = ServiceOptionsCharges["MonetaryValue"].Value<string>();
                }

                JObject TotalCharges = ShipmentCharges["TransportationCharges"] as JObject;
                if (TotalCharges != null)
                {
                    result.TotalCurrencyCode = TotalCharges["CurrencyCode"].Value<string>();
                    result.TotalMonetaryValue = TotalCharges["MonetaryValue"].Value<string>();
                }
            }
            JObject BillingWeight = ShipmentResults["BillingWeight"] as JObject;
            if (BillingWeight != null)
            {
                result.Weight = BillingWeight["Weight"].Value<string>();
                JObject UnitOfMeasurement = BillingWeight["UnitOfMeasurement"] as JObject;
                if (UnitOfMeasurement != null)
                {
                    result.WeightCode = UnitOfMeasurement["Code"].Value<string>();
                }
            }
            result.ShipmentIdentificationNumber = ShipmentResults["ShipmentIdentificationNumber"].Value<string>();

            JObject PackageResults = ShipmentResults["PackageResults"] as JObject;
            if (PackageResults != null)
            {
                result.TrackingNumber = PackageResults["TrackingNumber"].Value<string>();
                JObject ServiceOptionsCharges = PackageResults["ServiceOptionsCharges"] as JObject;
                if (ServiceOptionsCharges != null)
                {
                    result.PackageCurrencyCode = ServiceOptionsCharges["CurrencyCode"].Value<string>();
                    result.PackageMonetaryValue = ServiceOptionsCharges["MonetaryValue"].Value<string>();
                }
                JObject ShippingLabel= PackageResults["ShippingLabel"] as JObject;
                if (ShippingLabel != null)
                {
                    JObject ImageFormat = ShippingLabel["ImageFormat"] as JObject;
                    if (ImageFormat != null)
                    {
                        result.ImageFormatCode = ImageFormat["Code"].Value<string>();
                        result.ImageFormatDescription = ImageFormat["Description"].Value<string>();
                    }
                    result.GraphicImage = ShippingLabel["GraphicImage"].Value<string>();
                    result.HTMLImage = ShippingLabel["HTMLImage"].Value<string>();
                }
            }
            return result;

        }
    }
}
