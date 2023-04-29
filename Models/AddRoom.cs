using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hostel.Models
{
    public class AddRoom
    {
        public long id { get; set; }
        public long Room_number { get; set; }
        public string Block_name { get; set; }
        public string Floor { get; set; }
        public long Total_space { get; set; }
        public long Available_space { get; set; }
        
    }
}