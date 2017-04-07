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
        [DisplayName("Score")]
        public int? CandidateScore { get; set; }
        [DisplayName("Review")]
        public bool Review { get; set; }
        [DisplayName("Accepted")]
        public bool Accepted { get; set; }
        public int FormId { get; set; }

        [ForeignKey("FormId")]
        public Form Form { get; set; }
    }
}