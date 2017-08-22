using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Monotoring.Models;
using Monotoring.Context;

namespace Monotoring.Controllers
{
    public class DeliveryOrderController : Controller
    {
        private TrackContext context = new TrackContext();

        // GET: DeliveryOrder

        // GET: DeliveryOrder/Create}
        [HttpGet]
        public ActionResult Create(int id, int areaid)
        {
            if (areaid == 2 || areaid == 3)
            {
                Session["temparea"] = areaid;
                Session["tempid"] = id;
                int InArea = areaid;
                bool cont = true;
                int realID = 0;
                var model = from d in context.DeliveryOrder
                            where d.WorkOrdenID == id
                            select d;
                foreach (var item in model.ToList())
                {
                    realID = item.DeliveryOrderID;
                }
                DeliveryOrder dl = context.DeliveryOrder.Find(realID);
                switch (InArea)
                {
                    case 2:
                        if (dl.date_area_One == null)
                        {
                            cont = true;
                        }
                        else
                        {
                            cont = false;
                        }
                        break;
                    case 3:
                        if (dl.date_area_Two == null)
                        {
                            cont = true;
                        }
                        else
                        {
                            cont = false;
                        }
                        break;
                }
                if (cont == true)
                {
                    return PartialView("_deliveryView", dl);
                }
                else
                {
                    //return RedirectToAction("showDetail", "Home",dl.WorkOrdenID);
                    return Content("<script language='javascript' type='text/javascript'>alert('Ya ingreso la fecha de entrega. Gracias.');</script>");
                }
            }
            else
            {
                return RedirectToAction("reload", new { id = id, areaid = areaid });

            }

        }

        public ActionResult reload(int id, int areaid)
        {
            return RedirectToAction("FinishOrden", "Area_Orden", new { id = id, areaid = areaid });
        }

        // POST: DeliveryOrder/Create
        [HttpPost,ActionName("Create")]
        public ActionResult Create(DeliveryOrder model)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    context.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    int area = (int)Session["temparea"];
                    int id = (int)Session["tempid"];
                    return RedirectToAction("FinishOrden", "Area_Orden", new { id = id, areaid = area });
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch(Exception ex)
            {
                var x= ex.Message;
                return View();
            }
        }
        
    }
}
