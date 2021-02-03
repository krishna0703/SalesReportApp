using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace RestAPI
{
    public class DataAccess
    {
        private readonly Random _random = new Random();
        public DataTable SalesData()
        {
            DataTable dt = new DataTable();
            //in DB Call we will add dynamic Sting list
            string[] states = new string[7] { "Illinois", "Georgia", "NewYork", "California", "Washington", "Florida", "Colorado" };
            string[] Months = new string[5] { "January", "February", "March", "April", "May" };


            //            TotalSales StateName   Month
            //                  31  Florida 2
            //                  1   Georgia 1
            //                  2   Georgia 2

            dt.Clear();
            dt.Columns.Add("Month");//for Month
            dt.Columns.Add("State");//for State
            dt.Columns.Add("TotalSales");//for Sales

            foreach (string oState in states)
            {
                foreach (string oMonth in Months)
                {
                    DataRow _dr = dt.NewRow();
                    _dr["State"] = oState;
                    _dr["Month"] = oMonth;
                    _dr["TotalSales"] = _random.Next(10000).ToString();
                    dt.Rows.Add(_dr);
                }
            }

            return dt;
        }
    }
}