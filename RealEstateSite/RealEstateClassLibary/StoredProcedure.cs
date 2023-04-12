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
    public class StoredProcedure
    {
        SqlCommand command = new SqlCommand();
        DBConnect connect = new DBConnect();

        public StoredProcedure() { command.CommandType = CommandType.StoredProcedure; }

        private void SetCommandTextAndClearParam(String procedure)
        {
            command.CommandText = procedure;
            command.Parameters.Clear();
        }

        private Boolean UpdateDB()
        {
            int result = connect.DoUpdate(command);
            if (result != -1) return true;
            else return false;
        }

        private void AddHouseParams(String seller, String agent, String address, String status, String city,
            String propertyType, int homeSize, int bedroom, int bathroom, String amenity,
            String heatingCooling, String builtYear, String garageSize, String utility,
            String homeDescription, int price, String image)
        {
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
        }

        public int AddHouse(House house)
            //String seller, String agent, String address, String status, String city,
            //String propertyType, int homeSize, int bedroom, int bathroom, String amenity,
            //String heatingCooling, String builtYear, String garageSize, String utility,
            //String homeDescription, int price, String image)
        {
            SetCommandTextAndClearParam("TP_AddHouse");
            AddHouseParams(house.Seller, house.Agent, house.Address, house.Status, house.City, house.PropertyType,
                house.HomeSize, house.Bedroom, house.Bathroom, house.Amenity, house.HeatingCooling, house.BuiltYear,
                house.GarageSize, house.Utility, house.HomeDescription, house.Price, house.Image);
                //seller, agent, address, status, city, propertyType, homeSize, bedroom, bathroom,
                //amenity, heatingCooling, builtYear, garageSize, utility, homeDescription, price, image);
            command.Parameters.AddWithValue("@dateAdded", DateTime.Now);
            command.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
            connect.DoUpdate(command);

            //return the id of the house so that TP_AddRoom can use it
            return int.Parse(command.Parameters["@id"].Value.ToString()); //NULL??????????
        }

        public Boolean UpdateHouse(House house)//String seller, String agent, String address, String status, String city,
            //String propertyType, int homeSize, int bedroom, int bathroom, String amenity,
            //String heatingCooling, String builtYear, String garageSize, String utility,
            //String homeDescription, int price, String image)
        {
            SetCommandTextAndClearParam("TP_UpdateHouse");
            command.Parameters.AddWithValue("@id", house.Id);
            AddHouseParams(house.Seller, house.Agent, house.Address, house.Status, house.City, house.PropertyType,
                house.HomeSize, house.Bedroom, house.Bathroom, house.Amenity, house.HeatingCooling, house.BuiltYear,
                house.GarageSize, house.Utility, house.HomeDescription, house.Price, house.Image);
                //seller, agent, address, status, city, propertyType, homeSize, bedroom, bathroom,
                //amenity, heatingCooling, builtYear, garageSize, utility, homeDescription, price, image);
            return UpdateDB();
        }

        public Boolean ModifyRoomDB(String procedure, int id, String room, int width, int length)
        {   //for TP_AddRoom and TP_UpdateRoom
            SetCommandTextAndClearParam(procedure);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@room", room);
            command.Parameters.AddWithValue("@width", width);
            command.Parameters.AddWithValue("@length", length);
            return UpdateDB();
        }

        public Boolean DeleteHouse(int id)
        {   //delete all associated rooms 1st and then delete the house
            SetCommandTextAndClearParam("TP_DeleteAllRooms");
            command.Parameters.AddWithValue("@id", id);
            int result = connect.DoUpdate(command);

            command.CommandText = "TP_DeleteHouse";
            result += connect.DoUpdate(command);

            if (result >= 2) return true;
            return false;
        }

        public Boolean DeleteRoom(int id, String room)
        {   //delete a single room
            SetCommandTextAndClearParam("TP_DeleteRoom");
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@room", room);
            return UpdateDB();
        }

        public DataSet GetHouses(String procedure, String param, String value)
        {   //for TP_GetHouseBySeller (@seller) and TP_GetHouseByAgent (@agent)
            SetCommandTextAndClearParam(procedure);
            command.Parameters.AddWithValue(param, value);
            return connect.GetDataSet(command);
        }

        public DataSet GetRooms(int id)
        {
            SetCommandTextAndClearParam("TP_GetRooms");
            command.Parameters.AddWithValue("@id", id);
            return connect.GetDataSet(command);
        }
    }
}
