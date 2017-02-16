using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Monotoring.Models
{
    public class FamilyProduct
    {
        public int FamilyProductId { get; set; }
        [DisplayName("Familia del producto")]
        public string nameFamily { get; set; }

        public ICollection<Catalog> Catalog { get; set; }
    }
}