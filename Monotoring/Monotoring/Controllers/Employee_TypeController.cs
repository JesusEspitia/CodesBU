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
            if (Convert.ToString(Session["userType"]) == "1")
            {
                var type = context.Employee_type.ToList();
                return View(type);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
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
            if (Convert.ToString(Session["userType"]) == "1")
            {
                return View(new Employee_type());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
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
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Convert.ToString(Session["userType"]) == "1")
            {
                var model = context.Employee_type.Find(id);
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: Employee_Type/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee_type emp)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    context.Entry(emp).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee_Type/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (Convert.ToString(Session["userType"]) == "1")
            {
                var model = context.Employee_type.Find(id);
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: Employee_Type/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                // TODO: Add delete logic here
                if (ModelState.IsValid)
                {
                    var model = context.Employee_type.Find(id);
                    context.Employee_type.Remove(model);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
                
            }
            catch
            {
                return View();
            }
        }
    }
}
