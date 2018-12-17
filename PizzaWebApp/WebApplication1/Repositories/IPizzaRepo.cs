using PizzaWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebApp.Repositories
{
    public interface IPizzaRepo
    {
        void Save();
        void Createorder(Orderdetails order);
        void Createpizzaorder(Orderedpizzas pizzaorder);
        void Createdrinkorder(Ordereddrinks drinkorder);
        void Createsideorder(Orderedsides sideorder);
        void Createhistory(History history);
        void Createlocal(Location local);
        void UpdateCustomdeflocal(Customer user);
        //void Updatelocal(Orderdetails order);
        void Updateinventpizza(Inventorypizzas inventpizzas);
        void Updateinventdrink(Inventorydrinks inventdrink);
        void Updateinventsides(Inventorysides inventsides);
        //Orderdetails Getsuggestoforderbycustom(Customer user);
        //Orderedpizzas Getsuggestofpizzabycustom(Customer user);
        //Orderedsides Getsuggestofsidebycustom(Customer user);
        //Ordereddrinks Getsuggestofdrinkbycustom(Customer user);
        IEnumerable<History> Gethistory();
        IEnumerable<Customer> Getcustomers();
        IEnumerable<Pizzastore> Getstores();
        IEnumerable<Location> Getlocations();
        IEnumerable<Inventorydrinks> Getinventdrinks();
        IEnumerable<Inventorypizzas> Getinventpizzas();
        IEnumerable<Inventorysides> Getinventsides();
        IEnumerable<Orderdetails> Getorderdetails();
        IEnumerable<Ordereddrinks> Getorderdrinks();
        IEnumerable<Orderedpizzas> Getorderpizzas();
        IEnumerable<Orderedsides> Getordersides();
           

    }
}
