using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateClassLibary
{
    public class searchHouse
    {
        public string location { get; set; }
        public int minPrice { get; set; }
        public int maxPrice { get; set; }
        public string property { get; set; }
        public string garage { get; set; }
        public int minSize { get; set; }
        public int maxSize { get; set; }
        public string amenity { get; set; }
        public string utility { get; set; }
    }
}
