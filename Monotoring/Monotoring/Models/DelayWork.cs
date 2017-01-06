using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Monotoring.Models
{
    public class DelayWork
    {
        public int DelayWorkId { get; set; }
        public int WorkOrdenId { get; set; }
        public int DelayCodeId { get; set; }
        public string descripDelay { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime dateDelay { get; set; }
        public int UsersId { get; set; }

        [ForeignKey("WorkOrdenId")]
        public WorkOrden WorkOrden { get; set; }
        [ForeignKey("DelayCodeId")]
        public DelayCode DelayCode { get; set; }
        [ForeignKey("UsersId")]
        public Users Users { get; set; }
    }
}