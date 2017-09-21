using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.SDK
{
    public enum EResponseCode
    {
        [Description("成功")]
        Success=1,

        [Description("异常")]
        Exception =2
    }
}
