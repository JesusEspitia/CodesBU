﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Monotoring.Context;
using Monotoring.Models;

namespace Monotoring.Controllers
{
    public class OrdenCommentController : Controller
    {
        private TrackContext context = new TrackContext();

        // GET: OrdenComment
        public ActionResult Index()
        {
            return View();
        }

        // GET: OrdenComment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrdenComment/Create
        public ActionResult Create(int id)
        {
            var model = new OrdenComment();
            model.UsersId= (int)Session["userId"];
            model.WorkOrdenId = id;
            return PartialView("Create", model);
        }

        // POST: OrdenComment/Create
        [HttpPost]
        public ActionResult Create(OrdenComment model)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    context.OrdenComment.Add(model);
                    context.SaveChanges();
                    return RedirectToAction("Index", "Area_Orden");
                }
                else
                {
                    return PartialView("Index", "Area_Orden");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdenComment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrdenComment/Edit/5
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

        // GET: OrdenComment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrdenComment/Delete/5
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
