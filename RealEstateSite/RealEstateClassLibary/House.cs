using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateClassLibary
{
    public class House
    {
        public House() { }
        public String Seller { get; set; }
        public String Agent { get; set; }
        public String Homebuyer { get; set; }
        public String Address { get; set; }
        public String Status { get; set; }
        public String City { get; set; }
        public String PropertyType { get; set; }
        public int HomeSize { get; set; }   //Square footage
        public int Bedroom { get; set; }    //# of bedrooms
        public int Bathroom { get; set; }   //# of bathrooms
        public String Amenity { get; set; }
        public String HeatingCooling { get; set; }
        public String BuiltYear { get; set; }
        public String GarageSize { get; set; }
        public String Utility { get; set; }
        public String HomeDescription { get; set; }
        public int Price { get; set; }
        public String Image { get; set; }

    }
}
