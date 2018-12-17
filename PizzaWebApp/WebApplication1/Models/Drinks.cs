using System.Collections.Generic;

namespace PizzaWebApp.Models
{
    public class Drinks
    {
        public string Name { get;  set; }
        public double Cost { get;  set; }
        public List<Inventorydrinks> Inventorydrinks { get; set; } = new List<Inventorydrinks>();
        public List<Ordereddrinks> Ordereddrinks { get; set; } = new List<Ordereddrinks>();

    }
}