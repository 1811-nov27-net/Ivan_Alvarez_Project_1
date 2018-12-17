using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace PizzaPalace.DataAccess
{
    public partial class Pizzastore
    {
        public Pizzastore()
        {
            History = new HashSet<History>();
            Inventorydrinks = new HashSet<Inventorydrinks>();
            Inventorypizzas = new HashSet<Inventorypizzas>();
            Inventorysides = new HashSet<Inventorysides>();
            Orderdetails = new HashSet<Orderdetails>();
        }

        public int Storeid { get; set; }
        public string Name { get; set; }
        public int Locationid { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<History> History { get; set; }
        public virtual ICollection<Inventorydrinks> Inventorydrinks { get; set; }
        public virtual ICollection<Inventorypizzas> Inventorypizzas { get; set; }
        public virtual ICollection<Inventorysides> Inventorysides { get; set; }
        public virtual ICollection<Orderdetails> Orderdetails { get; set; }
    }
}
