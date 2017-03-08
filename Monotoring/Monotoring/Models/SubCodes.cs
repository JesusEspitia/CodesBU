using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Monotoring.Models
{
    public class SubCodes
    {
        public int SubCodesId { get; set; }
        public string DescripCode { get; set; }
        public int DelayCodeId { get; set; }
        
        [ForeignKey("DelayCodeId")]
        public DelayCode DelayCode { get; set; }

        public ICollection<DelayWork> DelayWork { get; set; }
    }
}