using System;
using System.Collections.Generic;

namespace PizzaPalace.DataAccess
{
    public partial class Orderedsides
    {
        public int Orderedsidesid { get; set; }
        public int Orderid { get; set; }
        public string Sidename { get; set; }
        public int Sideqty { get; set; }
        public double Sidescost { get; set; }

        public virtual Orderdetails Order { get; set; }
        public virtual Sides SidenameNavigation { get; set; }
    }
}
