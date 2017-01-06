﻿    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Monotoring.Models;
using Monotoring.Context;

namespace Monotoring.Controllers
{
    public class WorkOrdenController : Controller
    {
        private TrackContext context = new TrackContext();
        // GET: WorkOrden
        public ActionResult Index()
        {
            var orden = context.WorkOrden.ToList();
            return View(orden);
        }

        // GET: WorkOrden/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WorkOrden/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Catalog = new SelectList(context.Catalog, "CatalogId", "CatalogNo");
            return View(new WorkOrden());
        }

        // POST: WorkOrden/Create
        [HttpPost]
        public ActionResult Create(WorkOrden orden)
        {
            try
            {
                ViewBag.Catalog = new SelectList(context.Catalog, "CatalogId", "CatalogNo");
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    context.WorkOrden.Add(orden);
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

        // GET: WorkOrden/Edit/5
        [HttpGet]
        public ActionResult Edit(int id=0)
        {
            ViewBag.Catalog = new SelectList(context.Catalog, "CatalogId", "CatalogNo");
            WorkOrden orden = context.WorkOrden.Find(id);
            return View(orden);
        }

        // POST: WorkOrden/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, WorkOrden orden)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    context.Entry(orden).State = System.Data.Entity.EntityState.Modified;
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

        // GET: WorkOrden/Delete/5

        public ActionResult Delete(int id=0)
        {
            var orden = context.WorkOrden.Find(id);
            ViewBag.Catalog = new SelectList(context.Catalog, "CatalogId", "CatalogNo");
            return View(orden);
        }

        // POST: WorkOrden/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletedComfirmed(int id)
        {
            try
            {
                // TODO: Add delete logic here
                if (ModelState.IsValid)
                {
                    var orden = context.WorkOrden.Find(id);
                    context.WorkOrden.Remove(orden);
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
