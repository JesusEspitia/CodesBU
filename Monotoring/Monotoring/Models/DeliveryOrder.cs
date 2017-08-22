using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Monotoring.Models
{
    public class DeliveryOrder
    {
        public int DeliveryOrderID { get; set; }
        public int WorkOrdenID { get; set; }
        [DisplayName("Fecha de entrega de Hoja de Exportación")]
        public string date_area_One { get; set; }
        [DisplayName("Fecha de exportación")]
        public string date_area_Two { get; set; }

        [ForeignKey("WorkOrdenID")]
        public WorkOrden WorkOrden { get; set; }
    }
}