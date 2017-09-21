using Microsoft.VisualStudio.TestTools.UnitTesting;
using UPS.SDK.Street;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.SDK.Tests
{
    [TestClass()]
    public class StreetProviderTests
    {
        [TestMethod()]
        public void ExecuteTest()
        {
            XAVRequestEntity XAVRequest = new XAVRequestEntity();
            XAVRequest.AddressKeyFormat = new AddressKeyFormatEntity()
            {
                CountryCode="US",
                PostcodePrimaryLow= "43240",
                BuildingName="",
                ConsigneeName="",
                PoliticalDivision1="",
                PoliticalDivision2="",
                AddressLine= "801 Polaris Pkwy",
            };
            StreetProvider provider = new StreetProvider();
            provider.XAVRequest = XAVRequest;

            object result = provider.Execute();
            Assert.Fail();
        }
    }
}