using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.SDK.PublishRateShipment
{
    public partial class PublishResultEntity
    {
        public PublishResultEntity()
        {
        }

        public string TransportationCurrencyCode { get; set; }

        public string TransportationMonetaryValue { get; set; }

        public string ServiceOptionsCurrencyCode { get; set; }

        public string ServiceOptionsMonetaryValue { get; set; }

        public string TotalCurrencyCode { get; set; }

        public string TotalMonetaryValue { get; set; }

        public string WeightCode { get; set;}

        public string Weight { get; set; }

        public string ShipmentIdentificationNumber { get; set; }

        public string TrackingNumber { get; set; }

        public string PackageCurrencyCode { get; set; }

        public string PackageMonetaryValue { get; set; }

        public string ImageFormatCode { get; set; }

        public string ImageFormatDescription { get; set; }

        public string GraphicImage { get; set; }

        public string HTMLImage { get; set; }
    }
}
