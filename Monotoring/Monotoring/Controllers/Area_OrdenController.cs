using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Monotoring.Models;
using Monotoring.Context;
using System.IO;
using System.IO.Ports;
using System.Net;
using System.Net.Mail;

namespace Monotoring.Controllers
{
    public class Area_OrdenController : Controller
    {
        private TrackContext context = new TrackContext();
        // GET: Area_Orden
        public ActionResult Index()
        {
            if (Convert.ToString(Session["userType"]) != "")
            {
                var id = (int)Session["userId"];
                var lst = from a in context.Area_Orden
                          join u in context.Users on a.AreaId equals u.AreaId
                          join w in context.WorkOrden on a.WorkOrdenId equals w.WorkOrdenId
                          join d in context.DelayWork on w.WorkOrdenId equals d.WorkOrdenId
                          join ar in context.Area on a.AreaId equals ar.AreaId
                          join c in context.Catalog on w.CatalogId equals c.CatalogId
                          where u.UsersId == id && a.dateFinish == null && d.UsersId == id && d.dateFinish == null
                          select new OrdensView { WorkOrden = w, DelayWork = d, Area_Orden = a, Area = ar, Catalog = c };
                var modelDelay = lst.ToList();
                //ViewBag.OrdensDelay = modelOpen;

                var lst2 = from a in context.Area_Orden
                           join u in context.Users on a.AreaId equals u.AreaId
                           join w in context.WorkOrden on a.WorkOrdenId equals w.WorkOrdenId
                           join ar in context.Area on a.AreaId equals ar.AreaId
                           join c in context.Catalog on w.CatalogId equals c.CatalogId
                           where u.UsersId == id && a.dateFinish == null
                           select new OrdensView { WorkOrden = w, Area_Orden = a, Area = ar, Catalog = c };
                var modelOpen = lst2.ToList();
                //ViewBag.OrdensOpen = modelDelay;     
                foreach (var item in modelDelay.ToList())
                {
                    foreach (var item2 in modelOpen.ToList())
                    {
                        if (item.WorkOrden.WorkOrdenId == item2.WorkOrden.WorkOrdenId)
                        {
                            modelOpen.Remove(item2);
                        }
                    }
                }
                ViewBag.OrdensDelay = modelDelay;
                ViewBag.OrdensOpen = modelOpen;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult FinishOrden(int id)
        {
            var check = context.DelayWork.Where(d => d.WorkOrdenId == id).Where(d => d.dateFinish == null).ToList();
            if (check.ToList().Count == 0)
            {
                var delay = from d in context.DelayWork
                            where d.WorkOrdenId == id && d.dateFinish == null
                            select d;
                var lstdelay = delay.ToList();
                if (lstdelay.Count < 1)
                {
                    Session["stop"] = null;
                    int area = (int)Session["userAreaId"];
                    var ar = from u in context.Area
                             where u.orden == area
                             select u;
                    foreach (var item in ar.ToList())
                    {
                        area = (int)item.AreaId;
                    }
                    var up = from w in context.Area_Orden
                             where w.WorkOrdenId == id && w.AreaId == area
                             select w;
                    foreach (Area_Orden a in up)
                    {
                        a.dateFinish = DateTime.Now;
                        a.notify = true;
                        //finish = a.AreaId;
                    }
                    if (area == 6)
                    {
                        var upOrden = from w in context.WorkOrden
                                      where w.WorkOrdenId == id
                                      select w;

                        foreach (WorkOrden w in upOrden)
                        {
                            w.dateFinish = DateTime.Now;
                        }
                    }
                    context.SaveChanges();
                    //if (area != 6)
                    //{
                    //    int areanext = 0;
                    //    string to="";
                    //    int areaRoot = (int)Session["userAreaId"] + 1;
                    //    var an = from a in context.Area
                    //             where a.orden == areaRoot
                    //             select a;
                    //    foreach(var item in an.ToList())
                    //    {
                    //        areanext = (int)item.AreaId;
                    //    }
                    //    var emails = from u in context.Users
                    //                 where u.AreaId == areanext
                    //                 select u;
                    //    int i = 1;
                    //    foreach(var item in emails.ToList())
                    //    {
                    //        if (i == emails.ToList().Count)
                    //        {
                    //            to += item.emailuser;
                    //        }
                    //        else
                    //        {
                    //            to += item.emailuser + ",";
                    //        }
                    //    }
                    //    sendEmail("Pruena", to);
                    //}

                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Stop = "No puede finalizar la orden ya que cuenta con un retraso abierto, debe ser cerrado antes.";
                    Session["stop"] = "No puede finalizar la orden ya que cuenta con un retraso abierto, debe ser cerrado antes.";
                    return RedirectToAction("Index");
                    //return Content("<script language='javascript' type='text/javascript'>alert('No puede finalizar la orden ya que cuenta con un retraso abierto, debe ser cerrado antes.');</script>");
                }
            }
            else
            {
                //this.ModelState.AddModelError(string.Empty, "No puede finalizar la orden ya que cuenta con un retraso abierto, debe ser cerrado antes.");
                Session["stop"] = "No puede finalizar la orden ya que cuenta con un retraso abierto, debe ser cerrado antes.";
                return RedirectToAction("Index","Home");
            }
        }
        // GET: Area_Orden/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Area_Orden/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Area_Orden/Create
        [HttpPost]
        public ActionResult Create(Area_Orden item)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Area_Orden/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Area_Orden/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Area_Orden/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Area_Orden/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private void sendEmail(string body,string to)
        {
            MailMessage mail = new MailMessage();
            SmtpClient client = new SmtpClient();


            client.Host = "BN1PRD9201.prod.outlook.com";
            //client.Host = "smtp.google.com";
            client.Port = 25;
            client.EnableSsl = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            //client.Credentials = new System.Net.NetworkCredential("leopoldo_espitia@baxter.com", "Baxter6.");

            mail.From = new MailAddress("baxnotificaciones@baxter.com", "Trackbatch Notificaciones.");
            mail.To.Add(to);
            
            mail.Subject = "Notificacion";
            mail.Body = body;
            mail.IsBodyHtml = true;
            client.Send(mail);
        }
    
    }

}
