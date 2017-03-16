using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Monotoring.Models
{
    public class OrdensView
    {
        public WorkOrden WorkOrden { get; set; }
        public DelayWork DelayWork { get; set; }
        public Area_Orden Area_Orden { get; set; }
        public Area Area { get; set; }
        public Catalog Catalog { get; set; }
    }
}