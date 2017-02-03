using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Monotoring.Models
{
    public class DelayCode
    {
        [DisplayName("Tipo de retraso")]
        public int DelayCodeId { get; set;}
        [DisplayName("Tipo de retraso")]
        public string DelayName { get; set; }

        public ICollection<DelayWork> DelayWork { get; set; }
    }
}