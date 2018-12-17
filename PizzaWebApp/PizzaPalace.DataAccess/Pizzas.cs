using System;
using System.Collections.Generic;

namespace PizzaPalace.DataAccess
{
    public partial class Pizzas
    {
        public Pizzas()
        {
            Inventorypizzas = new HashSet<Inventorypizzas>();
            Orderedpizzas = new HashSet<Orderedpizzas>();
        }

        public string Name { get; set; }
        public double Cost { get; set; }

        public virtual ICollection<Inventorypizzas> Inventorypizzas { get; set; }
        public virtual ICollection<Orderedpizzas> Orderedpizzas { get; set; }
    }
}
