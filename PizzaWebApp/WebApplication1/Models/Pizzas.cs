using System.Collections.Generic;

namespace PizzaWebApp.Models
{
    public class Pizzas
    {
        public string Name { get; set; }
        public double Cost { get; set; }

        public List<Inventorypizzas> Inventorypizzas { get; set; } = new List<Inventorypizzas>();
        public List<Orderedpizzas> Orderedpizzas { get; set; } = new List<Orderedpizzas>();
    }
}