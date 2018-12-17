using System.Collections.Generic;

namespace PizzaWebApp.Models
{
    public class Location
    {
        public int Locationid { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public  Pizzastore Pizzastore { get; set; }
        public List<Customer> Customer { get; set; } = new List<Customer>();
        public List<Orderdetails> Orderdetails { get; set; } = new List<Orderdetails>();
    }
}