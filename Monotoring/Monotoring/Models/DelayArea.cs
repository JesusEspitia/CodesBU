using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Monotoring.Models
{
    public class DelayArea
    {
        public DelayWork DelayWork { get; set; }
        public DelayCode DelayCode { get; set; }
        public SubCodes SubCodes { get; set; }
        public Area Area { get; set; }
    }
}