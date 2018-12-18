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
    public class PizzastoreController : Controller
    {
        public IPizzaRepo Repo { get; set; }
        public PizzastoreController(IPizzaRepo repo)
        {
            Repo = repo;
        }

        // GET: Pizzastore
        [Route("login/")] 
        public ActionResult Index()
        {
            return View(Repo.Getstores());
        }

        // GET: Pizzastore/Details/5
        public ActionResult Details(int id)
        {
            return View(Repo.Getordersbystore(id));
        }

        // GET: Pizzastore/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pizzastore/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizzastore/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Repo.Getordersbystore(id));
        }

        // POST: Pizzastore/Edit/5
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

        // GET: Pizzastore/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Repo.Getinventbystore(id));
        }

        // POST: Pizzastore/Delete/5
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