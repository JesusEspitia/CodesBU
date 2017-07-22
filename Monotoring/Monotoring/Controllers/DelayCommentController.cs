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
                if (Convert.ToString(Session["userType"]) != "")
                {
                    ViewBag.DelayWork = new SelectList(context.DelayWork, "DelayWorkId", "DelayWorkId");
                    ViewBag.Users = new SelectList(context.Users, "UsersId", "fullname");
                    DelayComment model = new DelayComment();
                    model.DelayWorkId = id;
                    model.dateComment = DateTime.Now;
                    model.UsersId = (int)Session["userId"];
                    var commnt = context.DelayWork.Include("SubCodes").Where(c => c.DelayWorkId == id).ToList();
                    foreach(var item in commnt)
                    {
                        model.titleComment =item.SubCodes.DescripCode;
                    }
                    return PartialView("_modelNewComment",model);
                }
                else
                {
                    return PartialView("Index", "Home");
                }
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
                    return RedirectToAction("Index", "Home");
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
                var comment = context.DelayComment.Include("Users").Where(c => c.DelayWorkId == id).OrderByDescending(c => c.dateComment).ToList();

                //ViewBag.Comments = commet.ToList();
                return PartialView("_Comments",comment);
            }
            catch (Exception ex)
            {
                string x=ex.Message;
                return View();
            }
        }

        

    }
}