namespace PizzaWebApp.Models
{
    public class Ordereddrinks
    {
        public int Ordereddrinksid { get; set; }
        public int Orderid { get; set; }
        public string Drinkname { get; set; }
        public int Drinkqty { get; set; }
        public double Drinkscost { get; set; }

        public  Drinks DrinknameNavigation { get; set; }
        public  Orderdetails Order { get; set; }
    }
}