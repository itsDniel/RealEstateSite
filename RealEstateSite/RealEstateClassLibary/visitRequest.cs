using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateClassLibary
{
    public class visitRequest
    {
        public int homeid { get; set; }
        public string buyer { get; set; }
        public string buyerName { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string status { get; set; }
    }
}
