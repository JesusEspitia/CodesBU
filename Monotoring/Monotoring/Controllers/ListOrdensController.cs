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
            try
            {
                int areaId = 0;
                int userId = 0;
                if (Session["userName"].ToString() != "")
                {
                    userId = (int)Session["userId"];
                    areaId = (int)Session["userAreaId"];
                    if (areaId == 1)
                    {
                        //var model = from w in context.WorkOrden
                        //            where w.dateStart == null
                        //            select w;
                        var model = context.WorkOrden.Include("Catalog").Where(m => m.dateStart == null);
                        ViewBag.myModel = model.ToList();
                        List<int> lst = new List<int>();
                        ViewBag.myModel2 = lst.ToList();
                        return View();
                    }
                    else
                    {
                        int getArea = getBeforeArea(userId);
                        var model = from a in context.Area_Orden
                                    join w in context.WorkOrden on a.WorkOrdenId equals w.WorkOrdenId
                                    join c in context.Catalog on w.CatalogId equals c.CatalogId
                                    where a.AreaId == getArea && a.runOrden == true && a.dateFinish != null
                                    select new WorkCatalog { WorkOrden = w, Catalog = c };
                        List<int> lst = new List<int>();
                        ViewBag.myModel = lst.ToList();
                        ViewBag.myModel2 = model.ToList();
                        return View();
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }           
        }

        [HttpGet]
        public ActionResult CountNews()
        {
            int areaId = 0;
            int userId = 0;
            if (Session["userName"].ToString() != "" || Session["userName"].ToString() != null)
            {
                userId = (int)Session["userId"];
                areaId = (int)Session["userAreaId"];
                if (areaId == 1)
                {
                    var model = from w in context.WorkOrden
                                where w.dateStart == null
                                select w;
                    var lst = model.ToList();
                    return Content(lst.Count.ToString());
                }
                else
                {
                    int getArea = getBeforeArea(userId);
                    var model = from a in context.Area_Orden
                                join w in context.WorkOrden on a.WorkOrdenId equals w.WorkOrdenId
                                where a.AreaId == getArea && a.runOrden == true && a.dateFinish != null
                                select w;
                    var lst = model.ToList();
                    return View(lst.Count.ToString());
                }
            }
            else
            {
                return Content("0");
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
            area = (int)Session["userAreaId"];


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
            var ar=from u in context.Users
                  where u.UsersId==user
                  select u;
            
            foreach(var item in ar.ToList())
            {
                area = (int)item.AreaId;
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
            
            int areaid = (int)Session["userAreaId"];
            int ret = 0;
            
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