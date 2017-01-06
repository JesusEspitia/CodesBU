using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Monotoring.Models
{
    public class Employee_type
    {
        public int Employee_typeId { get; set; }
        public string NameType { get; set; }
        public int permission { get; set; }
        public string descrip_type { get; set; }  
        
        public ICollection<Users> Users { get; set; }
    }
}