using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CandidateTest.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        [DisplayName("Pregunta:")]
        public string ContenQuestion { get; set; }

        public ICollection<Answer> Answer { get; set; }
    }
}