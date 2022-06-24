using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp.Models
{
    public class Course
    {
        public int Cid { get; set; }

        public string Cname { get; set; }
        public decimal Fees { get; set; }
    }
}
