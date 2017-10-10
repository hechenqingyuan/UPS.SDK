using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.SDK
{
    public static class UPSServiceCode
    {
        private static Dictionary<string, string> Source = new Dictionary<string, string>()
        {
            { "14","UPS Next Day Air Early"},
            { "01","UPS Next Day Air"},
            { "13","UPS Next Day Air Saver"},
            { "59","UPS 2nd Day Air A.M."},
            { "02","UPS 2nd Day Air"},
            { "12","UPS 3 Day Select"},
            { "03","UPS Ground"},

            { "11","UPS Standard"},
            { "07","UPS Worldwide Express"},
            { "54","UPS Worldwide Express Plus"},
            { "08","UPS Worldwide Expedited"},
            { "65","UPS Worldwide Saver"},
            { "96","UPS Worldwide Express Freight"},
            { "82","UPS Today Standard"},
            { "83","UPS Today Dedicated Courier"},
            { "84","UPS Today Intercity"},
            { "85","UPS Today Express"},
            { "86","UPS Today Express Saver"},
            { "70","UPS Access Point Economy"},
        };

        public static Dictionary<string, string> GetSource()
        {
            return Source;
        }

        public static string GetCode(string argValue)
        {
            string result = string.Empty;
            foreach (KeyValuePair<string, string> item in Source)
            {
                if (item.Value.ToLower() == argValue.ToLower())
                {
                    result = item.Key;
                }
            }
            return result;
        }

        public static string GetValue(string argCode)
        {
            if (Source.ContainsKey(argCode))
            {
                return Source[argCode];
            }
            return string.Empty;
        }
    }
}
