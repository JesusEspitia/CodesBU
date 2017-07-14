using System;
using System.Collections.Generic;
using System.Linq;
using System.Dynamic;
using System.Web;
using System.Web.Mvc;
using Monotoring.Context;
using Monotoring.Models;

namespace Monotoring.Controllers
{
    public class HomeController : Controller
    {
        private TrackContext context = new TrackContext();
        public ActionResult Index()
        {
            dynamic models = new ExpandoObject();
            //List<object> models = new List<object>();
            var query = (from w in context.WorkOrden
                        join c in context.Catalog on w.CatalogId equals c.CatalogId
                        where w.dateStart != null && w.dateFinish == null
                        select new WorkCatalog { WorkOrden = w, Catalog = c }).OrderByDescending(x=>x.WorkOrden.dateStart);
            models.WorkOrden = query.ToList();
            var qArea = from a in context.Area_Orden
                        join ar in context.Area on a.AreaId equals ar.AreaId
                        select new AreaViewModel { Area = ar, Area_Orden = a };
            models.Area_Orden = qArea.ToList();
            //make graphic
            for (int i = 0; i < 12; i++)
            {
                setDatas(new DateTime(DateTime.Now.Year, i + 1, 1), new DateTime(DateTime.Now.Year, i + 1, 1).AddMonths(1).AddDays(-1), i);
            }
            ViewBag.d1 = infoTime[0, 0];
            ViewBag.d2 = infoTime[1, 0];
            ViewBag.d3 = infoTime[2, 0];
            ViewBag.d4 = infoTime[3, 0];
            ViewBag.d5 = infoTime[4, 0];
            ViewBag.d6 = infoTime[5, 0];
            ViewBag.d7 = infoTime[6, 0];
            ViewBag.d8 = infoTime[7, 0];
            ViewBag.d9 = infoTime[8, 0];
            ViewBag.d10 = infoTime[9, 0];
            ViewBag.d11 = infoTime[10, 0];
            ViewBag.d12 = infoTime[11, 0];

            ViewBag.d13 = infoTime[0, 1];
            ViewBag.d14= infoTime[1, 1];
            ViewBag.d15 = infoTime[2, 1];
            ViewBag.d16 = infoTime[3, 1];
            ViewBag.d17 = infoTime[4, 1];
            ViewBag.d18 = infoTime[5, 1];
            ViewBag.d19 = infoTime[6, 1];
            ViewBag.d20 = infoTime[7, 1];
            ViewBag.d21 = infoTime[8, 1];
            ViewBag.d22 = infoTime[9, 1];
            ViewBag.d23 = infoTime[10, 1];
            ViewBag.d24 = infoTime[11, 1];

            ViewBag.d25 = setDelayAll(new DateTime(DateTime.Now.Year, 1, 1), new DateTime(DateTime.Now.Year, 1, 1).AddMonths(1).AddDays(-1));
            ViewBag.d26 = setDelayAll(new DateTime(DateTime.Now.Year, 2, 1), new DateTime(DateTime.Now.Year, 2, 1).AddMonths(1).AddDays(-1));
            ViewBag.d27 = setDelayAll(new DateTime(DateTime.Now.Year, 3, 1), new DateTime(DateTime.Now.Year, 3, 1).AddMonths(1).AddDays(-1));
            ViewBag.d28 = setDelayAll(new DateTime(DateTime.Now.Year, 4, 1), new DateTime(DateTime.Now.Year, 4, 1).AddMonths(1).AddDays(-1));
            ViewBag.d29 = setDelayAll(new DateTime(DateTime.Now.Year, 5, 1), new DateTime(DateTime.Now.Year, 5, 1).AddMonths(1).AddDays(-1));
            ViewBag.d30 = setDelayAll(new DateTime(DateTime.Now.Year, 6, 1), new DateTime(DateTime.Now.Year, 6, 1).AddMonths(1).AddDays(-1));
            ViewBag.d31 = setDelayAll(new DateTime(DateTime.Now.Year, 7, 1), new DateTime(DateTime.Now.Year, 7, 1).AddMonths(1).AddDays(-1));
            ViewBag.d31 = setDelayAll(new DateTime(DateTime.Now.Year, 8, 1), new DateTime(DateTime.Now.Year, 7, 1).AddMonths(1).AddDays(-1));
            ViewBag.d31 = setDelayAll(new DateTime(DateTime.Now.Year, 9, 1), new DateTime(DateTime.Now.Year, 7, 1).AddMonths(1).AddDays(-1));
            ViewBag.d31 = setDelayAll(new DateTime(DateTime.Now.Year, 10, 1), new DateTime(DateTime.Now.Year, 7, 1).AddMonths(1).AddDays(-1));
            ViewBag.d31 = setDelayAll(new DateTime(DateTime.Now.Year, 11, 1), new DateTime(DateTime.Now.Year, 7, 1).AddMonths(1).AddDays(-1));
            ViewBag.d31 = setDelayAll(new DateTime(DateTime.Now.Year, 12, 1), new DateTime(DateTime.Now.Year, 7, 1).AddMonths(1).AddDays(-1));
            return View(models);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private int inTime = 0;
        private int outTime = 0;
        private int[,] infoTime = new int[12, 2];

        private void setDatas(DateTime start, DateTime finish, int x)
        {
            inTime = 0;
            outTime = 0;
            //var count= context.WorkOrden.Where(c => ((DateTime)c.dateFinish - (DateTime)c.dateStart).TotalDays <= 12).Where(c => ((DateTime)c.dateFinish).Day >= ((DateTime)start).Day && ((DateTime)c.dateFinish).Day <= ((DateTime)finish).Day ).Count();
            //int x = (int)count;
            var count = (from w in context.WorkOrden
                         where w.dateFinish != null && w.dateFinish >= start && w.dateFinish <= finish
                         select w);
            var query = from a in context.Area
                        select a;
            var sum = query.Sum(q => q.daysMax);
            foreach (var item in count.ToList())
            {
                if (((DateTime)item.dateFinish - (DateTime)item.dateStart).TotalDays <= (int)sum)
                {
                    inTime++;
                }
                else
                {
                    outTime++;
                }
            }
            infoTime[x, 0] = inTime;
            infoTime[x, 1] = outTime;
        }

        private int setDelayAll(DateTime start, DateTime finish)
        {
            var count = context.DelayWork.Where(c => c.dateFinish != null && c.dateDelay >= start && c.dateFinish <= finish).Count();

            return count;
        }

        [HttpGet]
        public ActionResult Details(int id)
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
                            where a.WorkOrdenId == id
                            select new AreaViewModel { Area = ar, Area_Orden = a };
            model.Area = queryArea.ToList();
            var queryDelay = from d in context.DelayWork
                             join c in context.DelayCode on d.DelayCodeId equals c.DelayCodeId
                             join s in context.SubCodes on d.SubCodesId equals s.SubCodesId
                             join u in context.Users on d.UsersId equals u.UsersId
                             join a in context.Area on u.AreaId equals a.AreaId
                             where d.WorkOrdenId == id
                             select new DelayArea { DelayWork = d, DelayCode = c, SubCodes = s, Area = a };
            model.Delay = queryDelay.ToList();
            //var queryArea=
            return View(model);
        }

