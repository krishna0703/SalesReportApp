using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestAPI.Models;
using System.Data;
using Newtonsoft.Json;
using System.Dynamic;
using Newtonsoft.Json.Linq;

namespace RestAPI.Controllers
{
    public class SalesAPIController : ApiController
    {
        // GET: DataPull
        public string Get()
        {
            DataAccess oDataAccess = new DataAccess();
            DataTable SalesData = new DataTable();
            string VData = string.Empty;
            dynamic Saleslist = new List<dynamic>();
            SalesData = oDataAccess.SalesData();

            if (SalesData != null && SalesData.Rows.Count > 0)
            {
                var distinctMonths = SalesData.AsEnumerable()
                          .Select(row => new {
                              Months = row.Field<string>("Month")
                          })
                          .Distinct();

                foreach (var Monthrow in distinctMonths)
                {
                    string Month = Monthrow.Months.ToString();

                    DataRow[] foundRows = SalesData.Select("Month='" + Month + "'", "State");
                    dynamic newobj = new ExpandoObject();
                    newobj.Month = Month;
                    foreach (DataRow oDataRow in foundRows)
                    {
                        AddProperty(newobj, oDataRow.ItemArray[1].ToString(), oDataRow.ItemArray[2].ToString());

                    }
                    Saleslist.Add(newobj);
                }

              VData= JsonConvert.SerializeObject(Saleslist);
            }
            return VData;

        }
        public void AddProperty(ExpandoObject expando, string name, object value)
        {
            var exDict = expando as IDictionary<string, object>;
            if (exDict.ContainsKey(name))
                exDict[name] = value;
            else
                exDict.Add(name, value);
        }
    }
}
