using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Monotoring.Models
{
    public class Catalog
    {
        public int CatalogId { get; set; }
        public string CatalogNo { get; set; }
        public string CatalogDescrip { get; set; }
        public ICollection<WorkOrden> WorkOrden { get; set; }
    }
}