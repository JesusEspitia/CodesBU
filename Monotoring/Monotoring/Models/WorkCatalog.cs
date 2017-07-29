using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Monotoring.Models;

namespace Monotoring.Models
{
    public class WorkCatalog
    {
        public WorkOrden WorkOrden { get; set; }
        public Catalog Catalog { get; set; }
        public Area_Orden Area_Orden { get; set; }
    }
}