using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.SDK.Rate
{
    public partial class RateCurrencyEntity
    {
        public RateCurrencyEntity() { }

        /// <summary>
        /// 货币类型
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// 费用金额
        /// </summary>
        public double MonetaryValue { get; set; }
    }
}
