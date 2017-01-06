﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Monotoring.Models
{
    public class DelayCode
    {
        public int DelayCodeId { get; set;}
        public string DelayName { get; set; }

        public ICollection<DelayWork> DelayWork { get; set; }
    }
}