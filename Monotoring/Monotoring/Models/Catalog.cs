using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int? FamilyProductId { get; set; }

        public ICollection<WorkOrden> WorkOrden { get; set; }

        [ForeignKey("FamilyProductId")]
        public FamilyProduct FamilyProduct { get; set; }
    }
}