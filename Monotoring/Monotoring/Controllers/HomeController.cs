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
            var query = from w in context.WorkOrden
                        where w.dateStart != null && w.dateFinish == null
                        select w;
            models.WorkOrden = query.ToList();
            var qArea = from a in context.Area_Orden
                        join ar in context.Area on a.AreaId equals ar.AreaId
                        select new AreaViewModel { Area = ar, Area_Orden = a };
            models.Area_Orden = qArea.ToList();
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
    }
}