using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hostel.Models
{
    public class vacate
    {
        public long id { get; set; }
        public string hosteler_name { get; set; }
        public long reg_no { get; set; }
        public string vacating_date { get; set; }
        public string vacating_reason { get; set; }
      
    }
}