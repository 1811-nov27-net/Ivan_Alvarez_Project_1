using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaWebApp.Repositories;
using PizzaWebApp.Models;

namespace PizzaWebApp.Controllers
{
    public class CustomerController : Controller
    {
        public IPizzaRepo Repo { get; set; }
        public CustomerController(IPizzaRepo repo)
        {
            Repo = repo;
        }
        // GET: Customer
        // public ActionResult 
        static int idy = 0;
        static int storeidy = 0;
        static int localidy = 0;

        [Route("Index")]
        public ActionResult Index()
        {
            return View(Repo.Getcustomers());
        }

        // GET: Customer/Details/5
        [Route("Details")]
        [Route("Details/{id}")]
        public ActionResult Details(int id)
        {

            return View(Repo.Getorderdetsbyid(id));
        }

        // GET: Customer/Create
        [Route("Order")]
        public ActionResult Create(int id, int storeid, int localid)
        {
            idy = id;
            storeidy = storeid;
            localidy = localid;
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create1(int id, int storeid, int localid, Orderedpizzas ordpizz)
        {

            storeid = storeidy;  
            id = idy;
            localid = localidy;
            try
            {
                DateTime newtime = DateTime.Now;

                PizzaWebApp.Models.Orderdetails neworder = new PizzaWebApp.Models.Orderdetails()
                {
                    Customerid = id,
                    Storeid = storeid,
                    Locationid = localid,
                    Dateplaced = newtime,
                    Totalcost = ordpizz.Pizzascost,
                };
                Repo.Createorder(neworder);
                PizzaWebApp.Models.Orderdetails order = Repo.Getorderbytime(newtime);
                ordpizz.Orderid = order.Orderid;
                Repo.Createpizzaorder(ordpizz);
    
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id, int local)
        {
            var newlocal = Repo.Getlocationbyid(local);
            return View();
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}