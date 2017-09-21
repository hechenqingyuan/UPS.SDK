using Microsoft.VisualStudio.TestTools.UnitTesting;
using UPS.SDK.PublishRateShipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.SDK.Tests
{
    [TestClass()]
    public class PublishShipProviderTests
    {
        [TestMethod()]
        public void ExecuteTest()
        {
            PublishShipRequestEntity ShipmentRequest = new PublishShipRequestEntity();
            ShipmentRequest.Shipment = new PShipmentEntity();
            ShipmentRequest.Shipment.Shipper = new PShipperAddressEntity()
            {
                Name = "Shipper Name",
                AttentionName = "Shipper Attn Name",
                TaxIdentificationNumber = "123456",
                Phone=new PPhoneEntity() { Number= "1234567890", Extension="1" },
                ShipperNumber= "V62044 - Xinyu Mu",
                FaxNumber= "FaxNumber",
                Address=new PAddressEntity()
                {
                    AddressLine= "1501 N Victory Pl",
                    City= "Burbank",
                    CountryCode="US",
                    PostalCode= "91502",
                    StateProvinceCode= "CA"
                }
            };
            ShipmentRequest.Shipment.ShipTo = new PShipperAddressEntity()
            {
                Name = "Shipper Name",
                AttentionName = "Shipper Attn Name",
                Phone = new PPhoneEntity() { Number = "1234567890", Extension = "1" },
                FaxNumber = "FaxNumber",
                Address = new PAddressEntity()
                {
                    AddressLine = "1501 N Victory Pl",
                    City = "Burbank",
                    CountryCode = "US",
                    PostalCode = "91502",
                    StateProvinceCode = "CA"
                }
            };
            ShipmentRequest.Shipment.ShipFrom = new PShipperAddressEntity()
            {
                Name = "Shipper Name",
                AttentionName = "Shipper Attn Name",
                Phone = new PPhoneEntity() { Number = "1234567890", Extension = "1" },
                FaxNumber = "FaxNumber",
                Address = new PAddressEntity()
                {
                    AddressLine = "1501 N Victory Pl",
                    City = "Burbank",
                    CountryCode = "US",
                    PostalCode = "91502",
                    StateProvinceCode = "CA"
                }
            };
           
            ShipmentRequest.Shipment.Package = new PPackageEntity()
            {
                Dimensions=new PDimensionsEntity() { Length="2",Height="2",Width="2" },
                PackageWeight=new PPackageWeightEntity() { Weight="10" },
            };

            PublishShipProvider provider = new PublishShipProvider();
            provider.ShipmentRequest = ShipmentRequest;
            object result = provider.Execute();
            Assert.Fail();
        }
    }
}