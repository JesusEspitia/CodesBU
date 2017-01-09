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
            if (Session["userName"].ToString() != "")
            {
                var qarea = from a in context.Area
                            where a.UsersId == (int)Session["userId"]
                            select a.AreaId;
                int areaId = qarea.First();

            }
            return View();
        }
    }
}