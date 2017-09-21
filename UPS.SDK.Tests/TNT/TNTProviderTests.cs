using Microsoft.VisualStudio.TestTools.UnitTesting;
using UPS.SDK.TNT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.SDK.Tests
{
    [TestClass()]
    public class TNTProviderTests
    {
        [TestMethod()]
        public void ExecuteTest()
        {
            TNTTimeInTransitEntity TimeInTransitRequest = new TNTTimeInTransitEntity();
            TimeInTransitRequest.ShipFrom = new TNTAddressEntity()
            {
                 Address=new TNTAddressItem()
                 {
                     CountryCode="US",
                     StateProvinceCode= "CA",
                     PostalCode= "91502"
                 }
            };
            TimeInTransitRequest.ShipTo = new TNTAddressEntity()
            {
                Address=new TNTAddressItem()
                {
                    CountryCode = "US",
                    StateProvinceCode = "CA",
                    PostalCode = "91763"
                }
            };
            TimeInTransitRequest.ShipmentWeight = new TNTShipmentWeightEntity()
            {
                Weight = "10"
            };
            TimeInTransitRequest.MaximumListSize = "8";

            TNTProvider provider = new TNTProvider();
            provider.TimeInTransitRequest = TimeInTransitRequest;
            List<TNTArrivalResultEntity> result = provider.Execute();
            Console.WriteLine(JsonHelper.SerializeObject(result));
            Assert.Fail();
        }
    }
}