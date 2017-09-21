using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.SDK
{
    public partial class JsonHelper
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static string SerializeObject(object value)
        {
            if (value != null)
            {
                IsoDateTimeConverter timeConverter = new IsoDateTimeConverter();
                timeConverter.DateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm':'ss";
                return JsonConvert.SerializeObject(value, Formatting.None, timeConverter);
            }
            return string.Empty;
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T DeserializeObject<T>(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                IsoDateTimeConverter timeConverter = new IsoDateTimeConverter();
                timeConverter.DateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm':'ss";
                return JsonConvert.DeserializeObject<T>(value, timeConverter);
            }
            return default(T);
        }
    }
}
