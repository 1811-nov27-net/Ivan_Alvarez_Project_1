using Microsoft.EntityFrameworkCore;
using PizzaPalace.DataAccess;
using Mods = PizzaWebApp.Models;
using System;
using System.IO;
using System.Security;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data = PizzaPalace.DataAccess;
using System.Text;


namespace PizzaWebApp.Repositories
{
    public class PizzaRepoDB : IPizzaRepo
    {
        public Data.PizzaDBContext _db;

        public PizzaRepoDB(Data.PizzaDBContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));

            db.Database.EnsureCreated();
        }
        public void Save()
        {
            _db.SaveChanges();
        }
        public void Createorder(Mods.Orderdetails order)
        {
            _db.Add(Map(order));
            Save();
        }
        public void Createpizzaorder(Mods.Orderedpizzas pizzaorder)
        {
            _db.Add(Map(pizzaorder));
            Save();

        }
        public void Createdrinkorder(Mods.Ordereddrinks drinkorder)
        {
            _db.Add(Map(drinkorder));
            Save();
        }
        public void Createsideorder(Mods.Orderedsides sideorder)
        {
            _db.Add(Map(sideorder));
            Save();
        }
        public void Createhistory(Mods.History history)
        {
            _db.Add(Map(history));
            Save();
        }
        public void Createlocal(Mods.Location local)
        {
            _db.Add(Map(local));
            Save();
        }
        public void UpdateCustomdeflocal(Mods.Customer user)
        {
            var changedlocal = Map(user);
            _db.Update(changedlocal);
            Save();
        }

        public void Updateinventpizza(Mods.Inventorypizzas inventpizzas)
        {
            var changedpizzainvent = Map(inventpizzas);
            _db.Update(changedpizzainvent);
            Save();
        }
        public void Updateinventdrink(Mods.Inventorydrinks inventdrink)
        {
            var changeddrinkinvent = Map(inventdrink);
            _db.Update(changeddrinkinvent);
            Save();
        }
        public void Updateinventsides(Mods.Inventorysides inventsides)
        {
            var changedsideinvent = Map(inventsides);
            _db.Update(changedsideinvent);
            Save();
        }

        //public void Updatelocal(Mods.Orderdetails order);
        //Orderdetails Getsuggestoforderbycustom(Customer user);
        //Orderedpizzas Getsuggestofpizzabycustom(Customer user);
        //Orderedsides Getsuggestofsidebycustom(Customer user);
        //Ordereddrinks Getsuggestofdrinkbycustom(Customer user);

        public IEnumerable<Mods.History> Gethistory()
        {
            return Map(_db.History.Include(r => r.Order).Include(a => a.Store).Include(b => b.User).AsNoTracking());
        }
        public List<Mods.History> Gethistorylist()
        {
            var list = Gethistory().ToList();
            return list;
        }
        public IEnumerable<Mods.Customer> Getcustomers()
        {
            return Map(_db.Customer.Include(r => r.Deflocation).Include(a => a.History).Include(b => b.Orderdetails).AsNoTracking());
        }
        public List<Mods.Customer> Getcustomerlist()
        {
            var list = Getcustomers().ToList();
            return list;
        }
        public IEnumerable<Mods.Pizzastore> Getstores()
        {
            return Map(_db.Pizzastore.Include(r => r.Location).Include(a => a.History).
             Include(c => c.Inventorydrinks).Include(d => d.Inventorypizzas).Include(f => f.Inventorysides).
            Include(t => t.Orderdetails).AsNoTracking());
        }
        public List<Mods.Pizzastore> Getstoreslist()
        {
            var list = Getstores().ToList();
            return list;
        }
        public IEnumerable<Mods.Location> Getlocations()
        {
            return Map(_db.Location.Include(r => r.Pizzastore).Include(a => a.Customer).
             Include(c => c.Orderdetails).AsNoTracking());
        }
        public List<Mods.Location> Getlocationslist()
        {
            var list = Getlocations().ToList();
            return list;
        }
        public IEnumerable<Mods.Inventorydrinks> Getinventdrinks()
        {
            return Map(_db.Inventorydrinks.Include(a => a.DrinknameNavigation).Include(b => b.Store).AsNoTracking());
        }
        public List<Mods.Inventorydrinks> Getinventdrinkslist()
        {
            var list = Getinventdrinks().ToList();
            return list;
        }
        public IEnumerable<Mods.Inventorypizzas> Getinventpizzas()
        {
            return Map(_db.Inventorypizzas.Include(a => a.PizzanameNavigation).Include(b => b.Store).AsNoTracking());

        }
        public List<Mods.Inventorypizzas> Getinventpizzaslist()
        {
            var list = Getinventpizzas().ToList();
            return list;
        }
        public IEnumerable<Mods.Inventorysides> Getinventsides()
        {
            return Map(_db.Inventorysides.Include(a => a.SidenameNavigation).Include(b => b.Store).AsNoTracking());

        }
        public List<Mods.Inventorysides> Getinventsideslist()
        {
            var list = Getinventsides().ToList();
            return list;
        }
        public IEnumerable<Mods.Orderdetails> Getorderdetails()
        {
            return Map(_db.Orderdetails.Include(a => a.Customer).Include(b => b.Location).Include(c => c.Store).
                Include(d => d.History).Include(e => e.Ordereddrinks).Include(f => f.Orderedpizzas).
                Include(g => g.Orderedsides).AsNoTracking());
        }
        public List<Mods.Orderdetails> Getorderdetslist()
        {
            var list = Getorderdetails().ToList();
            return list;
        }
        public IEnumerable<Mods.Ordereddrinks> Getorderdrinks()
        {
            return Map(_db.Ordereddrinks.Include(a => a.DrinknameNavigation).Include(b => b.Order).AsNoTracking());
        }
        public List<Mods.Ordereddrinks> Getorderdrinkslist()
        {
            var list = Getorderdrinks().ToList();
            return list;
        }
        public IEnumerable<Mods.Orderedpizzas> Getorderpizzas()
        {
            return Map(_db.Orderedpizzas.Include(a => a.PizzanameNavigation).Include(b => b.Order).AsNoTracking());

        }
        public List<Mods.Orderedpizzas> Getorderpizzaslist()
        {
            var list = Getorderpizzas().ToList();
            return list;
        }
        public IEnumerable<Mods.Orderedsides> Getordersides()
        {
            return Map(_db.Orderedsides.Include(a => a.SidenameNavigation).Include(b => b.Order).AsNoTracking());
        }
        public List<Mods.Orderedsides> Getordersideslist()
        {
            var list = Getordersides().ToList();
            return list;
        }


        public static PizzaWebApp.Models.Customer Map(Customer customer) => new PizzaWebApp.Models.Customer
        {
            Userid = customer.Userid,
            Username = customer.Username,
            Deflocationid = customer.Deflocationid,
            Haveorder = customer.Haveorder,
            Dateplaced = customer.Dateplaced,
            Firstname = customer.Firstname,
            Latname = customer.Lastname,
            Deflocation = Map(customer.Deflocation),
            History = Map(customer.History).ToList(),
            Orderdetails = Map(customer.Orderdetails).ToList(),
        };

        public static Customer Map(PizzaWebApp.Models.Customer customer) => new Customer
        {
            Userid = customer.Userid,
            Username = customer.Username,
            Deflocationid = customer.Deflocationid,
            Haveorder = customer.Haveorder,
            Dateplaced = customer.Dateplaced,
            Firstname = customer.Firstname,
            Lastname = customer.Latname,
            Deflocation = Map(customer.Deflocation),
            History = Map(customer.History).ToList(),
            Orderdetails = Map(customer.Orderdetails).ToList(),
        };

        public static PizzaWebApp.Models.Drinks Map(Drinks drinks) => new PizzaWebApp.Models.Drinks
        {
            Name = drinks.Name,
            Cost = drinks.Cost,
            Inventorydrinks = Map(drinks.Inventorydrinks).ToList(),
            Ordereddrinks = Map(drinks.Ordereddrinks).ToList(),
            
        };

        public static Drinks Map(PizzaWebApp.Models.Drinks drinks) => new Drinks
        {
            Name = drinks.Name,
            Cost = drinks.Cost,
            Inventorydrinks = Map(drinks.Inventorydrinks).ToList(),
            Ordereddrinks = Map(drinks.Ordereddrinks).ToList(),
        };

        public static PizzaWebApp.Models.History Map(History history) => new PizzaWebApp.Models.History
        {
            Historyid = history.Historyid,
            Userid = history.Userid,
            Storeid = history.Storeid,
            Orderid = history.Orderid,
            Order = Map(history.Order),
            Store = Map(history.Store),
            User = Map(history.User),
        };

        public static History Map(PizzaWebApp.Models.History history) => new History
        {
            Historyid = history.Historyid,
            Userid = history.Userid,
            Storeid = history.Storeid,
            Orderid = history.Orderid,
            Order = Map(history.Order),
            Store = Map(history.Store),
            User = Map(history.User),
        };

        public static PizzaWebApp.Models.Inventorydrinks Map(Inventorydrinks inventorydrinks) => new PizzaWebApp.Models.Inventorydrinks
        {
            Storeid = inventorydrinks.Storeid,
            Drinkname = inventorydrinks.Drinkname,
            Itemamount = inventorydrinks.Itemamount,
            Inventdrinkid = inventorydrinks.Inventdrinkid,
            DrinknameNavigation = Map(inventorydrinks.DrinknameNavigation),
            Store = Map(inventorydrinks.Store),
        };

        public static Inventorydrinks Map(PizzaWebApp.Models.Inventorydrinks inventorydrinks) => new Inventorydrinks
        {
            Storeid = inventorydrinks.Storeid,
            Drinkname = inventorydrinks.Drinkname,
            Itemamount = inventorydrinks.Itemamount,
            Inventdrinkid = inventorydrinks.Inventdrinkid,
            DrinknameNavigation = Map(inventorydrinks.DrinknameNavigation),
            Store = Map(inventorydrinks.Store),
        };

        public static PizzaWebApp.Models.Inventorypizzas Map(Inventorypizzas inventorypizzas) => new PizzaWebApp.Models.Inventorypizzas
        {
            Storeid = inventorypizzas.Storeid,
            Pizzaname = inventorypizzas.Pizzaname,
            Itemamount = inventorypizzas.Itemamount,
            Inventpizzasid = inventorypizzas.Inventpizzasid,
            PizzanameNavigation = Map(inventorypizzas.PizzanameNavigation),
            Store = Map(inventorypizzas.Store),
        };

        public static Inventorypizzas Map(PizzaWebApp.Models.Inventorypizzas inventorypizzas) => new Inventorypizzas
        {
            Storeid = inventorypizzas.Storeid,
            Pizzaname = inventorypizzas.Pizzaname,
            Itemamount = inventorypizzas.Itemamount,
            Inventpizzasid = inventorypizzas.Inventpizzasid,
            PizzanameNavigation = Map(inventorypizzas.PizzanameNavigation),
            Store = Map(inventorypizzas.Store),
        };

        public static PizzaWebApp.Models.Inventorysides Map(Inventorysides inventorysides) => new PizzaWebApp.Models.Inventorysides
        {
            Storeid = inventorysides.Storeid,
            Sidename = inventorysides.Sidename,
            Itemamount = inventorysides.Itemamount,
            Inventsidesid = inventorysides.Inventsidesid,
            SidenameNavigation = Map(inventorysides.SidenameNavigation),
            Store = Map(inventorysides.Store),
        };

        public static Inventorysides Map(PizzaWebApp.Models.Inventorysides inventorysides) => new Inventorysides
        {
            Storeid = inventorysides.Storeid,
            Sidename = inventorysides.Sidename,
            Itemamount = inventorysides.Itemamount,
            Inventsidesid = inventorysides.Inventsidesid,
            SidenameNavigation = Map(inventorysides.SidenameNavigation),
            Store = Map(inventorysides.Store),
        };

        public static PizzaWebApp.Models.Location Map(Location location) => new PizzaWebApp.Models.Location
        {
            Locationid = location.Locationid,
            State = location.State,
            Street = location.Street,
            City = location.City,
            Pizzastore = Map(location.Pizzastore),
            Customer = Map(location.Customer).ToList(),
            Orderdetails = Map(location.Orderdetails).ToList(),
        };

        public static Location Map(PizzaWebApp.Models.Location location) => new Location
        {
            Locationid = location.Locationid,
            Street = location.Street,
            State = location.State,
            City = location.City,
            Pizzastore = Map(location.Pizzastore),
            Customer = Map(location.Customer).ToList(),
            Orderdetails = Map(location.Orderdetails).ToList(),
        };

        public static PizzaWebApp.Models.Orderdetails Map(Orderdetails orderdetails) => new PizzaWebApp.Models.Orderdetails
        {
            Orderid = orderdetails.Orderid,
            Customerid = orderdetails.Customerid,
            Storeid = orderdetails.Storeid,
            Locationid = orderdetails.Locationid,
            Totalcost = orderdetails.Totalcost,
            Dateplaced = orderdetails.Dateplaced,
            Customer = Map(orderdetails.Customer),
            Location = Map(orderdetails.Location),
            Store = Map(orderdetails.Store),
            History = Map(orderdetails.History).ToList(),
            Ordereddrinks = Map(orderdetails.Ordereddrinks).ToList(),
            Orderedpizzas = Map(orderdetails.Orderedpizzas).ToList(),
            Orderedsides = Map(orderdetails.Orderedsides).ToList(),
        };

        public static Orderdetails Map(PizzaWebApp.Models.Orderdetails orderdetails) => new Orderdetails
        {
            Orderid = orderdetails.Orderid,
            Customerid = orderdetails.Customerid,
            Storeid = orderdetails.Storeid,
            Locationid = orderdetails.Locationid,        
            Totalcost = orderdetails.Totalcost,
            Dateplaced = orderdetails.Dateplaced,
            Customer = Map(orderdetails.Customer),
            Location = Map(orderdetails.Location),
            Store = Map(orderdetails.Store),
            History = Map(orderdetails.History).ToList(),
            Ordereddrinks = Map(orderdetails.Ordereddrinks).ToList(),
            Orderedpizzas = Map(orderdetails.Orderedpizzas).ToList(),
            Orderedsides = Map(orderdetails.Orderedsides).ToList(),
        };

        public static PizzaWebApp.Models.Ordereddrinks Map(Ordereddrinks ordereddrinks) => new PizzaWebApp.Models.Ordereddrinks
        {
            Ordereddrinksid = ordereddrinks.Ordereddrinksid,
            Orderid = ordereddrinks.Orderid,
            Drinkname = ordereddrinks.Drinkname,
            Drinkqty  = ordereddrinks.Drinkqty,
            Drinkscost = ordereddrinks.Drinkscost,
            DrinknameNavigation = Map(ordereddrinks.DrinknameNavigation),
            Order = Map(ordereddrinks.Order),
        };

        public static Ordereddrinks Map(PizzaWebApp.Models.Ordereddrinks ordereddrinks) => new Ordereddrinks
        {
            Ordereddrinksid = ordereddrinks.Ordereddrinksid,
            Orderid = ordereddrinks.Orderid,
            Drinkname = ordereddrinks.Drinkname,
            Drinkqty = ordereddrinks.Drinkqty,
            Drinkscost = ordereddrinks.Drinkscost,
            DrinknameNavigation = Map(ordereddrinks.DrinknameNavigation),
            Order = Map(ordereddrinks.Order),
        };

        public static PizzaWebApp.Models.Orderedpizzas Map(Orderedpizzas orderedpizzas) => new PizzaWebApp.Models.Orderedpizzas
        {
            Orderedpizzasid = orderedpizzas.Orderedpizzasid,
            Orderid = orderedpizzas.Orderid,
            Pizzaname = orderedpizzas.Pizzaname,
            Pizzaqty = orderedpizzas.Pizzaqty,
            Pizzascost = orderedpizzas.Pizzascost,
            PizzanameNavigation = Map(orderedpizzas.PizzanameNavigation),
            Order = Map(orderedpizzas.Order),
        };

        public static Orderedpizzas Map(PizzaWebApp.Models.Orderedpizzas orderedpizzas) => new Orderedpizzas
        {
            Orderedpizzasid = orderedpizzas.Orderedpizzasid,
            Orderid = orderedpizzas.Orderid,
            Pizzaname = orderedpizzas.Pizzaname,
            Pizzaqty = orderedpizzas.Pizzaqty,
            Pizzascost = orderedpizzas.Pizzascost,
            PizzanameNavigation = Map(orderedpizzas.PizzanameNavigation),
            Order = Map(orderedpizzas.Order),
        };

        public static PizzaWebApp.Models.Orderedsides Map(Orderedsides orderedsides) => new PizzaWebApp.Models.Orderedsides
        {
            Orderedsidesid = orderedsides.Orderedsidesid,
            Orderid = orderedsides.Orderid,
            Sidename = orderedsides.Sidename,
            Sideqty = orderedsides.Sideqty,
            Sidescost = orderedsides.Sidescost,
            SidenameNavigation = Map(orderedsides.SidenameNavigation),
            Order = Map(orderedsides.Order),
        };

        public static Orderedsides Map(PizzaWebApp.Models.Orderedsides orderedsides) => new Orderedsides
        {
            Orderedsidesid = orderedsides.Orderedsidesid,
            Orderid = orderedsides.Orderid,
            Sidename = orderedsides.Sidename,
            Sideqty = orderedsides.Sideqty,
            Sidescost = orderedsides.Sidescost,
            SidenameNavigation = Map(orderedsides.SidenameNavigation),
            Order = Map(orderedsides.Order),
        };

        public static PizzaWebApp.Models.Pizzas Map(Pizzas pizzas) => new PizzaWebApp.Models.Pizzas
        {
            Name = pizzas.Name,
            Cost = pizzas.Cost,
            Inventorypizzas = Map(pizzas.Inventorypizzas).ToList(),
            Orderedpizzas = Map(pizzas.Orderedpizzas).ToList(),
        };

        public static Pizzas Map(PizzaWebApp.Models.Pizzas pizzas) => new Pizzas
        {
            Name = pizzas.Name,
            Cost = pizzas.Cost,
            Inventorypizzas = Map(pizzas.Inventorypizzas).ToList(),
            Orderedpizzas = Map(pizzas.Orderedpizzas).ToList(),
        };

        public static PizzaWebApp.Models.Sides Map(Sides sides) => new PizzaWebApp.Models.Sides
        {
            Name = sides.Name,
            Cost = sides.Cost,
            Inventorysides = Map(sides.Inventorysides).ToList(),
            Orderedsides = Map(sides.Orderedsides).ToList(),
        };

        public static Sides Map(PizzaWebApp.Models.Sides sides) => new Sides
        {
            Name = sides.Name,
            Cost = sides.Cost,
            Inventorysides = Map(sides.Inventorysides).ToList(),
            Orderedsides = Map(sides.Orderedsides).ToList(),
        };

        public static PizzaWebApp.Models.Pizzastore Map(Pizzastore pizzastore) => new PizzaWebApp.Models.Pizzastore
        {
            Storeid = pizzastore.Storeid,
            Name = pizzastore.Name,
            Locationid = pizzastore.Locationid,
            Location = Map(pizzastore.Location),
            History = Map(pizzastore.History).ToList(),
            Inventorysides = Map(pizzastore.Inventorysides).ToList(),
            Inventorypizzas = Map(pizzastore.Inventorypizzas).ToList(),
            Inventorydrinks = Map(pizzastore.Inventorydrinks).ToList(),
            Orderdetails = Map(pizzastore.Orderdetails).ToList(),
        };

        public static Pizzastore Map(PizzaWebApp.Models.Pizzastore pizzastore) => new Pizzastore
        {
            Storeid = pizzastore.Storeid,
            Name = pizzastore.Name,
            Locationid = pizzastore.Locationid,
            Location = Map(pizzastore.Location),
            History = Map(pizzastore.History).ToList(),
            Inventorysides = Map(pizzastore.Inventorysides).ToList(),
            Inventorypizzas = Map(pizzastore.Inventorypizzas).ToList(),
            Inventorydrinks = Map(pizzastore.Inventorydrinks).ToList(),
            Orderdetails = Map(pizzastore.Orderdetails).ToList(),
        };

        public static IEnumerable<PizzaWebApp.Models.History> Map(IEnumerable<History> histories) => histories.Select(Map);
        public static IEnumerable<History> Map(IEnumerable<PizzaWebApp.Models.History> histories) => histories.Select(Map);

        public static IEnumerable<PizzaWebApp.Models.Orderdetails> Map(IEnumerable<Orderdetails> orderdetails) => orderdetails.Select(Map);
        public static IEnumerable<Orderdetails> Map(IEnumerable<PizzaWebApp.Models.Orderdetails> orderdetails) => orderdetails.Select(Map);

        public static IEnumerable<PizzaWebApp.Models.Inventorydrinks> Map(IEnumerable<Inventorydrinks> inventorydrinks) => inventorydrinks.Select(Map);
        public static IEnumerable<Inventorydrinks> Map(IEnumerable<PizzaWebApp.Models.Inventorydrinks> inventorydrinks) => inventorydrinks.Select(Map);

        public static IEnumerable<PizzaWebApp.Models.Inventorypizzas> Map(IEnumerable<Inventorypizzas> inventorypizzas) => inventorypizzas.Select(Map);
        public static IEnumerable<Inventorypizzas> Map(IEnumerable<PizzaWebApp.Models.Inventorypizzas> inventorypizzas) => inventorypizzas.Select(Map);

        public static IEnumerable<PizzaWebApp.Models.Inventorysides> Map(IEnumerable<Inventorysides> inventorysides) => inventorysides.Select(Map);
        public static IEnumerable<Inventorysides> Map(IEnumerable<PizzaWebApp.Models.Inventorysides> inventorysides) => inventorysides.Select(Map);

        public static IEnumerable<PizzaWebApp.Models.Ordereddrinks> Map(IEnumerable<Ordereddrinks> ordereddrinks) => ordereddrinks.Select(Map);
        public static IEnumerable<Ordereddrinks> Map(IEnumerable<PizzaWebApp.Models.Ordereddrinks> ordereddrinks) => ordereddrinks.Select(Map);

        public static IEnumerable<PizzaWebApp.Models.Orderedpizzas> Map(IEnumerable<Orderedpizzas> orderedpizzas) => orderedpizzas.Select(Map);
        public static IEnumerable<Orderedpizzas> Map(IEnumerable<PizzaWebApp.Models.Orderedpizzas> orderedpizzas) => orderedpizzas.Select(Map);

        public static IEnumerable<PizzaWebApp.Models.Orderedsides> Map(IEnumerable<Orderedsides> orderedsides) => orderedsides.Select(Map);
        public static IEnumerable<Orderedsides> Map(IEnumerable<PizzaWebApp.Models.Orderedsides> orderedsides) => orderedsides.Select(Map);

        public static IEnumerable<PizzaWebApp.Models.Customer> Map(IEnumerable<Customer> customers) => customers.Select(Map);
        public static IEnumerable<Customer> Map(IEnumerable<PizzaWebApp.Models.Customer> customers) => customers.Select(Map);

        public static IEnumerable<PizzaWebApp.Models.Drinks> Map(IEnumerable<Drinks> drinks) => drinks.Select(Map);
        public static IEnumerable<Drinks> Map(IEnumerable<PizzaWebApp.Models.Drinks> drinks) => drinks.Select(Map);

        public static IEnumerable<PizzaWebApp.Models.Pizzas> Map(IEnumerable<Pizzas> pizzas) => pizzas.Select(Map);
        public static IEnumerable<Pizzas> Map(IEnumerable<PizzaWebApp.Models.Pizzas> pizzas) => pizzas.Select(Map);

        public static IEnumerable<PizzaWebApp.Models.Sides> Map(IEnumerable<Sides> sides) => sides.Select(Map);
        public static IEnumerable<Sides> Map(IEnumerable<PizzaWebApp.Models.Sides> sides) => sides.Select(Map);

        public static IEnumerable<PizzaWebApp.Models.Location> Map(IEnumerable<Location> locations) => locations.Select(Map);
        public static IEnumerable<Location> Map(IEnumerable<PizzaWebApp.Models.Location> locations) => locations.Select(Map);

        public static IEnumerable<PizzaWebApp.Models.Pizzastore> Map(IEnumerable<Pizzastore> pizzastores) => pizzastores.Select(Map);
        public static IEnumerable<Pizzastore> Map(IEnumerable<PizzaWebApp.Models.Pizzastore> pizzastores) => pizzastores.Select(Map);
    }
}
