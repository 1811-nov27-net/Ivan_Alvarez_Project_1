using System.Collections.Generic;

namespace PizzaWebApp.Models
{
    public class Sides
    {
        public string Name { get; set; }
        public double Cost { get; set; }

        public List<Inventorysides> Inventorysides { get; set; } = new List<Inventorysides>();
        public List<Orderedsides> Orderedsides { get; set; } = new List<Orderedsides>();
    }
}