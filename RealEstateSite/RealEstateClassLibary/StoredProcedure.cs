﻿using System;
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

        //this method is used for both updating and adding house
        private void AddHouseParams(String seller, String agent, String address, String city, String propertyType,
            String amenity, String heatingCooling, String builtYear, String garageSize, String utility,
            String homeDescription, int price)
        {
            command.Parameters.AddWithValue("@seller", seller);
            command.Parameters.AddWithValue("@agent", agent);
            command.Parameters.AddWithValue("@address", address);
            command.Parameters.AddWithValue("@city", city);
            command.Parameters.AddWithValue("@propertyType", propertyType);
            command.Parameters.AddWithValue("@amenity", amenity);
            command.Parameters.AddWithValue("@heatingCooling", heatingCooling);
            command.Parameters.AddWithValue("@builtYear", builtYear);
            command.Parameters.AddWithValue("@garageSize", garageSize);
            command.Parameters.AddWithValue("@utility", utility);
            command.Parameters.AddWithValue("@homeDescription", homeDescription);
            command.Parameters.AddWithValue("@price", price);
            //command.Parameters.AddWithValue("@image", image);
        }

        public Boolean AddHouse(House house)
        {
            SetCommandTextAndClearParam("TP_AddHouse");
            AddHouseParams(house.Seller, house.Agent, house.Address, house.City, house.PropertyType,
                house.Amenity, house.HeatingCooling, house.BuiltYear, house.GarageSize, house.Utility,
                house.HomeDescription, house.Price);
            command.Parameters.AddWithValue("@status", house.Status);
            command.Parameters.AddWithValue("@dateAdded", DateTime.Now);
            command.Parameters.AddWithValue("@image", house.Image);
            return UpdateDB();
        }

        public Boolean UpdateHouse(House house)
        {
            SetCommandTextAndClearParam("TP_UpdateHouse");
            command.Parameters.AddWithValue("@id", house.Id);
            AddHouseParams(house.Seller, house.Agent, house.Address, house.City, house.PropertyType,
                house.Amenity, house.HeatingCooling, house.BuiltYear, house.GarageSize, house.Utility,
                house.HomeDescription, house.Price);
            return UpdateDB();
        }

        public Boolean UpdateImage(House house)
        {
            SetCommandTextAndClearParam("TP_UpdateImage");
            command.Parameters.AddWithValue("@id", house.Id);
            command.Parameters.AddWithValue("@img", house.Image);
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

        public List<House> GetHouses(String procedure, String param, String value)
        {   //for TP_GetHouseBySeller (@seller) and TP_GetHouseByAgent (@agent)
            SetCommandTextAndClearParam(procedure);
            command.Parameters.AddWithValue(param, value);
            DataTable houseTable = connect.GetDataSet(command).Tables[0]; //execute the stored procedure and get the data
            List<House> houses = new List<House>();

            foreach (DataRow row in houseTable.Rows)
            {
                House house = new House();
                house.Id = int.Parse(row["HomeID"].ToString());
                house.Seller = row["Seller"].ToString();
                house.Agent = row["Agent"].ToString();
                house.Homebuyer = row["Homebuyer"].ToString();
                house.Address = row["Address"].ToString();
                house.Status = row["Status"].ToString();
                house.City = row["City"].ToString();
                house.PropertyType = row["PropertyType"].ToString();
                house.HomeSize = row["HomeSize"].ToString();
                house.Bedroom = int.Parse(row["Bedroom"].ToString());
                house.Bathroom = int.Parse(row["Bathroom"].ToString());
                house.Amenity = row["Amenity"].ToString();
                house.HeatingCooling = row["Heating/Cooling"].ToString();
                house.BuiltYear = row["BuiltYear"].ToString();
                house.Utility = row["Utility"].ToString();
                house.HomeDescription = row["HomeDescription"].ToString();
                house.GarageSize = row["GarageSize"].ToString();
                house.Price = int.Parse(row["Price"].ToString());
                house.Image = row["Image"].ToString();
                house.FullName = row["FullName"].ToString();
                house.PhoneNumber = row["Phone"].ToString();
                house.Email = row["Email"].ToString();
                houses.Add(house);
            }

            return houses;
        }

        public List<Room> GetRooms(int id)
        {
            SetCommandTextAndClearParam("TP_GetRooms");
            command.Parameters.AddWithValue("@id", id);
            DataTable roomTable = connect.GetDataSet(command).Tables[0];
            List<Room> rooms = new List<Room>();

            foreach (DataRow row in roomTable.Rows)
            {
                Room room = new Room();
                room.Id = int.Parse(row["HomeID"].ToString());
                room.RoomName = row["Room"].ToString();
                room.Width = int.Parse(row["Width"].ToString());
                room.Length = int.Parse(row["Length"].ToString());
                rooms.Add(room);
            }
            return rooms;
        }

        public DataSet GetRole(String user)
        {   //used in SOAP
            SetCommandTextAndClearParam("TP_GetRole");
            command.Parameters.AddWithValue("@username", user);
            return connect.GetDataSet(command);
        }

        public Boolean UpdateHomeSizeInfo(HouseSize houseSize)
        {
            SetCommandTextAndClearParam("TP_UpdateHomeSizeInfo");
            command.Parameters.AddWithValue("@id", houseSize.Id);
            command.Parameters.AddWithValue("@bedroom", houseSize.Bedroom);
            command.Parameters.AddWithValue("@bathroom", houseSize.Bathroom);
            command.Parameters.AddWithValue("@homeSize", houseSize.HomeSize);
            return UpdateDB();
        }

        public DataTable GetDistinctCities()
        {
            SetCommandTextAndClearParam("TP_GetDistinctCities");
            return connect.GetDataSet(command).Tables[0];
        }
    }
}