using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Monotoring.Context;
using System.Data.Entity.Core.Objects;

namespace Monotoring.Controllers
{
    public class DashboardController : Controller
    {
        private TrackContext context = new TrackContext();
        private int inTime = 0;
        private int outTime = 0;
        private int[,] infoTime = new int[7, 2];
        // GET: Dashboard
        public ActionResult Index()
        {
            if (Convert.ToString(Session["userType"]) == "3" || Convert.ToString(Session["userType"]) == "2")
            {
                var orden = context.WorkOrden.Include("Catalog").Where(o => o.dateStart != null && o.dateFinish == null).ToList();
                ViewBag.Orden = orden;
                var delay = context.DelayWork.Include("WorkOrden").Include("DelayCode").Include("Users").ToList();
                ViewBag.Delay = delay;
                for(int i = 0; i < 7; i++)
                {
                    setDatas(new DateTime(DateTime.Now.Year, i + 1, 1), new DateTime(DateTime.Now.Year, i + 1, 1).AddMonths(1).AddDays(-1), i);
                }
                ViewBag.d1 = infoTime[0,0];
                ViewBag.d2 = infoTime[1,0];
                ViewBag.d3 = infoTime[2,0];
                ViewBag.d4 = infoTime[3,0];
                ViewBag.d5 = infoTime[4,0];
                ViewBag.d6 = infoTime[5,0];
                ViewBag.d7 = infoTime[6,0];

                ViewBag.d8 = infoTime[0, 1];
                ViewBag.d9 = infoTime[1, 1];
                ViewBag.d10 = infoTime[2, 1];
                ViewBag.d11 = infoTime[3, 1];
                ViewBag.d12 = infoTime[4, 1];
                ViewBag.d13 = infoTime[5, 1];
                ViewBag.d14 = infoTime[6, 1];

                ViewBag.d15 = setDelayAll(new DateTime(DateTime.Now.Year, 1, 1), new DateTime(DateTime.Now.Year, 1, 1).AddMonths(1).AddDays(-1));
                ViewBag.d16 = setDelayAll(new DateTime(DateTime.Now.Year, 2, 1), new DateTime(DateTime.Now.Year, 2, 1).AddMonths(1).AddDays(-1));
                ViewBag.d17 = setDelayAll(new DateTime(DateTime.Now.Year, 3, 1), new DateTime(DateTime.Now.Year, 3, 1).AddMonths(1).AddDays(-1));
                ViewBag.d18 = setDelayAll(new DateTime(DateTime.Now.Year, 4, 1), new DateTime(DateTime.Now.Year, 4, 1).AddMonths(1).AddDays(-1));
                ViewBag.d19 = setDelayAll(new DateTime(DateTime.Now.Year, 5, 1), new DateTime(DateTime.Now.Year, 5, 1).AddMonths(1).AddDays(-1));
                ViewBag.d20 = setDelayAll(new DateTime(DateTime.Now.Year, 6, 1), new DateTime(DateTime.Now.Year, 6, 1).AddMonths(1).AddDays(-1));
                ViewBag.d21 = setDelayAll(new DateTime(DateTime.Now.Year, 7, 1), new DateTime(DateTime.Now.Year, 7, 1).AddMonths(1).AddDays(-1));
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        private void setDatas(DateTime start, DateTime finish, int x)
        {
            inTime = 0;
            outTime = 0;
            //var count= context.WorkOrden.Where(c => ((DateTime)c.dateFinish - (DateTime)c.dateStart).TotalDays <= 12).Where(c => ((DateTime)c.dateFinish).Day >= ((DateTime)start).Day && ((DateTime)c.dateFinish).Day <= ((DateTime)finish).Day ).Count();
            //int x = (int)count;
            var count = (from w in context.WorkOrden
                        where w.dateFinish!=null && w.dateFinish >= start && w.dateFinish <= finish 
                        select w);
            var query = from a in context.Area
                        select a;
            var sum = query.Sum(q => q.daysMax);
            foreach(var item in count.ToList())
            {
                if(((DateTime)item.dateFinish-(DateTime)item.dateStart).TotalDays <= (int)sum)
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
        private int setDelayAll(DateTime start,DateTime finish)
        {
            var count = context.DelayWork.Where(c => c.dateFinish != null && c.dateDelay >= start && c.dateFinish <= finish).Count();

            return count;
        }
    }

    
}