using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Monotoring.Models;
using Monotoring.Context;

namespace Monotoring.Controllers
{
    public class AreaController : Controller
    {
        private TrackContext context = new TrackContext();
        // GET: Area
        public ActionResult Index()
        {
            if (Convert.ToString(Session["userType"]) == "3")
            {
                var area = context.Area.ToList();

                return View(area);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Area/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Area/Create
        [HttpGet]
        public ActionResult Create()
        {
            if (Convert.ToString(Session["userType"]) == "3")
            {
                //ViewBag.Users = new SelectList(context.Users, "UsersId", "username");
                return View(new Area());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: Area/Create
        [HttpPost]
        public ActionResult Create(Area area)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    context.Area.Add(area);
                    context.SaveChanges();
                    return RedirectToAction("Index","Config");
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

        // GET: Area/Edit/5
        public ActionResult Edit(int id=0)
        {
            //ViewBag.Users = new SelectList(context.Users, "UsersId", "username");
            if (Convert.ToString(Session["userType"]) == "3")
            {
                Area a = context.Area.Find(id);
                return View(a);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: Area/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Area area)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    context.Entry(area).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Index","Config");
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

        // GET: Area/Delete/5
        [HttpGet]
        public ActionResult Delete(int id=0)
        {
            if (Convert.ToString(Session["userType"]) == "3")
            {
                var area = context.Area.Find(id);
                //ViewBag.Users = new SelectList(context.Users, "UsersId", "username");
                return View(area);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: Area/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletedConfirmed(int id)
        {   
            var area = context.Area.Find(id);
            context.Area.Remove(area);
            context.SaveChanges();
            return RedirectToAction("Index","Config");
        }
    }
}
