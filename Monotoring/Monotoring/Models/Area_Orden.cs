using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Monotoring.Models
{
    public class Area_Orden
    {
        public int Area_OrdenId { get; set; }
        public int AreaId { get; set; }
        public int WorkOrdenId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:MM/dd/yyyy}",ApplyFormatInEditMode =true)]
        public DateTime dateStart { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? dateFinish { get; set; }
        public bool runOrden { get; set; }

        [ForeignKey("AreaId")]
        public Area Area { get; set; }
        [ForeignKey("WorkOrdenId")]
        public WorkOrden WorkOrden { get; set; }
    }
}