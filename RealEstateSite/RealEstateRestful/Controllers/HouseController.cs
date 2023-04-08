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

        [HttpPost]
        public void AddHouse([FromBody] House house)
        {
            int id = storedProcedure.AddHouse(house.Seller, house.Agent, house.Address, 
                house.Status, house.City, house.PropertyType, house.HomeSize, house.Bedroom, 
                house.Bathroom, house.Amenity, house.HeatingCooling, house.BuiltYear, 
                house.GarageSize, house.Utility, house.HomeDescription, house.Price, house.Image);

            //storedProcedure.ModifyRoomDB("TP_AddRoom", id, );
            //return true;
        }

    }
}
