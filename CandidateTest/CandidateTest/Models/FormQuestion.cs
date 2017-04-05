using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CandidateTest.Models
{
    public class FormQuestion
    {
        public int FormQuestionId { get; set; }
        public int FormId { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }

        [ForeignKey("FormId")]
        public Form Form { get; set; }
        [ForeignKey("QuestionId")]
        public Question Question { get; set; }
        [ForeignKey("AnswerId")]
        public Answer Answer { get; set; }
    }
}