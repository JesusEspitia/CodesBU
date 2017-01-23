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
            var area = context.Area.ToList();
            
            return View(area);
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
            //ViewBag.Users = new SelectList(context.Users, "UsersId", "username");
            return View(new Area());
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
                    return Redirect("Index");
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
            Area a = context.Area.Find(id);
            return View(a);
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

        // GET: Area/Delete/5
        [HttpGet]
        public ActionResult Delete(int id=0)
        {
            var area = context.Area.Find(id);
            //ViewBag.Users = new SelectList(context.Users, "UsersId", "username");
            return View(area);
        }

        // POST: Area/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletedConfirmed(int id)
        {   
            var area = context.Area.Find(id);
            context.Area.Remove(area);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
