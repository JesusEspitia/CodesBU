using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CandidateTest.Models
{
    public class Candidate
    {
        public int CandidateId { get; set; }
        [DisplayName("Candidate´s Name")]
        public string CandidateName { get; set; }
        [DisplayName("Position")]
        public string CandidatePosition { get; set; }
        [DisplayName("HR Rep.")]
        public string HR { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Interview")]
        public DateTime InterviewDate { get; set; }
        [DisplayName("Hiring Manager (e-mail)")]
        public string Manager { get; set; }
        public string CandidateType { get; set; }
        [DisplayName("Score")]
        public int CandidateScore { get; set; }
    }
}