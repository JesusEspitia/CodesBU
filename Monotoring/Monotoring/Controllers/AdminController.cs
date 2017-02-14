using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Monotoring.Context;

namespace Monotoring.Controllers
{
    public class AdminController : Controller
    {
        private TrackContext context = new TrackContext();
        // GET: Admin
        public ActionResult Index()
        {
            if (Convert.ToString(Session["userType"]) == "3")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        
        public ActionResult ListNewRequest()
        {
            try
            {
                var model = context.UserNewRequest.ToList();
                return View(model);
            }
            catch
            {
                return View();
            }
        }  

        [HttpGet]
        public ActionResult DenyRequest(int id)
        {
            try
            {
                var model = context.UserNewRequest.Find(id);
                context.UserNewRequest.Remove(model);
                context.SaveChanges();
                return RedirectToAction("ListNewRequest");
            }
            catch
            {
                return View();
            }
        }    
    }
}
