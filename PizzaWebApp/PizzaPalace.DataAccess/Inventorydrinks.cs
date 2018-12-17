using System;
using System.Collections.Generic;

namespace PizzaPalace.DataAccess
{
    public partial class Inventorydrinks
    {
        public int Storeid { get; set; }
        public string Drinkname { get; set; }
        public int Itemamount { get; set; }
        public int Inventdrinkid { get; set; }

        public virtual Drinks DrinknameNavigation { get; set; }
        public virtual Pizzastore Store { get; set; }
    }
}
