using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CandidateTest.Models;
using CandidateTest.Context;

namespace CandidateTest.Controllers
{
    public class FormController : Controller
    {
        private CandidateContext context = new CandidateContext();
        // GET: Form
        public ActionResult Index()
        {
            try
            {
                return View(new Form());
            }
            catch (Exception)
            {
                return View();
            }
            
        }
        [HttpPost]
        public ActionResult Create(Form model)
        {
            if (ModelState.IsValid)
            {
                bool acp = false;
                model.InterviewDate = DateTime.Now;
                context.Form.Add(model);
                if (model.Continue == "Yes")
                {
                    acp = true;
                }

                Candidate c = new Candidate()
                {
                    CandidateName = model.Candidate,
                    Review = false,
                    CandidateScore = ((Convert.ToInt32(model.question1) + Convert.ToInt32(model.question2) + Convert.ToInt32(model.question2) +
                    Convert.ToInt32(model.question4) + Convert.ToInt32(model.question5) + Convert.ToInt32(model.question6) + Convert.ToInt32(model.question7) +
                    Convert.ToInt32(model.question8) + Convert.ToInt32(model.question9) + Convert.ToInt32(model.question10)) * 100) / 400,
                    FormId = model.FormId,
                    Accepted = acp
                };
                context.Candidate.Add(c);
                context.SaveChanges();
                return RedirectToAction("Finish");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            try
            {
                var model = context.Form.Find(id);
                var model2 = context.Candidate.Where(c => c.FormId == id).ToList();
                foreach(var item in model2.ToList())
                {
                    item.Review = true;
                }
                ViewBag.d1 = model.question1;
                ViewBag.d2 = model.question2;
                ViewBag.d3 = model.question3;
                ViewBag.d4 = model.question4;
                ViewBag.d5 = model.question5;
                ViewBag.d6 = model.question6;
                ViewBag.d7 = model.question7;
                ViewBag.d8 = model.question8;
                ViewBag.d9 = model.question9;
                ViewBag.d10 = model.question10;
                context.SaveChanges();
                return View(model);
            }
            catch 
            {
                return View();
            }
        }

        public ActionResult Finish()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                var model = context.Form.Find(id);
                context.Form.Remove(model);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return RedirectToAction("Index","Home");
            }
        }
    }
}