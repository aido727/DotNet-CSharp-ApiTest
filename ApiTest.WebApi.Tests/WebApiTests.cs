using ApiTest.WebApi.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.AspNetCore.Mvc;
using ApiTest.DataModule;

namespace ApiTest.WebApi.Tests
{
    [TestClass]
    public class WebApiTests
    {
        IHeaderDictionary validHeader = new HeaderDictionary() {{ "Authorization", "Bearer af24353tdsfw"}};

        //authHeaderHandler
        [TestMethod]
        public void AuthHeaderHandler_Accepts()
        {
            var controller = new ApiTestController(new NullLogger<ApiTestController>(), new DataModuleService());
            var result = controller.authHeaderHandler(validHeader);
            Assert.IsTrue(result == true);
        }

        [TestMethod]
        public void AuthHeaderHandler_RejectsWhenWrongValue()
        {
            var controller = new ApiTestController(new NullLogger<ApiTestController>(), new DataModuleService());
            IHeaderDictionary headers = new HeaderDictionary() {{ "Authorization", "Bearer 111"}};
            var result = controller.authHeaderHandler(headers);
            Assert.IsTrue(result == false);
        }

        [TestMethod]
        public void AuthHeaderHandler_RejectsWhenWrongType()
        {
            var controller = new ApiTestController(new NullLogger<ApiTestController>(), new DataModuleService());
            IHeaderDictionary headers = new HeaderDictionary() {{ "Authorization", "Basic af24353tdsfw"}};
            var result = controller.authHeaderHandler(headers);
            Assert.IsTrue(result == false);
        }

        [TestMethod]
        public void AuthHeaderHandler_RejectsWhenMissingKey()
        {
            var controller = new ApiTestController(new NullLogger<ApiTestController>(), new DataModuleService());
            IHeaderDictionary headers = new HeaderDictionary() {{ "Something else", "Bearer af24353tdsfw"}};
            var result = controller.authHeaderHandler(headers);
            Assert.IsTrue(result == false);
        }
    }
}
