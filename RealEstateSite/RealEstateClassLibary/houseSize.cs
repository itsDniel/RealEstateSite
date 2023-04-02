using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateClassLibary
{
    public class houseSize
    {
        public static int minSize(string selected)
        {
            
            if(selected == "1")
            {
                return 0;
            }else if(selected == "2")
            {
                return 2500;
            }
            else if(selected == "3")
            {
                return 5000;
            }
            else
            {
                return 0;
            }
            
        }

        public static int maxSize(string selected)
        {
            
            if(selected == "1")
            {
                return 2500;
            }else if(selected == "2")
            {
                return 5000;
            }
            else
            {
                return int.MaxValue;
            }
            
        }
    }
}
