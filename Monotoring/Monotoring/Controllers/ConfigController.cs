using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Monotoring.Context;


namespace Monotoring.Controllers
{
    public class ConfigController : Controller
    {
        private TrackContext context = new TrackContext();
        // GET: Config
        public ActionResult Index()
        {
            if (Convert.ToString(Session["userType"]) == "3")
            {
                var area = context.Area.ToList();
                ViewBag.Area = area;
                var employee = context.Employee_type.ToList();
                ViewBag.Employee = employee;
                var family = context.FamilyProduct.ToList();
                ViewBag.Family = family;
                var code = context.DelayCode.ToList();
                ViewBag.Code = code;
                var sub = context.SubCodes.ToList();
                ViewBag.Sub = sub;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}