using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using Monotoring.Models;
using Monotoring.Context;
using System.Threading.Tasks;
using System.Dynamic;

namespace Monotoring.Controllers
{
    public class UsersController : Controller
    {
        private TrackContext context = new TrackContext();
        private object quot;
        
        public object Employee_typeId { get; private set; }

        // GET: Users
        public ActionResult Index()
        {
            var user = context.Users.Include("Area").Include("Type").ToList();
            return View(user);
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        //login
        [AllowAnonymous]
        public ActionResult Login()
        {
            Session["ErrorLog"] = 0;
            return View();

        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(Users user)
        {
            if (ModelState.IsValid)
            {
                string log = user.login();
                if (log== "in")
                {
                    Session["userName"] = user.username;
                    Session["userId"] = user.UsersId;
                    Session["userType"] = user.TypeId;
                    Session["userAreaId"] = user.AreaId;
                    int utype = Convert.ToInt32(Session["userType"]);
                    var type = from t in context.Employee_type
                               where t.Employee_typeId == utype
                               select t;
                    var dt = type.ToList();
                    foreach(var d in dt)
                    {
                        Session["userType"] = d.permission;
                    }
                    Session["ErrorLog"] = 0;
                    return RedirectToAction("Index", "Home");
                }
                else                
                {
                    if (log == "pass")
                    {
                        Session["ErrorLog"] = 1;
                    }
                    else
                    {
                        Session["ErrorLog"] = 2;
                    }
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpGet]
        public ActionResult Logout()
        {
            Session["userName"] = "";
            Session["userType"] = 0;
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        // GET: Users/Create
        public ActionResult Create()
        {
            //var type = context.Employee_type.ToList();
            ViewBag.Employee_type = new SelectList(context.Employee_type, "Employee_typeId","NameType");
            ViewBag.Area = new SelectList(context.Area, "AreaId", "AreaName");
            return View(new Users());
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create(Users user)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(user);
                }
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Employee_type = new SelectList(context.Employee_type, "Employee_typeId", "NameType");
            ViewBag.Area = new SelectList(context.Area, "AreaId", "AreaName");
            Users user = context.Users.Find(id);
            return View(user);
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Users user)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    context.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Users/Delete/5
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
    }
}
