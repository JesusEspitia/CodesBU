﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Monotoring.Models;
using Monotoring.Context;

namespace Monotoring.Controllers
{
    public class Area_OrdenController : Controller
    {
        private TrackContext context = new TrackContext();
        // GET: Area_Orden
        public ActionResult Index()
        {
            return View();
        }

        // GET: Area_Orden/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Area_Orden/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Area_Orden/Create
        [HttpPost]
        public ActionResult Create(Area_Orden item)
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

        // GET: Area_Orden/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Area_Orden/Edit/5
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

        // GET: Area_Orden/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Area_Orden/Delete/5
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
