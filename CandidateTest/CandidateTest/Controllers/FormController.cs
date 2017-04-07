﻿using System;
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
                context.Form.Add(model);
                Candidate c = new Candidate()
                {
                    CandidateName = model.Candidate,
                    Review = false,
                    CandidateScore = ((Convert.ToInt32(model.question1) + Convert.ToInt32(model.question2) + Convert.ToInt32(model.question2) +
                    Convert.ToInt32(model.question4) + Convert.ToInt32(model.question5) + Convert.ToInt32(model.question6) + Convert.ToInt32(model.question7) +
                    Convert.ToInt32(model.question8) + Convert.ToInt32(model.question9) + Convert.ToInt32(model.question10)) * 10) / 40,
                    FormId=model.FormId
                };
                context.Candidate.Add(c);
                context.SaveChanges();
                return RedirectToAction("Index");
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
                context.SaveChanges();
                return View(model);
            }
            catch 
            {
                return View();
            }
        }
    }
}