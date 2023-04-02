using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateClassLibary
{
    public class housePrice
    {
        public static int minPrice(string selected)
        {
            
            if(selected == "1")
            {
                return 0;
            }else if(selected == "2")
            {
                return 100000;
            }
            else if(selected == "3")
            {
                return 300000;
            }
            else
            {
                return 0;
            }

            
            
        }

        public static int maxPrice(string selected)
        {
            
            if(selected == "1")
            {
                return 100000;
            }
            else if(selected == "2")
            {
                return 300000;
            }
            else
            {
                return int.MaxValue;
            }

            
        }
            
    }
}
