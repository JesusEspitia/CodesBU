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
            if (Convert.ToString(Session["userType"]) == "3")
            {
                var cat = context.Catalog.Include("FamilyProduct").ToList();
                //ViewBag.Family = new SelectList(context.FamilyProduct, "FamilyProductId", "nameFamily");
                return View(cat);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
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
            if (Convert.ToString(Session["userType"]) == "3")
            {
                ViewBag.Family = new SelectList(context.FamilyProduct, "FamilyProductId", "nameFamily");
                return View(new Catalog());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: Catalog/Create
        [HttpPost]
        public ActionResult Create(Catalog catalog, HttpPostedFileBase image)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    ViewBag.Family = new SelectList(context.FamilyProduct, "FamilyProductId", "nameFamily");
                    string img = "";
                    if (image != null)
                    {

                        //catalog.image = new byte[image.ContentLength];
                        //image.InputStream.Read(catalog.image, 0, image.ContentLength);
                        img = System.IO.Path.GetFileName(image.FileName);
                        string physicalPath = Server.MapPath("~/fonts/images/" + img);

                        image.SaveAs(physicalPath);
                        catalog.image = img;

                    }
                    context.Catalog.Add(catalog);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Family = new SelectList(context.FamilyProduct, "FamilyProductId", "nameFamily");
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
            if (Convert.ToString(Session["userType"]) == "3")
            {
                ViewBag.Family = new SelectList(context.FamilyProduct, "FamilyProductId", "nameFamily");
                Catalog c = context.Catalog.Find(id);
                return View(c);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: Catalog/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Catalog catalog,HttpPostedFileBase image)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    ViewBag.Family = new SelectList(context.FamilyProduct, "FamilyProductId", "nameFamily");
                    string img = "";
                    if (image != null)
                    {

                        //catalog.image = new byte[image.ContentLength];
                        //image.InputStream.Read(catalog.image, 0, image.ContentLength);
                        img = System.IO.Path.GetFileName(image.FileName);
                        string physicalPath = Server.MapPath("~/fonts/images/" + img);

                        image.SaveAs(physicalPath);
                        catalog.image = img;

                    }
                    context.Entry(catalog).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Family = new SelectList(context.FamilyProduct, "FamilyProductId", "nameFamily");
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
            if (Convert.ToString(Session["userType"]) == "3")
            {

                var cat = context.Catalog.Find(id);
                return View(cat);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
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
