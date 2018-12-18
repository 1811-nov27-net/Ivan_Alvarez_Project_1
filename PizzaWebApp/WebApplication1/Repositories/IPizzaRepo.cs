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
        Orderdetails Getorderbytime(DateTime time);
        void Createpizzaorder(Orderedpizzas pizzaorder);
        void Createdrinkorder(Ordereddrinks drinkorder);
        void Createsideorder(Orderedsides sideorder);
        void Createhistory(History history);
        void Createlocal(Location local);
        void UpdateCustomdeflocalid(Customer user);
        void Updatedeflocal(Location local);
        //void Updatelocal(Orderdetails order);
        IEnumerable<Orderdetails> Getorderdetsbyid(int id);
        IEnumerable<Orderdetails> GetUsersbystore(int id);
        IEnumerable<Inventorypizzas> Getinventbystore(int id);
        IEnumerable<Orderdetails> Getordersbystore(int id);
       // IEnumerable<Customer> Getcustomerbystore(int id);
        Location Getlocationbyid(int id);
        Inventorypizzas Getinventpizzas(int store, string name);
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
