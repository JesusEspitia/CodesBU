using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Monotoring.Models
{
    public class Catalog
    {
        public int CatalogId { get; set; }
        [DisplayName("No. Producto")]
        public string CatalogNo { get; set; }
        [DisplayName("Porducto")]
        public string CatalogDescrip { get; set; }
        public ICollection<WorkOrden> WorkOrden { get; set; }
    }
}