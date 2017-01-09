using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Monotoring.Context;

namespace Monotoring.Controllers
{
    public class NotificationController : Controller
    {
        private TrackContext context = new TrackContext();
        // GET: Notification
        public ActionResult Index()
        {
            int ordenId;
            
            if (Session["userName"].ToString() != "")
            {
                var qarea = from a in context.Area
                            where a.UsersId == (int)Session["userId"]
                            select a.AreaId;
                int areaId = qarea.First();
                if(areaId == 1)
                {
                    var qOrden = from w in context.WorkOrden
                                where w.dateStart == null
                                select w;
                    return View(qOrden);
                }
                else
                {
                    var query = from a in context.Area_Orden
                                join w in context.WorkOrden on a.WorkOrdenId equals w.WorkOrdenId
                                where a.AreaId == (int)Session["userId"]
                                select w;
                    return View(query);
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
           
            
        }
    }
}