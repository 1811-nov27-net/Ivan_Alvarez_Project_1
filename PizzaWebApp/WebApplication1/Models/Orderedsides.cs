namespace PizzaWebApp.Models
{
    public class Orderedsides
    {
        public int Orderedsidesid { get; set; }
        public int Orderid { get; set; }
        public string Sidename { get; set; }
        public int Sideqty { get; set; }
        public double Sidescost { get; set; }

        public  Orderdetails Order { get; set; }
        public  Sides SidenameNavigation { get; set; }
    }
}