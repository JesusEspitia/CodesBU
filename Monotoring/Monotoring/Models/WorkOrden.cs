using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Monotoring.Models
{
    public class WorkOrden
    {
        [DisplayName("Orden")]
        public int WorkOrdenId { get; set; }
        [DisplayName("Producto")]
        public int  CatalogId { get; set; }
        [DisplayName("No. de orden")]
        public string BatchOrden { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Fecha de registro")]
        public DateTime dateRegistry { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Inicio de orden")]
        public DateTime? dateStart { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Finalizacion de la orden")]
        public DateTime? dateFinish { get; set; }
        [DisplayName("Cantidad")]
        public int quantityOrden { get; set; }
        public int ordenCount { get; set; }
        [ForeignKey("CatalogId")]
        public Catalog Catalog { get; set; }


        public ICollection<Area_Orden> Area_Orden { get; set; }
        public ICollection<DelayWork> DelayWork { get; set; }

    }
}