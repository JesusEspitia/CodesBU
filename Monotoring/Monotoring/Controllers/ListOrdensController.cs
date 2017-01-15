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
            if (Session["userName"].ToString() != "" || Session["userName"].ToString() != null)
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
                    int getArea = getBeforeArea(userId);
                    var model = from a in context.Area_Orden
                                join w in context.WorkOrden on a.WorkOrdenId equals w.WorkOrdenId
                                where a.AreaId == getArea && a.runOrden == true && a.dateFinish != null
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

        //[HttpGet]
        //public ActionResult StartOrden(int id = 0)
        //{
        //    var orden = context.WorkOrden.Find(id);
        //    return View(orden);
        //}

        [HttpGet]
        public ActionResult StartOrden(int id)
        {
            int orden = id;
            int area = 0;
            //var getOrden = from w in context.WorkOrden
            //            where w.BatchOrden == id.ToString()
            //            select w;
            //var lstOrden = getOrden.ToList();
            //foreach(var d in lstOrden)
            //{
            //    orden = d.WorkOrdenId;
            //}
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
                         where w.WorkOrdenId == id
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
                dateStart = DateTime.Now,
                runOrden = true
            };
            if(area != 1)
            {
                var slut = from a in context.Area_Orden
                           where a.WorkOrdenId == id && a.AreaId == (area-1)
                           select a;
                var slutlst = slut.ToList();
                foreach(Area_Orden a in slut)
                {
                    a.runOrden = false;
                }
            }
            context.Area_Orden.Add(ord);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public int getBeforeArea(int id)
        {
            var query = from a in context.Area
                        where a.UsersId == id
                        select a;
            int areaid = 0;
            int ret = 0;
            var lst = query.ToList();
            foreach (var d in lst)
            {
                areaid = d.AreaId;
            }
            switch (areaid)
            {
                case 2:
                    ret = 1;
                    break;
                case 3:
                    ret = 2;
                    break;
                case 4:
                    ret = 3;
                    break;
                case 5:
                    ret = 4;
                    break;
                case 6:
                    ret = 5;
                    break;
            }
            return ret;
        }
    }

    
}