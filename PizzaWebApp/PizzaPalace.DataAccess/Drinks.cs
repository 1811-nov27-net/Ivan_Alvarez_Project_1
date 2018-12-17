using System;
using System.Collections.Generic;

namespace PizzaPalace.DataAccess
{
    public partial class Drinks
    {
        public Drinks()
        {
            Inventorydrinks = new HashSet<Inventorydrinks>();
            Ordereddrinks = new HashSet<Ordereddrinks>();
        }

        public string Name { get; set; }
        public double Cost { get; set; }

        public virtual ICollection<Inventorydrinks> Inventorydrinks { get; set; }
        public virtual ICollection<Ordereddrinks> Ordereddrinks { get; set; }
    }
}
