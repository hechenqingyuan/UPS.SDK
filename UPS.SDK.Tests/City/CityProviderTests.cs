using Microsoft.VisualStudio.TestTools.UnitTesting;
using UPS.SDK.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.SDK.Tests
{
    [TestClass()]
    public class CityProviderTests
    {
        [TestMethod()]
        public void ExecuteTest()
        {
            CityValidateEntity AddressValidationRequest = new CityValidateEntity()
            {
                Address=new CityAddressEntity()
                {
                    StateProvinceCode="",
                    City="",
                    PostalCode= "43202"
                }
            };

            CityProvider provider = new CityProvider();
            provider.AddressValidationRequest = AddressValidationRequest;
            List<AVRResultEntity> result = provider.Execute();
            Console.WriteLine(JsonHelper.SerializeObject(result));
            Assert.Fail();
        }
    }
}