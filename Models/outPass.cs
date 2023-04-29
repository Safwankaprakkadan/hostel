using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hostel.Models
{
    public class outPass
    {
        public long id { get; set; }
        public long reg_no { get; set; }
        public string hosteler_name { get; set; }
        public long Contact_no { get; set; }
        public string date_of_outpass { get; set; }
        public string time_of_departure { get; set; }
        public string return_time { get; set; }
        public string reason_outpass { get; set; }
    }
}