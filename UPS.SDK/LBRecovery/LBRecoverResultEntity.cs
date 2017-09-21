using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.SDK.LBRecovery
{
    public class LBRecoverResultEntity
    {
        public LBRecoverResultEntity()
        {
        }

        public string TrackingNumber { get; set; }

        public string LabelImageFormatCode { get; set; }

        public string LabelGraphicImage { get; set; }

        public string LabelHTMLImage { get; set; }

        public string LabelPDF417 { get; set; }

        public string ReceiptHTMLImage { get; set; }
    }
}
