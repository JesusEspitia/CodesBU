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
            if(Session["userName"].ToString() != "")
            {
                var getID = from u in context.Area
                            where u.UsersId == (int)Session["userId"]
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
                    ViewBag.myModel = model;
                    return View();
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            
        }
    }
}