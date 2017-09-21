using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.SDK.PublishRateShipment
{
    public class PDimensionsEntity
    {
        public PDimensionsEntity()
        {
            UnitOfMeasurement = new JObject();
            UnitOfMeasurement.Add("Code", "IN");
            UnitOfMeasurement.Add("Description", "Inches");
        }

        public string Length { get; set; }

        public string Width { get; set; }

        public string Height { get; set; }

        public JObject UnitOfMeasurement { get; set; }
    }
}
