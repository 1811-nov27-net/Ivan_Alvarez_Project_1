using System;
using System.Collections.Generic;

namespace PizzaWebApp.Models
{
    public class Customer
    {
        public int Userid { get; set; }
        public string Username { get; set; }
        public int Deflocationid { get;  set; }
        public bool Haveorder { get;  set; }
        public DateTime? Dateplaced { get;  set; }
        public string Firstname { get;  set; }
        public string Latname { get;  set; }

        public Location Deflocation { get;  set; }
        public List<History> History { get; set; } = new List<History>();
        public List<Orderdetails> Orderdetails { get; set; } = new List<Orderdetails>();
    }
}