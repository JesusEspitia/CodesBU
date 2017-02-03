using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Monotoring.Models
{
    public class Area
    {
        [DisplayName("Área")]
        public int AreaId { get; set; }
        [DisplayName("Área")]
        public string AreaName { get; set; }
        [DisplayName("Descripción")]
        public string descripArea { get; set; }
        [DisplayName("Días Máximos")]
        public int daysMax { get; set; }


        public ICollection<Users> Users { get; set; }
        public ICollection<Area_Orden> Area_Orden { get; set; }
        
    }
}