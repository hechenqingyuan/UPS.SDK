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
            entity.Shipper = new ShipAddressEntity()
            {
                Name = "Shipper Name",
                ShipperNumber = "",
                Address = new AddressItemEntity()
                {
                    CountryCode = "US",
                    StateProvinceCode = "CA",
                    City = "Montclair",
                    PostalCode = "91763",
                    AddressLine = new List<string>()
                    {
                        "8960 Central Ave",
                    }
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
                    City = "Montclair",
                    PostalCode = "91763",
                    AddressLine = new List<string>()
                    {
                        "8960 Central Ave",
                    }
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
                    City = "Burbank",
                    PostalCode = "91502",
                    AddressLine = new List<string>()
                    {
                        "1501 N Victory Pl",
                    }
                }
            };
            entity.Package = new RatePackageEntity()
            {
                Dimensions = new RateDimensionsEntity() { Length = "5", Width = "5", Height = "5" },
                PackageWeight = new PackageWeightEntity() { Weight = "5" }
            };
            RateProvider provider = new RateProvider();
            provider.Shipment = entity;
            RateResultEntity returnValue = provider.Execute();
            Console.WriteLine(JsonHelper.SerializeObject(returnValue));
            Console.ReadLine();
        }
    }
}
