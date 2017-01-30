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
            var id = (int)Session["userId"];
            var lst = from a in context.Area_Orden
                      join u in context.Users on a.AreaId equals u.AreaId
                      join w in context.WorkOrden on a.WorkOrdenId equals w.WorkOrdenId
                      where u.UsersId == id && a.dateFinish==null
                      select w;
            ViewBag.ordens = lst.ToList();
            return View();
        }

        [HttpGet]
        public ActionResult FinishOrden(int id)
        {
            var delay = from d in context.DelayWork
                        where d.WorkOrdenId == id && d.dateFinish == null
                        select d;
            var lstdelay = delay.ToList();
            if (lstdelay.Count < 1)
            {
                Session["stop"] = null;
                int area = (int)Session["userAreaId"];
                var up = from w in context.Area_Orden
                         where w.WorkOrdenId == id && w.AreaId == area
                         select w;
                foreach (Area_Orden a in up)
                {
                    a.dateFinish = DateTime.Now;
                    //finish = a.AreaId;
                }
                if (area == 6)
                {
                    var upOrden = from w in context.WorkOrden
                                  where w.WorkOrdenId == id
                                  select w;

                    foreach (WorkOrden w in upOrden)
                    {
                        w.dateFinish = DateTime.Now;
                    }
                }
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Stop = "No puede finalizar la orden ya que cuenta con un retraso abierto, debe ser cerrado antes.";
                Session["stop"] = "No puede finalizar la orden ya que cuenta con un retraso abierto, debe ser cerrado antes.";
                return RedirectToAction("Index");
                //return Content("<script language='javascript' type='text/javascript'>alert('No puede finalizar la orden ya que cuenta con un retraso abierto, debe ser cerrado antes.');</script>");
            }
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
