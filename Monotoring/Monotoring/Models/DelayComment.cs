using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Monotoring.Models
{
    public class DelayComment
    {
        public int DelayCommentId { get; set; }
        [DisplayName("Retraso")]
        public int DelayWorkId { get; set; }
        [DisplayName("Título")]
        public string titleComment { get; set; }
        [DisplayName("Comentario")]
        public string Comment { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Fecha")]
        public DateTime dateComment { get; set; }
        [DisplayName("Autor")]
        public int UsersId { get; set; }

        [ForeignKey("DelayWorkId")]
        public DelayWork DelayWork { get; set; }
        [ForeignKey("UsersId")]
        public Users Users { get; set; }
    }
}