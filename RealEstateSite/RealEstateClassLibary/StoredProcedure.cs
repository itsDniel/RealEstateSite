using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace RealEstateClassLibary
{
    class StoredProcedure
    {
        SqlCommand command = new SqlCommand();
        DBConnect connect = new DBConnect();

        public StoredProcedure() { command.CommandType = CommandType.StoredProcedure; }

        private Boolean UpdateDB()
        {
            int result = connect.DoUpdate(command);
            if (result != -1) return true;
            else return false;
        }

        public int AddHouse(String seller, String agent, String address, String status, String city,
            String propertyType, int homeSize, int bedroom, int bathroom, String amenity,
            String heatingCooling, String builtYear, String garageSize, String utility, 
            String homeDescription, int price, String image)
        {   
            command.CommandText = "AddHouse";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@seller", seller);
            command.Parameters.AddWithValue("@agent", agent);
            command.Parameters.AddWithValue("@address", address);
            command.Parameters.AddWithValue("@status", status);
            command.Parameters.AddWithValue("@city", city);
            command.Parameters.AddWithValue("@propertyType", propertyType);
            command.Parameters.AddWithValue("@homeSize", homeSize);
            command.Parameters.AddWithValue("@bedroom", bedroom);
            command.Parameters.AddWithValue("@bathroom", bathroom);
            command.Parameters.AddWithValue("@amenity", amenity);
            command.Parameters.AddWithValue("@heatingCooling", heatingCooling);
            command.Parameters.AddWithValue("@builtYear", builtYear);
            command.Parameters.AddWithValue("@garageSize", garageSize);
            command.Parameters.AddWithValue("@utility", utility);
            command.Parameters.AddWithValue("@homeDescription", homeDescription);
            command.Parameters.AddWithValue("@price", price);
            command.Parameters.AddWithValue("@image", image);
            command.Parameters.AddWithValue("@dateAdded", DateTime.Now);
            connect.DoUpdate(command);
            return int.Parse(command.Parameters["@@identity"].Value.ToString());

            //if (result != -1) return true;
            //else return false;
        }

        //for TP_AddRoom and TP_UpdateRoom
        public Boolean UpdateRoomDB(String procedure, int id, String room, int dimension)
        {   
            command.CommandText = procedure;//"TP_AddRoom";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@room", room);
            command.Parameters.AddWithValue("@dimension", dimension);
            return UpdateDB();
        }

        public Boolean UpdateHouse()
        {
            return false;
        }

        public Boolean DeleteHouse(int id)
        {   //delete all associated rooms 1st and then delete the house
            command.CommandText = "TP_DeleteAllRooms";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@id", id);
            int result = connect.DoUpdate(command);

            command.CommandText = "TP_DeleteHouse";
            result += connect.DoUpdate(command);

            if (result >= 2) return true;
            return false;
        }
        
        public Boolean DeleteRoom(int id, String room)
        {   //delete a single room
            command.CommandText = "TP_DeleteRoom";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@room", room);
            return UpdateDB();
        }
    }
}
