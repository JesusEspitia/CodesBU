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
                        List<int> lst = new List<int>();
                        List<WorkCatalog> modelLst = new List<WorkCatalog>();
                        var model = context.WorkOrden.Include("Catalog").Where(m => m.dateStart == null);
                        var ids = context.AreaPlus.Include("Area").Where(a => a.userId == userId).ToList();
                        foreach(var item in ids.ToList())
                        {
                            lst.Add(getBeforeArea(item.Area.orden));
                        }
                        foreach(int i in lst)
                        {
                            var modelalt = from a in context.Area_Orden
                                           join ar in context.Area on a.AreaId equals ar.AreaId
                                           join w in context.WorkOrden on a.WorkOrdenId equals w.WorkOrdenId
                                           join c in context.Catalog on w.CatalogId equals c.CatalogId
                                           where ar.orden == i && a.runOrden == true && a.dateFinish != null
                                           select new WorkCatalog { WorkOrden = w, Catalog = c, Area = ar };
                            foreach(WorkCatalog w in modelalt.ToList())
                            {
                                modelLst.Add(w);
                            }
                            
                        }
                        List<int> t = new List<int>();
                        ViewBag.myModel = model.ToList();
                        ViewBag.IDArea = areaId;
                        ViewBag.myModel2 = modelLst.ToList();
                        ViewBag.myModel3 = t.ToList();
                        ViewBag.myModel4 = t.ToList();
                        return View();
                    }
                    else
                    {
                        List<int> lst = new List<int>();
                        List<WorkCatalog> modelLst = new List<WorkCatalog>();
                        int getArea = getBeforeArea(areaId);
                        var model = from a in context.Area_Orden
                                    join ar in context.Area on a.AreaId equals ar.AreaId
                                    join w in context.WorkOrden on a.WorkOrdenId equals w.WorkOrdenId
                                    join c in context.Catalog on w.CatalogId equals c.CatalogId
                                    where ar.orden == getArea && a.runOrden == true && a.dateFinish != null
                                    select new WorkCatalog { WorkOrden = w, Catalog = c };

                        var ids = context.AreaPlus.Include("Area").Where(a => a.userId == userId).ToList();
                        foreach (var item in ids.ToList())
                        {
                            lst.Add(getBeforeArea(item.Area.orden));
                        }
                        foreach (int i in lst)
                        {
                            var modelalt = from a in context.Area_Orden
                                           join ar in context.Area on a.AreaId equals ar.AreaId
                                           join w in context.WorkOrden on a.WorkOrdenId equals w.WorkOrdenId
                                           join c in context.Catalog on w.CatalogId equals c.CatalogId
                                           where ar.orden == i && a.runOrden == true && a.dateFinish != null
                                           select new WorkCatalog { WorkOrden = w, Catalog = c, Area = ar };
                            foreach (WorkCatalog w in modelalt.ToList())
                            {
                                modelLst.Add(w);
                            }

                        }
                        List<int> t = new List<int>();
                        ViewBag.IDArea = areaId;
                        ViewBag.myModel = t.ToList();
                        ViewBag.myModel3 = model.ToList();
                        ViewBag.myModel4 = modelLst.ToList();
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
                                join ar in context.Area on a.AreaId equals ar.AreaId
                                join w in context.WorkOrden on a.WorkOrdenId equals w.WorkOrdenId
                                where ar.orden == getArea && a.runOrden == true && a.dateFinish != null
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
        public ActionResult StartOrden(int id, int fromarea)
        {
            int orden = id;
            int area = fromarea;
            //var getOrden = from w in context.WorkOrden
            //            where w.BatchOrden == id.ToString()
            //            select w;
            //var lstOrden = getOrden.ToList();
            //foreach(var d in lstOrden)
            //{
            //    orden = d.WorkOrdenId;
            //}
            int user = Convert.ToInt32(Session["userId"]);
            //area = (int)Session["userAreaId"];


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
            var ar = from a in context.Area
                     where a.orden == area
                     select a;

            foreach (var item in ar.ToList())
            {
                area = (int)item.AreaId;
            }
            Area_Orden ord = new Area_Orden()
            {
                AreaId = area,
                WorkOrdenId = orden,
                dateStart = DateTime.Now,
                runOrden = true,
                notify = false
            };
            area = fromarea;
            if (area != 1)
            {
                var slut = from a in context.Area_Orden
                           join b in context.Area on a.AreaId equals b.AreaId
                           where a.WorkOrdenId == id && b.orden == (area-1)
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
            
            int areaid = id;
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