using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Monotoring.Models
{
    public class AreaPlus
    {
        public int AreaPlusId { get; set; }
        [DisplayName("Usuario")]
        public int userId { get; set; }
        [DisplayName("Área")]
        public int areaId { get; set; }

        [ForeignKey("userId")]
        public Users Users { get; set; }
        [ForeignKey("areaId")]
        public Area Area { get; set; }
    }
}