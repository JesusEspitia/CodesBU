using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Monotoring.Models;
using Monotoring.Context;

namespace Monotoring.Controllers
{
    public class AreaPlusController : Controller
    {
        private TrackContext context = new TrackContext();
        // GET: AreaPlus
        public ActionResult Index()
        {
            return View();
        }

        // GET: AreaPlus/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AreaPlus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AreaPlus/Create
        [HttpPost]
        public ActionResult Create(AreaPlus model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.AreaPlus.Add(model);
                    context.SaveChanges();
                    return RedirectToAction("Index","Users");
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

        // GET: AreaPlus/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AreaPlus/Edit/5
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

        // GET: AreaPlus/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AreaPlus/Delete/5
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
