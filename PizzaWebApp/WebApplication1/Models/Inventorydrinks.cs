namespace PizzaWebApp.Models
{
    public class Inventorydrinks
    {
        public int Storeid { get; set; }
        public string Drinkname { get; set; }
        public int Itemamount { get; set; }
        public int Inventdrinkid { get; set; }

        public  Drinks DrinknameNavigation { get; set; }
        public  Pizzastore Store { get; set; }
    }
}