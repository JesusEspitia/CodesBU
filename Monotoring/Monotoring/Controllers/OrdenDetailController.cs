using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Monotoring.Models;
using Monotoring.Context;

namespace Monotoring.Models
{
    public class OrdenDetailController : Controller
    {
        private TrackContext context = new TrackContext();
        // GET: OrdenDetail
        [HttpGet]
        public ActionResult Index(int id)
        {
            var query = from w in context.WorkOrden
                        join a in context.Area_Orden on w.WorkOrdenId equals a.WorkOrdenId
                        join ar in context.Area on a.AreaId equals ar.AreaId
                        join d in context.DelayWork on w.WorkOrdenId equals d.WorkOrdenId
                        join c in context.DelayCode on d.DelayCodeId equals c.DelayCodeId
                        where w.WorkOrdenId == id
                        select new OrdenDetail { WorkOrden = w, Area_Orden = a, Area = ar, DelayWork = d, DelayCode = c };

            return View(query);
        }

        // GET: OrdenDetail/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrdenDetail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrdenDetail/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdenDetail/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrdenDetail/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdenDetail/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrdenDetail/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
