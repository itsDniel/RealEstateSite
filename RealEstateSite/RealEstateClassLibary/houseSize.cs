using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateClassLibary
{
    public class HouseSize
    {
        public int Id { get; set; }
        public int Bedroom { get; set; }
        public int Bathroom { get; set; }
        public String HomeSize { get; set; }

        public static int MinSize(string selected)
        {
            if(selected == "1") return 0;
            else if(selected == "2") return 2500;
            else if(selected == "3") return 5000;
            else return 0;
        }

        public static int MaxSize(string selected)
        {
            if(selected == "1") return 2500;
            else if(selected == "2") return 5000;
            else return int.MaxValue;
        }
    }
}
