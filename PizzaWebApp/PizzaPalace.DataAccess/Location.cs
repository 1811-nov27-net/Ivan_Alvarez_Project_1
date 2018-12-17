using System;
using System.Collections.Generic;

namespace PizzaPalace.DataAccess
{
    public partial class Location
    {
        public Location()
        {
            Customer = new HashSet<Customer>();
            Orderdetails = new HashSet<Orderdetails>();
        }

        public int Locationid { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public virtual Pizzastore Pizzastore { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<Orderdetails> Orderdetails { get; set; }
    }
}
