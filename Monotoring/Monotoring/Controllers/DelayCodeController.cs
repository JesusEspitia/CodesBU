using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Monotoring.Models;
using Monotoring.Context;

namespace Monotoring.Controllers
{
    public class DelayCodeController : Controller
    {
        private TrackContext context = new TrackContext();
        // GET: DelayCode
        public ActionResult Index()
        {
            if (Convert.ToString(Session["userType"]) == "1")
            {
                var code = context.DelayCode.ToList();
                return View(code);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: DelayCode/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DelayCode/Create
        [HttpGet]
        public ActionResult Create()
        {
            if (Convert.ToString(Session["userType"]) == "1")
            {
                return View(new DelayCode());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: DelayCode/Create
        [HttpPost]
        public ActionResult Create(DelayCode code)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    context.DelayCode.Add(code);
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

        // GET: DelayCode/Edit/5
        [HttpGet]
        public ActionResult Edit(int id=0)
        {
            if (Convert.ToString(Session["userType"]) == "1")
            {
                var code = context.DelayCode.Find(id);
                return View(code);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: DelayCode/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DelayCode code)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    context.Entry(code).State = System.Data.Entity.EntityState.Modified;
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

        // GET: DelayCode/Delete/5
        [HttpGet]
        public ActionResult Delete(int id=0)
        {
            if (Convert.ToString(Session["userType"]) == "1")
            {
                var code = context.DelayCode.Find(id);
                return View(code);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: DelayCode/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletedConfirmed(int id)
        {
            try
            {
                // TODO: Add delete logic here
                if (ModelState.IsValid)
                {
                    var code = context.DelayCode.Find(id);
                    context.DelayCode.Remove(code);
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
