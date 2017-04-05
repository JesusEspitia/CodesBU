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
        public int CandidateId { get; set; }
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