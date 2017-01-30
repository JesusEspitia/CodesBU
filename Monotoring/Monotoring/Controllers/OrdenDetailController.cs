using System;
using System.Collections.Generic;
using System.Linq;
using System.Dynamic;
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
            int catalog = 0;
            dynamic model = new ExpandoObject();
            //var query = from w in context.WorkOrden
            //            join a in context.Area_Orden on w.WorkOrdenId equals a.WorkOrdenId
            //            join ar in context.Area on a.AreaId equals ar.AreaId
            //            join d in context.DelayWork on w.WorkOrdenId equals d.WorkOrdenId
            //            join c in context.DelayCode on d.DelayCodeId equals c.DelayCodeId
            //            join ct in context.Catalog on w.CatalogId equals ct.CatalogId
            //            where w.WorkOrdenId == id
            //            select new OrdenDetail { WorkOrden = w, Area_Orden = a, Area = ar, DelayWork = d, DelayCode = c,Catalog=ct };
            //model.OrdenDetail = query.ToList();
            var queryOrden = from w in context.WorkOrden
                             join c in context.Catalog on w.CatalogId equals c.CatalogId
                             where w.WorkOrdenId == id
                             select new WorkCatalog { WorkOrden = w, Catalog = c };
            model.WorkCatalog = queryOrden.ToList();
            var queryArea = from a in context.Area_Orden
                            join ar in context.Area on a.AreaId equals ar.AreaId
                            where a.WorkOrdenId==id
                            select new AreaViewModel { Area = ar, Area_Orden = a };
            model.Area = queryArea.ToList();
            var queryDelay = from d in context.DelayWork
                             join c in context.DelayCode on d.DelayCodeId equals c.DelayCodeId
                             where d.WorkOrdenId==id
                             select new DelayArea { DelayWork = d, DelayCode = c };
            model.Delay = queryDelay.ToList();
            //var queryArea=
            return View(model);
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
