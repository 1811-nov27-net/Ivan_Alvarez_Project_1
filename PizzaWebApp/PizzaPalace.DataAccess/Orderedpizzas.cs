using System;
using System.Collections.Generic;

namespace PizzaPalace.DataAccess
{
    public partial class Orderedpizzas
    {
        public int Orderedpizzasid { get; set; }
        public int Orderid { get; set; }
        public string Pizzaname { get; set; }
        public int Pizzaqty { get; set; }
        public double Pizzascost { get; set; }

        public virtual Orderdetails Order { get; set; }
        public virtual Pizzas PizzanameNavigation { get; set; }
    }
}
