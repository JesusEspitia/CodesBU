using System;
using System.Collections.Generic;
using System.Linq;
using System.Dynamic;
using System.Web;
using System.Web.Mvc;
using Monotoring.Context;

namespace Monotoring.Controllers
{
    public class HomeController : Controller
    {
        private TrackContext context = new TrackContext();
        public ActionResult Index()
        {
            dynamic models = new ExpandoObject();
            //List<object> models = new List<object>();
            models.WorkOrden = context.WorkOrden.ToList();
            models.Area_Orden = context.Area_Orden.ToList();
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