using System;
using System.Collections.Generic;

namespace PizzaPalace.DataAccess
{
    public partial class Customer
    {
        public Customer()
        {
            History = new HashSet<History>();
            Orderdetails = new HashSet<Orderdetails>();
        }

        public int Userid { get; set; }
        public string Username { get; set; }
        public int Deflocationid { get; set; }
        public bool Haveorder { get; set; }
        public DateTime? Dateplaced { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public virtual Location Deflocation { get; set; }
        public virtual ICollection<History> History { get; set; }
        public virtual ICollection<Orderdetails> Orderdetails { get; set; }
    }
}
