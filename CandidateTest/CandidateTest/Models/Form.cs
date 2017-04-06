using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CandidateTest.Models
{
    public class Form
    {
        public int FormId { get; set; }
        [DisplayName("Candidate´s Name")]
        public string Candidate { get; set; }
        [DisplayName("Positition")]
        public string Positiion { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Interview")]
        public DateTime InterviewDate { get; set; }
        [DisplayName("HR Rep.")]
        public string HR_rep { get; set; }
        public string candidate_type { get; set; }
        [DisplayName("Hiring Manager (e-mail)")]
        public string manager_email { get; set; } 
        [DisplayName("Technical Skills")]
        public string question1 { get; set; }
        [DisplayName("Motivated to do the work")]
        public string question2 { get; set; }
        [DisplayName("Team Skills in Similar Gruops")]
        public string question3 { get; set; }
        [DisplayName("Problem Solving and Quality of Things")]
        public string question4 { get; set; }
        [DisplayName("Achieved Similar Results")]
        public string question5 { get; set; }
        [DisplayName("Planning and Executing")]
        public string question6 { get; set; }
        [DisplayName("Continuous Improvement")]
        public string question7 { get; set; }
        [DisplayName("Environment and Motivational Fit")]
        public string question8 { get; set; }
        [DisplayName("Trend for Growth")]
        public string question9 { get; set; }
        [DisplayName("Character and Values")]
        public string question10 { get; set; }
        [DisplayName("Candidate´s Strengths")]
        public string Strengths { get; set; }
        [DisplayName("Candidate´s Weaknesses")]
        public string Weaknesses { get; set; }
        [DisplayName("Recommendations")]
        public string Recommendations { get; set; }
        [DisplayName("Interviewer")]
        public string Interviewer { get; set; }
        [DisplayName("Do your recommend this Candidate for the next step?")]
        public string Continue { get; set; }

    }
}