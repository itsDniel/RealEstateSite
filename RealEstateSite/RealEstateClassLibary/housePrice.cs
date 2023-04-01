using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateClassLibary
{
    public class housePrice
    {
        public static int minPrice(int a)
        {
            int min;
            if(a == 1 || a == 0)
            {
                min = 0;
            }else if(a == 2)
            {
                min = 100000;
            }
            else
            {
                min = 300000;
            }
            return min;
            
        }

        public static int maxPrice(int a)
        {
            int max;
            if(a == 1)
            {
                max = 100000;
            }
            else if(a == 2)
            {
                max = 300000;
            }
            else
            {
                max = int.MaxValue;
            }

            return max;
        }
            
    }
}
