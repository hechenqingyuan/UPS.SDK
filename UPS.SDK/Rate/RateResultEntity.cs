using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.SDK.Rate
{
    public partial class RateResultEntity
    {
        public RateResultEntity() { }

        public RateCurrencyEntity TransportationCharges { get; set; }

        public RateCurrencyEntity ServiceOptionsCharges { get; set; }

        public RateCurrencyEntity TotalCharges { get; set; }

        public RateCurrencyEntity NegotiatedRateCharges { get; set; }
    }
}