        public ActionResult showDetail(int id)
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
                            where a.WorkOrdenId == id
                            select new AreaViewModel { Area = ar, Area_Orden = a };
            model.Area = queryArea.ToList();
            var queryDelay = (from d in context.DelayWork
                             join c in context.DelayCode on d.DelayCodeId equals c.DelayCodeId
                             join s in context.SubCodes on d.SubCodesId equals s.SubCodesId
                             join u in context.Users on d.UsersId equals u.UsersId
                             join a in context.Area on u.AreaId equals a.AreaId
                             where d.WorkOrdenId == id
                             select new DelayArea { DelayWork = d, DelayCode = c, SubCodes = s, Area = a }).OrderByDescending(c=>c.DelayWork.dateDelay);
            model.Delay = queryDelay.ToList();
            var comment = context.DelayComment.Include("Users").Where(c => c.DelayWorkId == id).OrderByDescending(c=>c.dateComment).ToList();
            model.DelayComment = comment.ToList();
            var comments = context.OrdenComment.Include("Users").Where(o => o.WorkOrdenId == id).OrderByDescending(o => o.dateComment).ToList();
            model.OrdenComment = comments.ToList();
            var last = context.Area_Orden.Include("Area").Where(a=> a.WorkOrdenId == id).Where(a => a.dateFinish == null).ToList();
            model.LastArea = last.ToList();
            
            //var 
            return PartialView("_modalDetail",model);
        }

    }

}