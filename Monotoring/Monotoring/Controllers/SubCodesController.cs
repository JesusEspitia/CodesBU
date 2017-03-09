using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Monotoring.Context;
using Monotoring.Models;

namespace Monotoring.Controllers
{
    public class SubCodesController : Controller
    {
        private TrackContext context = new TrackContext();
        // GET: SubCodes
        public ActionResult Index()
        {
            return View();
        }

        // GET: SubCodes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SubCodes/Create
        public ActionResult Create()
        {
            ViewBag.Code = new SelectList(context.DelayCode, "DelayCodeId", "DelayName");
            return View(new SubCodes());
        }

        // POST: SubCodes/Create
        [HttpPost]
        public ActionResult Create(SubCodes model)
        {
            try
            {
                if (Convert.ToString(Session["userType"]) == "3")
                {

                    ViewBag.Code = new SelectList(context.DelayCode, "DelayCodeId", "DelayName");
                    // TODO: Add insert logic here
                    if (ModelState.IsValid)
                    {
                        context.SubCodes.Add(model);
                        context.SaveChanges();
                        return RedirectToAction("Index", "Config");
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: SubCodes/Edit/5
        public ActionResult Edit(int id)
        {
            if (Convert.ToString(Session["userType"]) == "3")
            {
                ViewBag.Code = new SelectList(context.DelayCode, "DelayCodeId", "DelayName");
                var model = context.SubCodes.Find(id);
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: SubCodes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SubCodes model)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    context.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Index", "Config");
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

        // GET: SubCodes/Delete/5
        public ActionResult Delete(int id)
        {
            if (Convert.ToString(Session["userType"]) == "3")
            {
                ViewBag.Code = new SelectList(context.DelayCode, "DelayCodeId", "DelayName");
                var model = context.SubCodes.Find(id);
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: SubCodes/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                // TODO: Add delete logic here
                if (ModelState.IsValid)
                {
                    var model = context.SubCodes.Find(id);
                    context.SubCodes.Remove(model);
                    context.SaveChanges();
                    return RedirectToAction("Index", "Config");
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
