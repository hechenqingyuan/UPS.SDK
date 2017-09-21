using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.SDK.PublishRateShipment
{
    public class PPackageWeightEntity
    {
        public PPackageWeightEntity()
        {
            UnitOfMeasurement = new JObject();
            UnitOfMeasurement.Add("Code", "LBS");
            UnitOfMeasurement.Add("Description", "Pounds");
        }

        public string Weight { get; set; }

        public JObject UnitOfMeasurement { get; set; }
    }
}
