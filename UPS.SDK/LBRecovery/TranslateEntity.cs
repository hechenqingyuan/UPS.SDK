using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.SDK.LBRecovery
{
    public class TranslateEntity
    {
        public TranslateEntity()
        {
            LanguageCode = "eng";
            DialectCode = "GB";
            Code = "01";
        }

        public string LanguageCode { get; set; }

        public string DialectCode { get; set; }

        public string Code { get; set; }

    }
}
