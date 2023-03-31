using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateClassLibary
{
    public class TwoFactorPinGenerator
    {
        public static int RNG()
        {
            Random rnd = new Random();
            int num = rnd.Next(100000, 1000000);
            return num;
        }

        public static int questionGenerator()
        {
            Random rnd = new Random();
            int num = rnd.Next(1, 4);
            return num;
        }
    }
}
