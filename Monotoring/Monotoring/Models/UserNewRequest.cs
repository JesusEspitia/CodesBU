using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public string areaRequest { get;  set; }
    }
}