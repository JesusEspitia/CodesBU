using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Monotoring.Models;
using Monotoring.Context;

namespace Monotoring.Controllers
{
    public class DelayWorkController : Controller
    {
        private TrackContext context = new TrackContext();
        // GET: DelayWork
        public ActionResult Index()
        {
            var delay = context.DelayWork.ToList();
            return View(delay);
        }

        // GET: DelayWork/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DelayWork/Create
        [HttpGet]
        public ActionResult Create(int id)
        {
            DelayWork model = new DelayWork();
            model.WorkOrdenId = id;
            model.UsersId = (int)Session["userId"];
            ViewBag.DelayCode = new SelectList(context.DelayCode, "DelayCodeId", "DelayName");
            ViewBag.WorkOrden = new SelectList(context.WorkOrden, "WorkOrdenId", "BatchOrden");
            //ViewBag.WorkOrden = id;
            ViewBag.Users = new SelectList(context.Users, "UsersId", "username");
            return View(model);
        }

        // POST: DelayWork/Create
        [HttpPost]
        public ActionResult Create(DelayWork delay)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    context.DelayWork.Add(delay);
                    context.SaveChanges();
                    return RedirectToAction("Index", "Area_Orden");
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

        // GET: DelayWork/Edit/5
        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            ViewBag.DelayCode = new SelectList(context.DelayCode, "DelayCodeId", "DelayName");
            ViewBag.WorkOrden = new SelectList(context.WorkOrden, "WorkOrdenId", "BatchOrden");
            ViewBag.Users = new SelectList(context.Users, "UsersId", "username");
            var delay = context.DelayWork.Find(id);
            return View(delay);
        }

        // POST: DelayWork/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DelayWork delay)
        {
            try
            {
                ViewBag.DelayCode = new SelectList(context.DelayCode, "DelayCodeId", "DelayName");
                ViewBag.WorkOrden = new SelectList(context.WorkOrden, "WorkOrdenId", "BatchOrden");
                ViewBag.Users = new SelectList(context.Users, "UsersId", "username");
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    context.Entry(delay).State = System.Data.Entity.EntityState.Modified;
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

        // GET: DelayWork/Delete/5
        [HttpGet]
        public ActionResult Delete(int id = 0)
        {
            var delay = context.DelayWork.Find(id);
            return View(delay);
        }

        // POST: DelayWork/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletedConfirmed(int id)
        {
            try
            {
                // TODO: Add delete logic here
                if (ModelState.IsValid)
                {
                    var delay = context.DelayWork.Find(id);
                    context.DelayWork.Remove(delay);
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

        [HttpGet]
        public ActionResult finishDelay(int id)
        {
            var query = from d in context.DelayWork
                        where d.DelayWorkId == id
                        select d;
            foreach (DelayWork d in query)
            {
                d.dateFinish = DateTime.Now;
            }
            context.SaveChanges();
            return RedirectToAction("Index", "Area_Orden");
        }
    }
}
