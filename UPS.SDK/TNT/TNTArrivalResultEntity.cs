using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.SDK.TNT
{
    public partial class TNTArrivalResultEntity
    {
        public TNTArrivalResultEntity() { }

        public string Code { get; set; }

        public string Description { get; set; }

        public string GuaranteedIndicator { get; set; }

        public string ArrivalDate { get; set; }

        public string ArrivalTime { get; set; }

        public string BusinessDaysInTransit { get; set; }

        public string DayOfWeek { get; set; }

        public string CustomerCenterCutoff { get; set; }
    }
}
