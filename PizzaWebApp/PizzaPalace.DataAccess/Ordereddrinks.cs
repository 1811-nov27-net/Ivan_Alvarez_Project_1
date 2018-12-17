using System;
using System.Collections.Generic;

namespace PizzaPalace.DataAccess
{
    public partial class Ordereddrinks
    {
        public int Ordereddrinksid { get; set; }
        public int Orderid { get; set; }
        public string Drinkname { get; set; }
        public int Drinkqty { get; set; }
        public double Drinkscost { get; set; }

        public virtual Drinks DrinknameNavigation { get; set; }
        public virtual Orderdetails Order { get; set; }
    }
}
