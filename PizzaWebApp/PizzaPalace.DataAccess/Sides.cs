using System;
using System.Collections.Generic;

namespace PizzaPalace.DataAccess
{
    public partial class Sides
    {
        public Sides()
        {
            Inventorysides = new HashSet<Inventorysides>();
            Orderedsides = new HashSet<Orderedsides>();
        }

        public string Name { get; set; }
        public double Cost { get; set; }

        public virtual ICollection<Inventorysides> Inventorysides { get; set; }
        public virtual ICollection<Orderedsides> Orderedsides { get; set; }
    }
}
