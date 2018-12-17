using System;
using System.Collections.Generic;

namespace PizzaWebApp.Models
{
    public class Orderdetails
    {
        public int Orderid { get; set; }
        public int Customerid { get; set; }
        public int Storeid { get; set; }
        public int Locationid { get; set; }
        public double Totalcost { get; set; }
        public DateTime Dateplaced { get; set; }

        public  Customer Customer { get; set; }
        public  Location Location { get; set; }
        public  Pizzastore Store { get; set; }
        public List<History> History { get; set; } = new List<History>();
        public  List<Ordereddrinks> Ordereddrinks { get; set; } = new List<Ordereddrinks>();
        public List<Orderedpizzas> Orderedpizzas { get; set; } = new List<Orderedpizzas>();
        public List<Orderedsides> Orderedsides { get; set; } = new List<Orderedsides>();
    }
}