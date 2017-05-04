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
        [DisplayName("Nombre de usuario (Usuario de red)")]
        public string userNameRequest { get; set; }
        [DisplayName("Nombre completo")]
        public string fullname { get; set; }
        [DisplayName("Correo electrónico")]
        public string email { get; set; }
        [DisplayName("Área")]
        public int areaRequest { get;  set; }

        [ForeignKey("areaRequest")]
        [DisplayName("Área")]
        public Area Area { get; set; }
    }
}