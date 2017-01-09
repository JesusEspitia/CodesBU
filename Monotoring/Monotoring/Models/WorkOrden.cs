using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Monotoring.Models
{
    public class WorkOrden
    {
        public int WorkOrdenId { get; set; }
        public int  CatalogId { get; set; }
        public string BatchOrden { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime dateRegistry { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? dateStart { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? dateFinish { get; set; }
        public int quantityOrden { get; set; }
        public int ordenCount { get; set; }
        [ForeignKey("CatalogId")]
        public Catalog Catalog { get; set; }


        public ICollection<Area_Orden> Area_Orden { get; set; }
        public ICollection<DelayWork> DelayWork { get; set; }

    }
}