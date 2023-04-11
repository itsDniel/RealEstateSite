using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealEstateClassLibary;
using System.Data;

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
            return storedProcedure.AddHouse(house);//house.Seller, house.Agent, house.Address, 
                                                   //house.Status, house.City, house.PropertyType, house.HomeSize, house.Bedroom, 
                                                   //house.Bathroom, house.Amenity, house.HeatingCooling, house.BuiltYear, 
                                                   //house.GarageSize, house.Utility, house.HomeDescription, house.Price, house.Image);
        }

        [HttpPost]
        public Boolean AddRoom([FromBody] List<Room> rooms)
        {
            int result = 0;
            foreach (Room room in rooms)
            {
                bool added = storedProcedure.ModifyRoomDB("TP_AddRoom", room.Id, room.RoomName, room.Width, room.Length);
                if (added) result++;
            }
            if (result == rooms.Count) return true;
            else return false;
        }

        [HttpPut]
        public Boolean UpdateHouse([FromBody] House house)
        {
            return storedProcedure.UpdateHouse(house);
        }

        [HttpPut]
        public Boolean UpdateRoom([FromBody] Room room)
        {
            return storedProcedure.ModifyRoomDB("TP_UpdateRoom", room.Id, room.RoomName, room.Width, room.Length);
        }

        [HttpDelete]
        public Boolean DeleteHouse(int id)
        {
            return storedProcedure.DeleteHouse(id);
        }

        [HttpDelete]
        public Boolean DeleteRoom(int id, String roomName)
        {
            return storedProcedure.DeleteRoom(id, roomName);
        }
        
        [HttpGet("GetHouseBySeller")]
        public DataSet GetHouseBySeller(String username)
        {
            return storedProcedure.GetHouses("TP_GetHouseBySeller", "@seller", username);
        }

        [HttpGet("GetHouseByAgent")]
        public DataSet GetHouseByAgent(String username)
        {
            return storedProcedure.GetHouses("TP_GetHouseByAgent", "@agent", username);
        }

        public DataSet GetRooms(int id)
        {
            return storedProcedure.GetRooms(id);
        }
    }
}
