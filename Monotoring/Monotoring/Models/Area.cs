using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Monotoring.Models
{
    public class Area
    {
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public string descripArea { get; set; }
        public int daysMax { get; set; }
        public int UsersId { get; set; }

        [ForeignKey("UsersId")]
        public Users Users { get; set; }

        public ICollection<Area_Orden> Area_Orden { get; set; }
    }
}