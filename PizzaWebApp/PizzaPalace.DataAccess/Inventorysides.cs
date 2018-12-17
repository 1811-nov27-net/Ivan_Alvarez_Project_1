using System;
using System.Collections.Generic;

namespace PizzaPalace.DataAccess
{
    public partial class Inventorysides
    {
        public int Storeid { get; set; }
        public string Sidename { get; set; }
        public int Itemamount { get; set; }
        public int Inventsidesid { get; set; }

        public virtual Sides SidenameNavigation { get; set; }
        public virtual Pizzastore Store { get; set; }
    }
}
