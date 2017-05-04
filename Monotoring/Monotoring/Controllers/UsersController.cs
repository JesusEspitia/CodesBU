using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.DirectoryServices;
using Monotoring.Models;
using Monotoring.Context;
using System.Threading.Tasks;
using System.Dynamic;
using System.DirectoryServices.AccountManagement;

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
            if (Convert.ToString(Session["userType"]) == "3")
            {
                var user = context.Users.Include("Area").Include("Type").ToList();
                return View(user);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        //login
        //[AllowAnonymous]
        //public ActionResult Login()
        //{
        //    Session["ErrorLog"] = 0;
        //    return View();

        //}
        //[HttpPost]
        //[AllowAnonymous]
        //public async Task<ActionResult> Login(Users user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        string log = user.login();
        //        if (log== "in")
        //        {
        //            Session["userName"] = user.username;
        //            Session["userId"] = user.UsersId;
        //            Session["userType"] = user.TypeId;
        //            Session["userAreaId"] = user.AreaId;
        //            int utype = Convert.ToInt32(Session["userType"]);
        //            var type = from t in context.Employee_type
        //                       where t.Employee_typeId == utype
        //                       select t;
        //            var dt = type.ToList();
        //            foreach(var d in dt)
        //            {
        //                Session["userType"] = d.permission;
        //            }
        //            Session["ErrorLog"] = 0;
        //            return RedirectToAction("Index", "Home");
        //        }
        //        else                
        //        {
        //            if (log == "pass")
        //            {
        //                Session["ErrorLog"] = 1;
        //            }
        //            else
        //            {
        //                Session["ErrorLog"] = 2;
        //            }
        //            return View();
        //        }
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //}
        [HttpGet]
        public ActionResult Logout()
        {
            Session["userName"] = "";
            Session["userType"] = 0;
            System.Web.Security.FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        // GET: Users/Create
        public ActionResult Create(string username="",string fullname="",string email="",int  area=0)
        {
            if (Convert.ToString(Session["userType"]) == "3")
            {
                //var type = context.Employee_type.ToList();
                ViewBag.Employee_type = new SelectList(context.Employee_type, "Employee_typeId", "NameType");
                ViewBag.Area = new SelectList(context.Area, "AreaId", "AreaName");
                Users model = new Users();
                model.username = username;
                model.fullname = fullname;
                model.emailuser = email;
                model.AreaId = area;
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
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
                    if (ValidUserExists(user.username) == true && UserIsNotRegister(user.username) == false)
                    {
                        context.Users.Add(user);
                        context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Employee_type = new SelectList(context.Employee_type, "Employee_typeId", "NameType");
                        ViewBag.Area = new SelectList(context.Area, "AreaId", "AreaName");
                        this.ModelState.AddModelError(string.Empty, "El usuario no existe dentro de los registros, o ya fue registrado.");
                        return View();
                    }                    
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
            if (Convert.ToString(Session["userType"]) == "3")
            {
                ViewBag.Employee_type = new SelectList(context.Employee_type, "Employee_typeId", "NameType");
                ViewBag.Area = new SelectList(context.Area, "AreaId", "AreaName");
                Users user = context.Users.Find(id);
                return View(user);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
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
        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (Convert.ToString(Session["userType"]) == "3")
            {
                var model = context.Users.Find(id);
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: Users/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                // TODO: Add delete logic here
                if (ModelState.IsValid)
                {
                    var model = context.Users.Find(id);
                    context.Users.Remove(model);
                    context.SaveChanges();
                    return RedirectToAction("Index");
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
     
        public bool ValidUserExists(string username)
        {
            using(var domainContext = new PrincipalContext(ContextType.Domain, "global.baxter.com"))
            {
                using (var findUser = UserPrincipal.FindByIdentity(domainContext, IdentityType.SamAccountName, username))
                {
                    if (findUser != null)
                    {
                        return true;
                    }
                    else
                        return false;
                }
            }
        }
        public bool UserIsNotRegister(string username)
        {
            var user = from u in context.Users
                       where u.username == username
                       select u;
            var listUser = user.ToList();
            if (listUser.Count >= 1)
            {
                return true;
            }
            else
                return false;
        }

        [HttpGet]
        public ActionResult NewUserRequest()
        {
            ViewBag.Area = new SelectList(context.Area, "AreaId", "AreaName");
            return View(new UserNewRequest());
        }
        [HttpPost]
        public ActionResult NewUserRequest(UserNewRequest model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ViewBag.Area = new SelectList(context.Area, "AreaId", "AreaName");
                    context.UserNewRequest.Add(model);
                    context.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Area = new SelectList(context.Area, "AreaId", "AreaName");
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
