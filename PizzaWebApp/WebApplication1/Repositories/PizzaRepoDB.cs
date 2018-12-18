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
            _db.Add(CreateMap(order));
            Save();
        }
        public Data.Orderdetails CreateMap(Mods.Orderdetails order) => new Data.Orderdetails
        {
            Orderid = order.Orderid,
            Customerid = order.Customerid,
            Storeid = order.Storeid,
            Locationid = order.Locationid,
            Totalcost = order.Totalcost,
            Dateplaced = order.Dateplaced,
        };

        public Mods.Orderdetails Getorderbytime(DateTime time)
        {
            return TimeorderMap(_db.Orderdetails.Where(c => c.Dateplaced == time).First());
        }
        public static Mods.Orderdetails TimeorderMap(Data.Orderdetails order) => new Mods.Orderdetails
        {
            Orderid = order.Orderid,
            Customerid = order.Customerid,
            Storeid = order.Storeid,
            Locationid = order.Locationid,
            Totalcost = order.Totalcost,
            Dateplaced = order.Dateplaced,
        };
        public static Data.Orderdetails TimeorderMap(Mods.Orderdetails order) => new Data.Orderdetails
        {
            Orderid = order.Orderid,
            Customerid = order.Customerid,
            Storeid = order.Storeid,
            Locationid = order.Locationid,
            Totalcost = order.Totalcost,
            Dateplaced = order.Dateplaced,
        };

        public void Createpizzaorder(Mods.Orderedpizzas pizzaorder)
        {
            _db.Add(CreateMap(pizzaorder));
            Save();

        }
        public Data.Orderedpizzas CreateMap(Mods.Orderedpizzas pizza) => new Data.Orderedpizzas
        {
            Orderedpizzasid = pizza.Orderedpizzasid,
            Orderid = pizza.Orderid,
            Pizzaname = pizza.Pizzaname,
            Pizzaqty = pizza.Pizzaqty,
            Pizzascost = pizza.Pizzascost,
        };


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
        public void UpdateCustomdeflocalid(Mods.Customer user)
        {
            var changedlocal = CustomMap(user);
            _db.Update(changedlocal);
            Save();
        }
        public void Updatedeflocal(Mods.Location local)
        {
            var newlocal = CustomlocalMap2(local);
            _db.Update(newlocal);
            Save();
        }
        public Mods.Inventorypizzas Getinventpizzas(int store, string name)
        {
            return InventMap(_db.Inventorypizzas.Where(c => c.Pizzaname == name && c.Storeid == store).First());
        }
        public static PizzaWebApp.Models.Inventorypizzas InventMap(Data.Inventorypizzas inventorypizzas) => new PizzaWebApp.Models.Inventorypizzas
        {
            Storeid = inventorypizzas.Storeid,
            Pizzaname = inventorypizzas.Pizzaname,
            Itemamount = inventorypizzas.Itemamount,
            Inventpizzasid = inventorypizzas.Inventpizzasid,
        };

        public static Data.Inventorypizzas InventMap(PizzaWebApp.Models.Inventorypizzas inventorypizzas) => new Data.Inventorypizzas
        {
            Storeid = inventorypizzas.Storeid,
            Pizzaname = inventorypizzas.Pizzaname,
            Itemamount = inventorypizzas.Itemamount,
            Inventpizzasid = inventorypizzas.Inventpizzasid,
        };
        public void Updateinventpizza(Mods.Inventorypizzas inventpizzas)
        {
            Data.Inventorypizzas changedpizzainvent = UpdateMap(inventpizzas);
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

        public Mods.Location Getlocationbyid(int id)
        {
            return CustomlocalMap2(_db.Location.Where(c => c.Locationid == id).First());
        }


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
        public IEnumerable<Mods.Orderdetails> Getorderdetsbyid(int id)
        {
            return CustomdetsMap(_db.Orderdetails.Where(c => c.Customerid == id).AsNoTracking());
        }
        public IEnumerable<Mods.Orderdetails> GetUsersbystore(int id)
        {
            return StoredetsMap(_db.Orderdetails.Where(c => c.Storeid == id).AsNoTracking());
        }
        public static Mods.Orderdetails StoredetsMap(Data.Orderdetails dets) => new Mods.Orderdetails
        {
            Orderid = dets.Orderid,
            Customerid = dets.Customerid,
            Storeid = dets.Storeid,
            Locationid = dets.Locationid,
            Totalcost = dets.Totalcost,
            Dateplaced = dets.Dateplaced,
        };
        public static Data.Orderdetails StoredetsMap(Mods.Orderdetails dets) => new Data.Orderdetails
        {
            Orderid = dets.Orderid,
            Customerid = dets.Customerid,
            Storeid = dets.Storeid,
            Locationid = dets.Locationid,
            Totalcost = dets.Totalcost,
            Dateplaced = dets.Dateplaced,
        };
        public static IEnumerable<PizzaWebApp.Models.Orderdetails> StoredetsMap(IEnumerable<Data.Orderdetails> orderdetails) => orderdetails.Select(StoredetsMap);
        public static IEnumerable<Data.Orderdetails> StoredetsMap(IEnumerable<PizzaWebApp.Models.Orderdetails> orderdetails) => orderdetails.Select(StoredetsMap);

        public IEnumerable<Mods.Inventorypizzas> Getinventbystore(int id)
        {
            return StoreinventMap(_db.Inventorypizzas.Where(c => c.Storeid == id).AsNoTracking());
        }
        public static Mods.Inventorypizzas StoreinventMap(Data.Inventorypizzas inventpizzas) => new Mods.Inventorypizzas
        {
            Storeid = inventpizzas.Storeid,
            Pizzaname = inventpizzas.Pizzaname,
            Itemamount = inventpizzas.Itemamount,
            Inventpizzasid = inventpizzas.Inventpizzasid,
        };
        public static Data.Inventorypizzas StoreinventMap(Mods.Inventorypizzas inventpizzas) => new Data.Inventorypizzas
        {
            Storeid = inventpizzas.Storeid,
            Pizzaname = inventpizzas.Pizzaname,
            Itemamount = inventpizzas.Itemamount,
            Inventpizzasid = inventpizzas.Inventpizzasid,
        };
        public static IEnumerable<PizzaWebApp.Models.Inventorypizzas> StoreinventMap(IEnumerable<Data.Inventorypizzas> inventorypizzas) => inventorypizzas.Select(StoreinventMap);
        public static IEnumerable<Data.Inventorypizzas> StoreinventMap(IEnumerable<PizzaWebApp.Models.Inventorypizzas> inventorypizzas) => inventorypizzas.Select(StoreinventMap);


        public List<Mods.Customer> Getcustomerlist()
        {
            var list = Getcustomers().ToList();
            return list;
        }
        public IEnumerable<Mods.Pizzastore> Getstores()
        {
            return Map(_db.Pizzastore.Include(r => r.Location).AsNoTracking());
        }
        public IEnumerable<Mods.Orderdetails> Getordersbystore(int id)
        {
            return StoreorderMap(_db.Orderdetails.Where(c => c.Storeid == id).AsNoTracking());
        }
        public static  Mods.Orderdetails StoreorderMap(Data.Orderdetails dets) => new Mods.Orderdetails
        {
            Orderid = dets.Orderid,
            Customerid = dets.Customerid,
            Storeid = dets.Storeid,
            Locationid = dets.Locationid,
            Totalcost = dets.Totalcost,
            Dateplaced = dets.Dateplaced,
        };
        public static Data.Orderdetails StoreorderMap(Mods.Orderdetails dets) => new Data.Orderdetails
        {
            Orderid = dets.Orderid,
            Customerid = dets.Customerid,
            Storeid = dets.Storeid,
            Locationid = dets.Locationid,
            Totalcost = dets.Totalcost,
            Dateplaced = dets.Dateplaced,
        };
        public static IEnumerable<PizzaWebApp.Models.Orderdetails> StoreorderMap(IEnumerable<Data.Orderdetails> orderdetails) => orderdetails.Select(StoreorderMap);
        public static IEnumerable<Data.Orderdetails> StoreorderMap(IEnumerable<PizzaWebApp.Models.Orderdetails> orderdetails) => orderdetails.Select(StoreorderMap);


        //public static IEnumerable<Mods.Customer> Getcustomerbystore(int id)
        //{
        //    return StorecustomMap(_db.)
        //}


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


        public static PizzaWebApp.Models.Customer CustomMap(Data.Customer customer) => new PizzaWebApp.Models.Customer
        {
            Userid = customer.Userid,
            Username = customer.Username,
            Deflocationid = customer.Deflocationid,
            Haveorder = customer.Haveorder,
            Dateplaced = customer.Dateplaced,
            Firstname = customer.Firstname,
            Latname = customer.Lastname,
            Deflocation = CustomlocalMap(customer.Deflocation),
            History = CustomhistMap(customer.History).ToList(),
            Orderdetails = CustomdetsMap(customer.Orderdetails).ToList(),
        };
        public static Mods.Location CustomlocalMap(Data.Location local) => new Mods.Location
        {
            Locationid = local.Locationid,
            State = local.State,
            Street = local.Street,
            City = local.City,
        };
        public static Mods.Location CustomlocalMap2(Data.Location local) => new Mods.Location
        {
            Locationid = local.Locationid,
            State = local.State,
            Street = local.Street,
            City = local.City,
        };
        public static Data.Location CustomlocalMap2(Mods.Location local) => new Data.Location
        {
            Locationid = local.Locationid,
            State = local.State,
            Street = local.Street,
            City = local.City,
        };
        public static Mods.History CustomhistMap(Data.History hist) => new Mods.History
        {
            Historyid = hist.Historyid,
            Userid = hist.Userid,
            Storeid = hist.Storeid,
            Orderid = hist.Orderid,
        };
        public static Mods.Orderdetails CustomdetsMap(Data.Orderdetails dets) => new Mods.Orderdetails
        {
            Orderid = dets.Orderid,
            Customerid = dets.Customerid,
            Storeid = dets.Storeid,
            Locationid = dets.Locationid,
            Totalcost = dets.Totalcost,
            Dateplaced = dets.Dateplaced,
        };
        public static Data.Customer CustomMap(PizzaWebApp.Models.Customer customer) => new Data.Customer
        {
            Userid = customer.Userid,
            Username = customer.Username,
            Deflocationid = customer.Deflocationid,
            Haveorder = customer.Haveorder,
            Dateplaced = customer.Dateplaced,
            Firstname = customer.Firstname,
            Lastname = customer.Latname,
            Deflocation = CustomlocalMap(customer.Deflocation),
            History = CustomhistMap(customer.History).ToList(),
            Orderdetails = CustomdetsMap(customer.Orderdetails).ToList(),
        };
        public static Data.Location CustomlocalMap(Mods.Location local) => new Data.Location
        {
            Locationid = local.Locationid,
            State = local.State,
            Street = local.Street,
            City = local.City,
        };
        public static Data.History CustomhistMap(Mods.History hist) => new Data.History
        {
            Historyid = hist.Historyid,
            Userid = hist.Userid,
            Storeid = hist.Storeid,
            Orderid = hist.Orderid,
        };
        public static Data.Orderdetails CustomdetsMap(Mods.Orderdetails dets) => new Data.Orderdetails
        {
            Orderid = dets.Orderid,
            Customerid = dets.Customerid,
            Storeid = dets.Storeid,
            Locationid = dets.Locationid,
            Totalcost = dets.Totalcost,
            Dateplaced = dets.Dateplaced,
        };

        public static PizzaWebApp.Models.Drinks Map(Data.Drinks drinks) => new PizzaWebApp.Models.Drinks
        {
            Name = drinks.Name,
            Cost = drinks.Cost,
            Inventorydrinks = Map(drinks.Inventorydrinks).ToList(),
            Ordereddrinks = Map(drinks.Ordereddrinks).ToList(),
            
        };

        public static Data.Drinks Map(PizzaWebApp.Models.Drinks drinks) => new Data.Drinks
        {
            Name = drinks.Name,
            Cost = drinks.Cost,
            Inventorydrinks = Map(drinks.Inventorydrinks).ToList(),
            Ordereddrinks = Map(drinks.Ordereddrinks).ToList(),
        };

        public static PizzaWebApp.Models.History Map(Data.History history) => new PizzaWebApp.Models.History
        {
            Historyid = history.Historyid,
            Userid = history.Userid,
            Storeid = history.Storeid,
            Orderid = history.Orderid,
            Order = Map(history.Order),
            Store = Map(history.Store),
            User = CustomMap(history.User),
        };

        public static Data.History Map(PizzaWebApp.Models.History history) => new Data.History
        {
            Historyid = history.Historyid,
            Userid = history.Userid,
            Storeid = history.Storeid,
            Orderid = history.Orderid,
            Order = Map(history.Order),
            Store = Map(history.Store),
            User = CustomMap(history.User),
        };

        public static PizzaWebApp.Models.Inventorydrinks Map(Data.Inventorydrinks inventorydrinks) => new PizzaWebApp.Models.Inventorydrinks
        {
            Storeid = inventorydrinks.Storeid,
            Drinkname = inventorydrinks.Drinkname,
            Itemamount = inventorydrinks.Itemamount,
            Inventdrinkid = inventorydrinks.Inventdrinkid,
            DrinknameNavigation = Map(inventorydrinks.DrinknameNavigation),
            Store = Map(inventorydrinks.Store),
        };

        public static Data.Inventorydrinks Map(PizzaWebApp.Models.Inventorydrinks inventorydrinks) => new Data.Inventorydrinks
        {
            Storeid = inventorydrinks.Storeid,
            Drinkname = inventorydrinks.Drinkname,
            Itemamount = inventorydrinks.Itemamount,
            Inventdrinkid = inventorydrinks.Inventdrinkid,
            DrinknameNavigation = Map(inventorydrinks.DrinknameNavigation),
            Store = Map(inventorydrinks.Store),
        };

        public static PizzaWebApp.Models.Inventorypizzas UpdateMap(Data.Inventorypizzas inventorypizzas) => new PizzaWebApp.Models.Inventorypizzas
        {
            Storeid = inventorypizzas.Storeid,
            Pizzaname = inventorypizzas.Pizzaname,
            Itemamount = inventorypizzas.Itemamount,
            Inventpizzasid = inventorypizzas.Inventpizzasid,
        };

        public static Data.Inventorypizzas UpdateMap(PizzaWebApp.Models.Inventorypizzas inventorypizzas) => new Data.Inventorypizzas
        {
            Storeid = inventorypizzas.Storeid,
            Pizzaname = inventorypizzas.Pizzaname,
            Itemamount = inventorypizzas.Itemamount,
            Inventpizzasid = inventorypizzas.Inventpizzasid,
        };

        public static PizzaWebApp.Models.Inventorysides Map(Data.Inventorysides inventorysides) => new PizzaWebApp.Models.Inventorysides
        {
            Storeid = inventorysides.Storeid,
            Sidename = inventorysides.Sidename,
            Itemamount = inventorysides.Itemamount,
            Inventsidesid = inventorysides.Inventsidesid,
            SidenameNavigation = Map(inventorysides.SidenameNavigation),
            Store = Map(inventorysides.Store),
        };

        public static Data.Inventorysides Map(PizzaWebApp.Models.Inventorysides inventorysides) => new Data.Inventorysides
        {
            Storeid = inventorysides.Storeid,
            Sidename = inventorysides.Sidename,
            Itemamount = inventorysides.Itemamount,
            Inventsidesid = inventorysides.Inventsidesid,
            SidenameNavigation = Map(inventorysides.SidenameNavigation),
            Store = Map(inventorysides.Store),
        };

        public static PizzaWebApp.Models.Location Map(Data.Location location) => new PizzaWebApp.Models.Location
        {
            Locationid = location.Locationid,
            State = location.State,
            Street = location.Street,
            City = location.City,
            Pizzastore = Map(location.Pizzastore),
            Customer = Map(location.Customer).ToList(),
            Orderdetails = Map(location.Orderdetails).ToList(),
        };

        public static Data.Location Map(PizzaWebApp.Models.Location location) => new Data.Location
        {
            Locationid = location.Locationid,
            Street = location.Street,
            State = location.State,
            City = location.City,
            Pizzastore = Map(location.Pizzastore),
            Customer = Map(location.Customer).ToList(),
            Orderdetails = Map(location.Orderdetails).ToList(),
        };

        public static PizzaWebApp.Models.Orderdetails Map(Data.Orderdetails orderdetails) => new PizzaWebApp.Models.Orderdetails
        {
            Orderid = orderdetails.Orderid,
            Customerid = orderdetails.Customerid,
            Storeid = orderdetails.Storeid,
            Locationid = orderdetails.Locationid,
            Totalcost = orderdetails.Totalcost,
            Dateplaced = orderdetails.Dateplaced,
            Customer = CustomMap(orderdetails.Customer),
            Location = Map(orderdetails.Location),
            Store = Map(orderdetails.Store),
            History = Map(orderdetails.History).ToList(),
            Ordereddrinks = Map(orderdetails.Ordereddrinks).ToList(),
            Orderedpizzas = Map(orderdetails.Orderedpizzas).ToList(),
            Orderedsides = Map(orderdetails.Orderedsides).ToList(),
        };

        public static Data.Orderdetails Map(PizzaWebApp.Models.Orderdetails orderdetails) => new Data.Orderdetails
        {
            Orderid = orderdetails.Orderid,
            Customerid = orderdetails.Customerid,
            Storeid = orderdetails.Storeid,
            Locationid = orderdetails.Locationid,        
            Totalcost = orderdetails.Totalcost,
            Dateplaced = orderdetails.Dateplaced,
            Customer = CustomMap(orderdetails.Customer),
            Location = Map(orderdetails.Location),
            Store = Map(orderdetails.Store),
            History = Map(orderdetails.History).ToList(),
            Ordereddrinks = Map(orderdetails.Ordereddrinks).ToList(),
            Orderedpizzas = Map(orderdetails.Orderedpizzas).ToList(),
            Orderedsides = Map(orderdetails.Orderedsides).ToList(),
        };

        public static PizzaWebApp.Models.Ordereddrinks Map(Data.Ordereddrinks ordereddrinks) => new PizzaWebApp.Models.Ordereddrinks
        {
            Ordereddrinksid = ordereddrinks.Ordereddrinksid,
            Orderid = ordereddrinks.Orderid,
            Drinkname = ordereddrinks.Drinkname,
            Drinkqty  = ordereddrinks.Drinkqty,
            Drinkscost = ordereddrinks.Drinkscost,
            DrinknameNavigation = Map(ordereddrinks.DrinknameNavigation),
            Order = Map(ordereddrinks.Order),
        };

        public static Data.Ordereddrinks Map(PizzaWebApp.Models.Ordereddrinks ordereddrinks) => new Data.Ordereddrinks
        {
            Ordereddrinksid = ordereddrinks.Ordereddrinksid,
            Orderid = ordereddrinks.Orderid,
            Drinkname = ordereddrinks.Drinkname,
            Drinkqty = ordereddrinks.Drinkqty,
            Drinkscost = ordereddrinks.Drinkscost,
            DrinknameNavigation = Map(ordereddrinks.DrinknameNavigation),
            Order = Map(ordereddrinks.Order),
        };

        public static PizzaWebApp.Models.Orderedpizzas Map(Data.Orderedpizzas orderedpizzas) => new PizzaWebApp.Models.Orderedpizzas
        {
            Orderedpizzasid = orderedpizzas.Orderedpizzasid,
            Orderid = orderedpizzas.Orderid,
            Pizzaname = orderedpizzas.Pizzaname,
            Pizzaqty = orderedpizzas.Pizzaqty,
            Pizzascost = orderedpizzas.Pizzascost,
            PizzanameNavigation = Map(orderedpizzas.PizzanameNavigation),
            Order = Map(orderedpizzas.Order),
        };

        public static Data.Orderedpizzas Map(PizzaWebApp.Models.Orderedpizzas orderedpizzas) => new Data.Orderedpizzas
        {
            Orderedpizzasid = orderedpizzas.Orderedpizzasid,
            Orderid = orderedpizzas.Orderid,
            Pizzaname = orderedpizzas.Pizzaname,
            Pizzaqty = orderedpizzas.Pizzaqty,
            Pizzascost = orderedpizzas.Pizzascost,
            PizzanameNavigation = Map(orderedpizzas.PizzanameNavigation),
            Order = Map(orderedpizzas.Order),
        };

        public static PizzaWebApp.Models.Orderedsides Map(Data.Orderedsides orderedsides) => new PizzaWebApp.Models.Orderedsides
        {
            Orderedsidesid = orderedsides.Orderedsidesid,
            Orderid = orderedsides.Orderid,
            Sidename = orderedsides.Sidename,
            Sideqty = orderedsides.Sideqty,
            Sidescost = orderedsides.Sidescost,
            SidenameNavigation = Map(orderedsides.SidenameNavigation),
            Order = Map(orderedsides.Order),
        };

        public static Data.Orderedsides Map(PizzaWebApp.Models.Orderedsides orderedsides) => new Data.Orderedsides
        {
            Orderedsidesid = orderedsides.Orderedsidesid,
            Orderid = orderedsides.Orderid,
            Sidename = orderedsides.Sidename,
            Sideqty = orderedsides.Sideqty,
            Sidescost = orderedsides.Sidescost,
            SidenameNavigation = Map(orderedsides.SidenameNavigation),
            Order = Map(orderedsides.Order),
        };

        public static PizzaWebApp.Models.Pizzas Map(Data.Pizzas pizzas) => new PizzaWebApp.Models.Pizzas
        {
            Name = pizzas.Name,
            Cost = pizzas.Cost,
            Inventorypizzas = Map(pizzas.Inventorypizzas).ToList(),
            Orderedpizzas = Map(pizzas.Orderedpizzas).ToList(),
        };

        public static Data.Pizzas Map(PizzaWebApp.Models.Pizzas pizzas) => new Data.Pizzas
        {
            Name = pizzas.Name,
            Cost = pizzas.Cost,
            Inventorypizzas = Map(pizzas.Inventorypizzas).ToList(),
            Orderedpizzas = Map(pizzas.Orderedpizzas).ToList(),
        };

        public static PizzaWebApp.Models.Sides Map(Data.Sides sides) => new PizzaWebApp.Models.Sides
        {
            Name = sides.Name,
            Cost = sides.Cost,
            Inventorysides = Map(sides.Inventorysides).ToList(),
            Orderedsides = Map(sides.Orderedsides).ToList(),
        };

        public static Data.Sides Map(PizzaWebApp.Models.Sides sides) => new Data.Sides
        {
            Name = sides.Name,
            Cost = sides.Cost,
            Inventorysides = Map(sides.Inventorysides).ToList(),
            Orderedsides = Map(sides.Orderedsides).ToList(),
        };

        public static PizzaWebApp.Models.Pizzastore Map(Data.Pizzastore pizzastore) => new PizzaWebApp.Models.Pizzastore
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

        public static Data.Pizzastore Map(PizzaWebApp.Models.Pizzastore pizzastore) => new Data.Pizzastore
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
        public static PizzaWebApp.Models.Pizzastore StoreMap(Data.Pizzastore pizzastore) => new PizzaWebApp.Models.Pizzastore
        {
            Storeid = pizzastore.Storeid,
            Name = pizzastore.Name,
            Locationid = pizzastore.Locationid,
            Location = StorelocalMap(pizzastore.Location),
     
        };
        public static Mods.Location StorelocalMap(Data.Location local) => new Mods.Location
        {
            Locationid = local.Locationid,
            State = local.State,
            Street = local.Street,
            City = local.City,
        };

        public static Data.Pizzastore StoreMap(PizzaWebApp.Models.Pizzastore pizzastore) => new Data.Pizzastore
        {
            Storeid = pizzastore.Storeid,
            Name = pizzastore.Name,
            Locationid = pizzastore.Locationid,
            Location = StorelocalMap(pizzastore.Location),
  
        };
        public static Data.Location StorelocalMap(Mods.Location local) => new Data.Location
        {
            Locationid = local.Locationid,
            State = local.State,
            Street = local.Street,
            City = local.City,
        };
        public static IEnumerable<PizzaWebApp.Models.History> Map(IEnumerable<Data.History> histories) => histories.Select(Map);
        public static IEnumerable<Data.History> Map(IEnumerable<PizzaWebApp.Models.History> histories) => histories.Select(Map);

        public static IEnumerable<PizzaWebApp.Models.Orderdetails> Map(IEnumerable<Data.Orderdetails> orderdetails) => orderdetails.Select(Map);
        public static IEnumerable<Data.Orderdetails> Map(IEnumerable<PizzaWebApp.Models.Orderdetails> orderdetails) => orderdetails.Select(Map);

        public static IEnumerable<PizzaWebApp.Models.History> CustomhistMap(IEnumerable<Data.History> histories) => histories.Select(CustomhistMap);
        public static IEnumerable<Data.History> CustomhistMap(IEnumerable<PizzaWebApp.Models.History> histories) => histories.Select(CustomhistMap);

        public static IEnumerable<PizzaWebApp.Models.Orderdetails> CustomdetsMap(IEnumerable<Data.Orderdetails> orderdetails) => orderdetails.Select(CustomdetsMap);
        public static IEnumerable<Data.Orderdetails> CustomdetsMap(IEnumerable<PizzaWebApp.Models.Orderdetails> orderdetails) => orderdetails.Select(CustomdetsMap);


        public static IEnumerable<PizzaWebApp.Models.Inventorydrinks> Map(IEnumerable<Data.Inventorydrinks> inventorydrinks) => inventorydrinks.Select(Map);
        public static IEnumerable<Data.Inventorydrinks> Map(IEnumerable<PizzaWebApp.Models.Inventorydrinks> inventorydrinks) => inventorydrinks.Select(Map);

        public static IEnumerable<PizzaWebApp.Models.Inventorypizzas> Map(IEnumerable<Data.Inventorypizzas> inventorypizzas) => inventorypizzas.Select(UpdateMap);
        public static IEnumerable<Data.Inventorypizzas> Map(IEnumerable<PizzaWebApp.Models.Inventorypizzas> inventorypizzas) => inventorypizzas.Select(UpdateMap);

        public static IEnumerable<PizzaWebApp.Models.Inventorysides> Map(IEnumerable<Data.Inventorysides> inventorysides) => inventorysides.Select(Map);
        public static IEnumerable<Data.Inventorysides> Map(IEnumerable<PizzaWebApp.Models.Inventorysides> inventorysides) => inventorysides.Select(Map);

        public static IEnumerable<PizzaWebApp.Models.Ordereddrinks> Map(IEnumerable<Data.Ordereddrinks> ordereddrinks) => ordereddrinks.Select(Map);
        public static IEnumerable<Data.Ordereddrinks> Map(IEnumerable<PizzaWebApp.Models.Ordereddrinks> ordereddrinks) => ordereddrinks.Select(Map);

        public static IEnumerable<PizzaWebApp.Models.Orderedpizzas> Map(IEnumerable<Data.Orderedpizzas> orderedpizzas) => orderedpizzas.Select(Map);
        public static IEnumerable<Data.Orderedpizzas> Map(IEnumerable<PizzaWebApp.Models.Orderedpizzas> orderedpizzas) => orderedpizzas.Select(Map);

        public static IEnumerable<PizzaWebApp.Models.Orderedsides> Map(IEnumerable<Data.Orderedsides> orderedsides) => orderedsides.Select(Map);
        public static IEnumerable<Data.Orderedsides> Map(IEnumerable<PizzaWebApp.Models.Orderedsides> orderedsides) => orderedsides.Select(Map);

        public static IEnumerable<PizzaWebApp.Models.Customer> Map(IEnumerable<Data.Customer> customers) => customers.Select(CustomMap);
        public static IEnumerable<Data.Customer> Map(IEnumerable<PizzaWebApp.Models.Customer> customers) => customers.Select(CustomMap);

        public static IEnumerable<PizzaWebApp.Models.Drinks> Map(IEnumerable<Data.Drinks> drinks) => drinks.Select(Map);
        public static IEnumerable<Data.Drinks> Map(IEnumerable<PizzaWebApp.Models.Drinks> drinks) => drinks.Select(Map);

        public static IEnumerable<PizzaWebApp.Models.Pizzas> Map(IEnumerable<Data.Pizzas> pizzas) => pizzas.Select(Map);
        public static IEnumerable<Data.Pizzas> Map(IEnumerable<PizzaWebApp.Models.Pizzas> pizzas) => pizzas.Select(Map);

        public static IEnumerable<PizzaWebApp.Models.Sides> Map(IEnumerable<Data.Sides> sides) => sides.Select(Map);
        public static IEnumerable<Data.Sides> Map(IEnumerable<PizzaWebApp.Models.Sides> sides) => sides.Select(Map);

        public static IEnumerable<PizzaWebApp.Models.Location> Map(IEnumerable<Data.Location> locations) => locations.Select(Map);
        public static IEnumerable<Data.Location> Map(IEnumerable<PizzaWebApp.Models.Location> locations) => locations.Select(Map);

        public static IEnumerable<PizzaWebApp.Models.Pizzastore> Map(IEnumerable<Data.Pizzastore> pizzastores) => pizzastores.Select(StoreMap);
        public static IEnumerable<Data.Pizzastore> Map(IEnumerable<PizzaWebApp.Models.Pizzastore> pizzastores) => pizzastores.Select(StoreMap);
    }
}
