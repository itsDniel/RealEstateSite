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
    [Route("api/[controller]")] //http://localhost:28769/api/house
    //[ApiController]
    public class HouseController : Controller//Base
    {
        StoredProcedure storedProcedure = new StoredProcedure();

        [HttpPost("AddHouse")] //api/house/addhouse
        public int AddHouse([FromBody] House house)
        {   //add a record to the TP_Home table and return the id of the record
            return storedProcedure.AddHouse(house);
        }

        [HttpPost("AddRoom")]
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

        [HttpPut("UpdateHouse")]
        public Boolean UpdateHouse([FromBody]House house)
        {
            return storedProcedure.UpdateHouse(house);
        }

        [HttpPut]
        public Boolean UpdateRoom([FromBody] Room room)
        {
            return storedProcedure.ModifyRoomDB("TP_UpdateRoom", room.Id, room.RoomName, room.Width, room.Length);
        }

        [HttpDelete("DeleteHouse/{id}")]            //api/house/13
        public Boolean DeleteHouse(int id)
        {
            return storedProcedure.DeleteHouse(id);
        }

        [HttpDelete("DeleteRoom/{id}/{roomName}")]  //api/house/13/kitchen
        public Boolean DeleteRoom(int id, String roomName)
        {
            return storedProcedure.DeleteRoom(id, roomName);
        }
        
        [HttpGet("GetHouseBySeller/{username}")]    //api/house/GetHouseBySeller/jenny
        public DataSet GetHouseBySeller(String username)
        {
            return storedProcedure.GetHouses("TP_GetHouseBySeller", "@seller", username);
        }

        [HttpGet("GetHouseByAgent/{username}")]     //api/house/GetHouseByAgent/jenny
        public DataSet GetHouseByAgent(String username)
        {
            return storedProcedure.GetHouses("TP_GetHouseByAgent", "@agent", username);
        }

        [HttpGet("GetRooms/{id}")]                  //api/house/GetRooms
        public DataSet GetRooms(int id)
        {
            return storedProcedure.GetRooms(id);
        }
    }
}
