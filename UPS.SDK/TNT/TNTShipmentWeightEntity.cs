using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.SDK.TNT
{
    public partial class TNTShipmentWeightEntity
    {
        public TNTShipmentWeightEntity()
        {
            UnitOfMeasurement = new JObject();
            UnitOfMeasurement.Add("Code", "LBS");
            UnitOfMeasurement.Add("Description", "pounds");
        }

        public string Weight { get; set; }

        public JObject UnitOfMeasurement { get; set; }
    }
}
