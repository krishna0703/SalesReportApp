using System;
using System.Web.Mvc;
//using WebApplication2.Models;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Configuration;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public async Task<JsonResult> GetDtails()

        {
            //var salesreport = new List<CarPurchase>();
            string response = string.Empty;
            JValue responsejvalue = null;
            string responsejson = string.Empty;
            bool status = false;
            try
            {

                //salesreport.Add(new Models.CarPurchase() { Month = "Jan", Illinois = "100", Georgia = "852", NewYork = "656", California = "2541", Colorado = "2356", Florida = "5544", Washington = "2540" });
                //salesreport.Add(new Models.CarPurchase() { Month = "Feb", Illinois = "200", Georgia = "852", NewYork = "656", California = "2541", Colorado = "2356", Florida = "5544", Washington = "2540" });
                //salesreport.Add(new Models.CarPurchase() { Month = "Mar", Illinois = "300", Georgia = "852", NewYork = "656", California = "2541", Colorado = "2356", Florida = "5544", Washington = "2540" });
                //salesreport.Add(new Models.CarPurchase() { Month = "Apr", Illinois = "400", Georgia = "852", NewYork = "656", California = "2541", Colorado = "2356", Florida = "5544", Washington = "2540" });
                //salesreport.Add(new Models.CarPurchase() { Month = "May", Illinois = "500", Georgia = "852", NewYork = "656", California = "2541", Colorado = "2356", Florida = "5544", Washington = "2540" });

                //Api Call
                string baseURL = ConfigurationManager.AppSettings["RestURL"].ToString();
                String APIName = ConfigurationManager.AppSettings["SalesAPIName"].ToString();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseURL);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Result = await client.GetAsync(APIName);
                    if (Result.IsSuccessStatusCode)
                    {
                        response = Result.Content.ReadAsStringAsync().Result;
                        responsejson = JsonConvert.DeserializeObject<JValue>(response).ToString();
                        status = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(new { responsejson, status }, JsonRequestBehavior.AllowGet);
        }
    }
}