using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateClassLibary
{
    public class houseSize
    {
        public static int minSize(int a)
        {
            int min;
            if(a == 1 || a == 0)
            {
                min = 0;
            }else if(a == 2)
            {
                min = 2500;
            }
            else
            {
                min = 5000;
            }
            return min;
        }

        public static int maxSize(int a)
        {
            int max;
            if(a == 1)
            {
                max = 2500;
            }else if(a == 2)
            {
                max = 5000;
            }
            else
            {
                max = int.MaxValue;
            }
            return max;
        }
    }
}
