using System.Collections.Generic;

namespace PizzaWebApp.Models
{
    public class Pizzastore
    {
        public int Storeid { get; set; }
        public string Name { get; set; }
        public int Locationid { get; set; }

        public Location Location { get; set; }
        public List<History> History { get; set; } = new List<History>();
        public List<Inventorydrinks> Inventorydrinks { get; set; } = new List<Inventorydrinks>();
        public List<Inventorypizzas> Inventorypizzas { get; set; } = new List<Inventorypizzas>();
        public List<Inventorysides> Inventorysides { get; set; } = new List<Inventorysides>();
        public List<Orderdetails> Orderdetails { get; set; } = new List<Orderdetails>();
    }
}