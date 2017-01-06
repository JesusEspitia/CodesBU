using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Monotoring.Models;
using Monotoring.Context;

namespace Monotoring.Controllers
{
    public class CatalogController : Controller
    {
        private TrackContext context = new TrackContext();
        // GET: Catalog
        public ActionResult Index()
        {
            var cat = context.Catalog.ToList();
            return View(cat);
        }

        // GET: Catalog/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Catalog/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Catalog());
        }

        // POST: Catalog/Create
        [HttpPost]
        public ActionResult Create(Catalog catalog)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    context.Catalog.Add(catalog);
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

        // GET: Catalog/Edit/5
        [HttpGet]
        public ActionResult Edit(int id=0)
        {
            Catalog c = context.Catalog.Find(id);
            return View(c);
        }

        // POST: Catalog/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Catalog catalog)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    context.Entry(catalog).State = System.Data.Entity.EntityState.Modified;
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

        // GET: Catalog/Delete/5
        public ActionResult Delete(int id=0)
        {
            var cat = context.Catalog.Find(id);
            return View(cat);
        }

        // POST: Catalog/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletedConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                var cat = context.Catalog.Find(id);
                context.Catalog.Remove(cat);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
