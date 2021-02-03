using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Models
{
    public class SalesReport
    {
        public string stateName { get; set; }
        public Decimal TotalSales { get; set; }
        public string SalesMonth { get; set; }
    }
    

}