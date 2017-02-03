using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Monotoring.Models
{
    public class Employee_type
    {
        [DisplayName("Cargo")]
        public int Employee_typeId { get; set; }
        [DisplayName("Cargo")]
        public string NameType { get; set; }
        [DisplayName("Nivel de permisos")]
        public int permission { get; set; }
        [DisplayName("Descripción del cargo")]
        public string descrip_type { get; set; }  
        
        public ICollection<Users> Users { get; set; }
    }
}