using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Monotoring.Models
{
    public class DelayWork
    {
        public int DelayWorkId { get; set; }
        [DisplayName("Orden")]
        public int WorkOrdenId { get; set; }
        [DisplayName("Tipo de retraso")]
        public int DelayCodeId { get; set; }
        [DisplayName("Descripción del retraso")]
        public int SubCodesId { get; set; }
        [DisplayName("Responsable de las acciones")]
        public string Responsable { get; set; }
        [DisplayName("Número de reporte que se genero")]
        public int? ReportNo { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Fecha de inicio")]
        public DateTime dateDelay { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Fecha de liberación")]
        public DateTime? dateFinish { get; set; }
        [DisplayName("Usuario")]
        public int UsersId { get; set; }

        [ForeignKey("WorkOrdenId")]
        [DisplayName("Orden")]
        public WorkOrden WorkOrden { get; set; }
        [ForeignKey("DelayCodeId")]
        [DisplayName("Tipo de retraso")]
        public DelayCode DelayCode { get; set; }
        [ForeignKey("UsersId")]
        [DisplayName("Usuario")]
        public Users Users { get; set; }
        [ForeignKey("SubCodesId")]
        public SubCodes SubCodes { get; set; }

        public ICollection<DelayComment> DelayComment { get; set; }
    }
}