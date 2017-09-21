using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.SDK.TNT
{
    public partial class TNTProvider
    {
        public TNTProvider() { }

        private string ApiName = "/rest/TimeInTransit";

        public TNTTimeInTransitEntity TimeInTransitRequest { get; set; }

        /// <summary>
        /// 执行
        /// </summary>
        /// <returns></returns>
        public List<TNTArrivalResultEntity> Execute()
        {
            string returnValue = string.Empty;
            string UPS_URL_RATE = ConfigurationManager.AppSettings["UPS_URL_RATE"];
            string UPS_UserName = ConfigurationManager.AppSettings["UPS_UserName"];
            string UPS_Password = ConfigurationManager.AppSettings["UPS_Password"];
            string UPS_Token = ConfigurationManager.AppSettings["UPS_Token"];

            JObject root = new JObject();

            JObject Security = new JObject();
            JObject UsernameToken = new JObject();
            UsernameToken.Add("Username", UPS_UserName);
            UsernameToken.Add("Password", UPS_Password);
            JObject ServiceAccessToken = new JObject();
            ServiceAccessToken.Add("AccessLicenseNumber", UPS_Token);
            Security.Add("UsernameToken", UsernameToken);
            Security.Add("UPSServiceAccessToken", ServiceAccessToken);
            root.Add("Security", Security);

            JObject json = JObject.Parse(JsonHelper.SerializeObject(TimeInTransitRequest));
            root.Add("TimeInTransitRequest",json);

            returnValue = root.ToString();

            ITopClient client = new TopClientDefault();
            string content = client.Execute(this.ApiName, root);

            List<TNTArrivalResultEntity> listResult = null;

            JObject jResult = JObject.Parse(content);
            if (jResult == null)
            {
                return listResult;
            }
            JObject TimeInTransitResponse = jResult["TimeInTransitResponse"] as JObject;
            if (TimeInTransitResponse == null)
            {
                return listResult;
            }
            JObject TransitResponse = TimeInTransitResponse["TransitResponse"] as JObject;
            if (TransitResponse == null)
            {
                return listResult;
            }
            JArray ServiceSummary = TransitResponse["ServiceSummary"] as JArray;
            if (ServiceSummary != null && ServiceSummary.Count() > 0)
            {
                listResult = new List<TNTArrivalResultEntity>();
                foreach (JToken jtoken in ServiceSummary)
                {
                    JObject resultItem = jtoken as JObject;
                    TNTArrivalResultEntity entity = new TNTArrivalResultEntity();
                    JObject Service = resultItem["Service"] as JObject;
                    if (Service != null)
                    {
                        entity.Code = Service["Code"].Value<string>();
                        entity.Description = Service["Description"].Value<string>();
                    }
                    entity.GuaranteedIndicator = resultItem["GuaranteedIndicator"].Value<string>();

                    JObject EstimatedArrival= resultItem["EstimatedArrival"] as JObject;
                    if (EstimatedArrival!= null)
                    {
                        JObject Arrival = EstimatedArrival["Arrival"] as JObject;
                        if (Arrival != null)
                        {
                            entity.ArrivalDate = Arrival["Date"].Value<string>();
                            entity.ArrivalTime = Arrival["Time"].Value<string>();
                        }
                        entity.BusinessDaysInTransit = EstimatedArrival["BusinessDaysInTransit"].Value<string>();
                        entity.DayOfWeek = EstimatedArrival["DayOfWeek"].Value<string>();
                        entity.CustomerCenterCutoff = EstimatedArrival["CustomerCenterCutoff"].Value<string>();
                    }
                    listResult.Add(entity);
                }
            }
            return listResult;
        }
    }
}
