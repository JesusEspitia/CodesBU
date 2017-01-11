using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Monotoring.Context;
using Monotoring.Models;

namespace Monotoring.Controllers
{
    public class ListOrdensController : Controller
    {
        private TrackContext context = new TrackContext();
        // GET: ListOrdens
        public ActionResult Index()
        {
            int areaId = 0;
            int userId = 0;
            if (Session["userName"].ToString() != "")
            {
                userId = (int)Session["userId"];
                var getID = from u in context.Area
                            where u.UsersId ==  userId
                            select u;
                var result = getID.ToList();
                foreach(var d in result)
                {
                    areaId = d.AreaId;
                }
                if (areaId == 1)
                {
                    var model = from w in context.WorkOrden
                                where w.dateStart == null
                                select w;
                    ViewBag.myModel = model.ToList();
                    return View();
                }
                else
                {
                    var model = from a in context.Area_Orden
                                join ar in context.Area on a.AreaId equals ar.AreaId
                                join u in context.Users on ar.UsersId equals u.UsersId
                                join w in context.WorkOrden on a.WorkOrdenId equals w.WorkOrdenId
                                where u.UsersId == userId
                                select w;
                    ViewBag.myModel = model.ToList();
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            
        }

        [HttpPost]
        public ActionResult StartOrden(int id)
        {
            int orden = 0;
            int area = 0;
            var getOrden = from w in context.WorkOrden
                        where w.BatchOrden == id.ToString()
                        select w;
            var lstOrden = getOrden.ToList();
            foreach(var d in lstOrden)
            {
                orden = d.WorkOrdenId;
            }
            int user = Convert.ToInt32(Session["userId"]);
            var getArea = from a in context.Area
                          where a.UsersId == user
                          select a;
            var lstArea = getArea.ToList();
            foreach(var d in lstArea)
            {
                area = d.AreaId;
            }

            if (area == 1)
            {
                var up = from w in context.WorkOrden
                         where w.BatchOrden == id.ToString()
                         select w;
                foreach(WorkOrden wo in up)
                {
                    wo.dateStart = DateTime.Now;
                }
            }

            Area_Orden ord = new Area_Orden()
            {
                AreaId = area,
                WorkOrdenId = orden,
                dateStart = DateTime.Now
            };
            context.Area_Orden.Add(ord);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}