using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Monotoring.Context;
using Monotoring.Models;

namespace Monotoring.Controllers
{
    public class GenerateOrdenController : Controller
    {
        private TrackContext context = new TrackContext();
        // GET: GenerateOrden
        public ActionResult Index()
        {
            var model = context.WorkOrden.Include("Catalog").Where(o => o.dateStart == null).ToList();
            return View(model);
        }
    }
}