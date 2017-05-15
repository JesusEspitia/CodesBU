using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Monotoring.Models
{
    public class OrdenComment
    {
        public int OrdenCommentId { get; set; }
        [DisplayName("Orden:")]
        public int WorkOrdenId { get; set; }
        [DisplayName("Comentario:")]
        public string Commnet { get; set; }
        public int UsersId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Fecha")]
        public DateTime dateComment { get; set; }

        [ForeignKey("WorkOrdenId")]
        public WorkOrden WorkOrden { get; set; }
        [ForeignKey("UsersId")]
        public Users Users { get; set; }
    }
}