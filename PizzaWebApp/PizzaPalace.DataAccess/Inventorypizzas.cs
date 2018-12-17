using System;
using System.Collections.Generic;

namespace PizzaPalace.DataAccess
{
    public partial class Inventorypizzas
    {
        public int Storeid { get; set; }
        public string Pizzaname { get; set; }
        public int Itemamount { get; set; }
        public int Inventpizzasid { get; set; }

        public virtual Pizzas PizzanameNavigation { get; set; }
        public virtual Pizzastore Store { get; set; }
    }
}
