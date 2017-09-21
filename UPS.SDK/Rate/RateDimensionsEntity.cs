using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.SDK.Rate
{
    public partial class RateDimensionsEntity
    {
        public RateDimensionsEntity()
        {
            UnitOfMeasurement = new JObject();
            UnitOfMeasurement.Add("Code", "IN");
            UnitOfMeasurement.Add("Description", "inches");
        }

        public string Length { get; set; }

        public string Width { get; set; }

        public string Height { get; set; }

        public JObject UnitOfMeasurement { get; set; }
    }
}
