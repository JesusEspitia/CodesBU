using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Monotoring.Context;
using Monotoring.Models;

namespace Monotoring.Controllers
{
    public class DelayCommentController : Controller
    {
        private TrackContext context = new TrackContext();
        // GET: DelayComment
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public  ActionResult New(int id)
        {
            try
            {
                ViewBag.DelayWork = new SelectList(context.DelayWork, "DelayWorkId", "DelayWorkId");
                DelayComment model = new DelayComment();
                model.DelayWorkId = id;
                model.dateComment = DateTime.Now;
                return View(model);
            }
            catch (Exception ex)
            {

                return View();
            }
        }

        [HttpPost,ActionName("New")]
        public ActionResult New(DelayComment model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.DelayComment.Add(model);
                    context.SaveChanges();
                    return RedirectToAction("Index", "Area_Orden");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult List(int id)
        {
            try
            {
                var comment = context.DelayComment.Where(c => c.DelayWorkId == id).ToList();

                //ViewBag.Comments = commet.ToList();
                return View(comment);
            }
            catch (Exception ex)
            {
                string x=ex.Message;
                return View();
            }
        }

    }
}