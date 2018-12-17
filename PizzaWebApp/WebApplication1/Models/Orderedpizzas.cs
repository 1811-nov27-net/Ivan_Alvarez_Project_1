namespace PizzaWebApp.Models
{
    public class Orderedpizzas
    {
        public int Orderedpizzasid { get; set; }
        public int Orderid { get; set; }
        public string Pizzaname { get; set; }
        public int Pizzaqty { get; set; }
        public double Pizzascost { get; set; }

        public  Orderdetails Order { get; set; }
        public  Pizzas PizzanameNavigation { get; set; }
    }
}