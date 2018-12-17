using System;
using System.Collections.Generic;

namespace PizzaPalace.DataAccess
{
    public partial class Orderdetails
    {
        public Orderdetails()
        {
            History = new HashSet<History>();
            Ordereddrinks = new HashSet<Ordereddrinks>();
            Orderedpizzas = new HashSet<Orderedpizzas>();
            Orderedsides = new HashSet<Orderedsides>();
        }

        public int Orderid { get; set; }
        public int Customerid { get; set; }
        public int Storeid { get; set; }
        public int Locationid { get; set; }
        public double Totalcost { get; set; }
        public DateTime Dateplaced { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Location Location { get; set; }
        public virtual Pizzastore Store { get; set; }
        public virtual ICollection<History> History { get; set; }
        public virtual ICollection<Ordereddrinks> Ordereddrinks { get; set; }
        public virtual ICollection<Orderedpizzas> Orderedpizzas { get; set; }
        public virtual ICollection<Orderedsides> Orderedsides { get; set; }
    }
}
