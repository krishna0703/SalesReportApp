using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication2.Controllers;
using System.Web.Mvc;
using System.Web.Routing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class HomeControllerUnitTest
    {
        [TestMethod]
        public void GetDetailsPositiveCase()
        {
            HomeController ObjHomeCntrl = new HomeController();
            Task<JsonResult> result = ObjHomeCntrl.GetDtails() as Task<JsonResult>;
            IDictionary <string,object> data=(IDictionary <string,object>) new RouteValueDictionary(result);
            Assert.AreEqual(true, data["status"]);
        }
        [TestMethod]
        public void GetDetailsNegativeCase()
        {
            HomeController ObjHomeCntrl = new HomeController();
            Task<JsonResult> result = ObjHomeCntrl.GetDtails() as Task<JsonResult>;
            IDictionary<string, object> data = (IDictionary<string, object>)new RouteValueDictionary(result);
            Assert.AreNotEqual(false, data["status"]);
        }
    }
}
