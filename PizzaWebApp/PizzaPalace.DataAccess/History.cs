using System;
using System.Collections.Generic;

namespace PizzaPalace.DataAccess
{
    public partial class History
    {
        public int Historyid { get; set; }
        public int Userid { get; set; }
        public int Storeid { get; set; }
        public int Orderid { get; set; }

        public virtual Orderdetails Order { get; set; }
        public virtual Pizzastore Store { get; set; }
        public virtual Customer User { get; set; }
    }
}
