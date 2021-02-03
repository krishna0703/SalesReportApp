using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace WebApplication2.Models
{
    public class CarPurchase
    {
        public string Month { get; set; }
        public string Illinois { get; set; }
        public string Georgia { get; set; }
        public string NewYork { get; set; }
        public string California { get; set; }
        public string Washigton { get; set; }
        public string Florida { get; set; }
        public string Colorado { get; set; }
        public string Washington { get; internal set; }
    }
}