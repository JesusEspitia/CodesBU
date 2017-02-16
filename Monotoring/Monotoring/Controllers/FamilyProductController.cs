using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Monotoring.Context;
using Monotoring.Models;

namespace Monotoring.Controllers
{
    public class FamilyProductController : Controller
    {
        private TrackContext context = new TrackContext();
        // GET: FamilyProduct
        public ActionResult Index()
        {
            if (Convert.ToString(Session["userType"]) == "3")
            {
                var model = context.FamilyProduct.ToList();
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: FamilyProduct/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FamilyProduct/Create
        public ActionResult Create()
        {
            if (Convert.ToString(Session["userType"]) == "3")
            {
                return View(new FamilyProduct());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: FamilyProduct/Create
        [HttpPost]
        public ActionResult Create(FamilyProduct model)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    context.FamilyProduct.Add(model);
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

        // GET: FamilyProduct/Edit/5
        public ActionResult Edit(int id)
        {
            if (Convert.ToString(Session["userType"]) == "3")
            {
                var model = context.FamilyProduct.Find(id);
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: FamilyProduct/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FamilyProduct model)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    context.Entry(model).State = System.Data.Entity.EntityState.Modified;
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

        // GET: FamilyProduct/Delete/5
        public ActionResult Delete(int id)
        {
            if (Convert.ToString(Session["userType"]) == "3")
            {
                var model = context.FamilyProduct.Find(id);
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: FamilyProduct/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletedConfirmed(int id)
        {
            try
            {
                // TODO: Add delete logic here
                if (ModelState.IsValid)
                {
                    var model = context.FamilyProduct.Find(id);
                    context.FamilyProduct.Remove(model);
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
