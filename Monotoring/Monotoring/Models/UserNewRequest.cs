using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Monotoring.Models
{
    public class UserNewRequest
    {
        public int UserNewRequestId { get; set; }
        [DisplayName("Nombre de usuario")]
        public string userNameRequest { get; set; }
        [DisplayName("Área")]
        public int areaRequest { get;  set; }

        [ForeignKey("areaRequest")]
        [DisplayName("Área")]
        public Area Area { get; set; }
    }
}