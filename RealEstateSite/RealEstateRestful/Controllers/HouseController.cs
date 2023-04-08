using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealEstateClassLibary;

namespace RealEstateRestful.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class HouseController : Controller//Base
    {
        StoredProcedure storedProcedure = new StoredProcedure();

        [HttpPost] //http://localhost:28769/api/house
        public int AddHouse([FromBody] House house)
        {   //add a record to the TP_Home table and return the id of the record
            return storedProcedure.AddHouse(house.Seller, house.Agent, house.Address, 
                house.Status, house.City, house.PropertyType, house.HomeSize, house.Bedroom, 
                house.Bathroom, house.Amenity, house.HeatingCooling, house.BuiltYear, 
                house.GarageSize, house.Utility, house.HomeDescription, house.Price, house.Image);
        }

        [HttpPost]
        public void AddRoom(List<House> houses)
        {

        }
    }
}
