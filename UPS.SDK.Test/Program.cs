using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPS.SDK.Rate;

namespace UPS.SDK.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            RateShipmentEntity entity = new RateShipmentEntity();
            entity.Service = new RateServiceEntity() { Code="03" };
            entity.Shipper = new ShipAddressEntity()
            {
                Name = "Shipper Name",
                ShipperNumber = "",
                Address = new AddressItemEntity()
                {
                    CountryCode = "US",
                    StateProvinceCode = "CA",
                    City = "",
                    PostalCode = "91763",
                    AddressLine = new List<string>()
                }
            };
            entity.ShipFrom = new ShipAddressEntity()
            {
                Name = "Shipper Name",
                ShipperNumber = "",
                Address = new AddressItemEntity()
                {
                    CountryCode = "US",
                    StateProvinceCode = "CA",
                    City = "",
                    PostalCode = "91763",
                    AddressLine = new List<string>()
                }
            };
            entity.ShipTo = new ShipAddressEntity()
            {
                Name = "Shipper Name",
                ShipperNumber = "",
                Address = new AddressItemEntity()
                {
                    CountryCode = "US",
                    StateProvinceCode = "CA",
                    City = "",
                    PostalCode = "91502",
                    AddressLine = new List<string>()
                }
            };
            entity.Package = new RatePackageEntity()
            {
                Dimensions = new RateDimensionsEntity() { Length = "2", Width = "2", Height = "2" },
                PackageWeight = new PackageWeightEntity() { Weight = "2" }
            };
            RateProvider provider = new RateProvider();
            provider.Shipment = entity;
            RateResultEntity returnValue = provider.Execute();
            Console.WriteLine(JsonHelper.SerializeObject(returnValue));
            Console.ReadLine();
        }
    }
}
