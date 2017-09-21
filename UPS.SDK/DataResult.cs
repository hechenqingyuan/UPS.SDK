using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.SDK
{
    public partial class DataResult
    {
        public DataResult() { }

        public int Code { get; set; }

        public string Message { get; set; }

    }

    public partial class DataResult<T> : DataResult
    {
        public T Result { get; set; }
    }
}
