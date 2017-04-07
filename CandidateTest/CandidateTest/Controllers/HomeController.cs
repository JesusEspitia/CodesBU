﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CandidateTest.Context;
using CandidateTest.Models;

namespace CandidateTest.Controllers
{
    public class HomeController : Controller
    {
        private CandidateContext context = new CandidateContext();
        
        public ActionResult Index()
        {
            var model = context.Candidate.Include("Form").Where(c => c.Review == false).Where(c=>c.Form.Continue=="Yes").ToList();
            var model2= context.Candidate.Include("Form").Where(c => c.Review == false).Where(c=>c.Form.Continue=="No").ToList();
            ViewBag.candidateList = model.ToList();
            ViewBag.candidate2 = model2.ToList();
            var model3 = context.Candidate.Include("Form").Where(c => c.Review == true).ToList();
            ViewBag.history = model3.ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}