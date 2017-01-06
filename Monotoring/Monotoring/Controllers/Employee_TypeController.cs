using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Monotoring.Models;
using Monotoring.Context;

namespace Monotoring.Controllers
{
    public class Employee_TypeController : Controller
    {
        private TrackContext context = new TrackContext();
        // GET: Employee_Type
        public ActionResult Index()
        {
            var type = context.Employee_type.ToList();
            return View(type);
        }

        // GET: Employee_Type/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee_Type/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Employee_type());
        }

        // POST: Employee_Type/Create
        [HttpPost]
        public ActionResult Create(Employee_type emp)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    context.Employee_type.Add(emp);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(emp);
                }
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee_Type/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee_Type/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee_Type/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee_Type/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
