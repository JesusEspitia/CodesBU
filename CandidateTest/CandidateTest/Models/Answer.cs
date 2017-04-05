using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using CandidateTest.Models;

namespace CandidateTest.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }
        [DisplayName("Answer")]
        public string AnswerContent { get; set; }
        public int QuestionId { get; set; }
        [DisplayName("Value")]
        public int AnswerValue { get; set; }

        //declare foreign key
        [ForeignKey("QuestionId")]
        public Question Question { get; set; }
    }
}