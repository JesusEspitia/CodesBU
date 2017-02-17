using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Monotoring.Context;

namespace Monotoring.Controllers
{
    public class DashboardController : Controller
    {
        private TrackContext context = new TrackContext();
        // GET: Dashboard
        public ActionResult Index()
        {
            if (Convert.ToString(Session["userType"]) == "3" || Convert.ToString(Session["userType"]) == "2")
            {
                var orden = context.WorkOrden.Include("Catalog").Where(o => o.dateStart != null).ToList();
                ViewBag.Orden = orden;
                var delay = context.DelayWork.Include("WorkOrden").Include("DelayCode").Include("Users").ToList();
                ViewBag.Delay = delay;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}