using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApplication2;

namespace API.Tests
{
    [TestClass()]
    public class SalesAPITest
    {
        [TestMethod()]
        public void GetAPIDetailsTest()
        {
            //string baseURL = ConfigurationManager.AppSettings["RestURL"].ToString();
            //String APIName = ConfigurationManager.AppSettings["SalesAPIName"].ToString();
            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri(baseURL);
            //    client.DefaultRequestHeaders.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //    HttpResponseMessage Result = await client.GetAsync(APIName);
            //    if (Result.IsSuccessStatusCode)
            //    {
            //        response = Result.Content.ReadAsStringAsync().Result;
            //        responsejson = JsonConvert.DeserializeObject<JValue>(response).ToString();
            //        //Unable to cast object of type 'Newtonsoft.Json.Linq.JArray' to type 'Newtonsoft.Json.Linq.JValue'.
            //        status = true;
            //    }
            //}
            Assert.Fail();
        }
    }
}