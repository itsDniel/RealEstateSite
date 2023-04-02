using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace RealEstateClassLibary
{
    public class StoredProceduralCommand
    {
        
        //Command to check if user exist in TP_Account table
        //Daniel
        public SqlCommand checkLogin(string username, string password)
        {
            SqlCommand command = new SqlCommand("TP_CheckLogin");
            command.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }
        
        //Command to check if username exist in TP_Account table
        //Daniel
        public SqlCommand checkUsername(string username)
        {
            SqlCommand command = new SqlCommand("TP_CheckUsername");
            command.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        public SqlCommand checkEmail(User user)
        {
            SqlCommand command = new SqlCommand("TP_CheckEmail");
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = user.Email;
            command.Parameters.Add("@role", SqlDbType.VarChar).Value = user.Role;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Command to update a user into TP_Account table
        //Daniel
        public SqlCommand updateAccount(User user)
        {
            SqlCommand command = new SqlCommand("TP_UpdateAccount");
            command.Parameters.Add("@username", SqlDbType.VarChar).Value = user.Username;
            command.Parameters.Add("@role", SqlDbType.VarChar).Value = user.Role;
            command.Parameters.Add("@fullname", SqlDbType.VarChar).Value = user.FullName;
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = user.Email;
            command.Parameters.Add("@password", SqlDbType.VarChar).Value = user.Password;
            command.Parameters.Add("@phone", SqlDbType.VarChar).Value = user.Phone;
            command.Parameters.Add("@q1", SqlDbType.VarChar).Value = user.Q1;
            command.Parameters.Add("@q2", SqlDbType.VarChar).Value = user.Q2;
            command.Parameters.Add("@q3", SqlDbType.VarChar).Value = user.Q3;
            command.Parameters.Add("@a1", SqlDbType.VarChar).Value = user.A1;
            command.Parameters.Add("@a2", SqlDbType.VarChar).Value = user.A2;
            command.Parameters.Add("@a3", SqlDbType.VarChar).Value = user.A3;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Command to retrieve dataset based on the given email and role
        //Daniel
        public SqlCommand getQuestion (string email, string role)
        {
            SqlCommand command = new SqlCommand("TP_GetQuestion");
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
            command.Parameters.Add("@role", SqlDbType.VarChar).Value = role;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Command to update a user password in TP_Account
        //Daniel
        public SqlCommand updatePassword(string email, string role, string password)
        {
            SqlCommand command = new SqlCommand("TP_UpdatePassword");
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
            command.Parameters.Add("@role", SqlDbType.VarChar).Value = role;
            command.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Command to get the role of the given username
        //Daniel
        public SqlCommand getRole(string username)
        {
            SqlCommand command = new SqlCommand("TP_GetRole");
            command.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Command to get home based on search filter
        //Daniel
        public SqlCommand searchHome(searchHouse house)
        {
            SqlCommand command = new SqlCommand("TP_SearchHouse");
            command.Parameters.Add("@location", SqlDbType.VarChar).Value = house.location;
            command.Parameters.Add("@minPrice", SqlDbType.Int).Value = house.minPrice;
            command.Parameters.Add("@maxPrice", SqlDbType.Int).Value = house.maxPrice;
            command.Parameters.Add("@property", SqlDbType.VarChar).Value = house.property;
            command.Parameters.Add("@garage", SqlDbType.VarChar).Value = house.garage;
            command.Parameters.Add("@minSize", SqlDbType.Int).Value = house.minSize;
            command.Parameters.Add("@maxSize", SqlDbType.Int).Value = house.maxSize;
            command.Parameters.Add("@amenity", SqlDbType.VarChar).Value = house.amenity;
            command.Parameters.Add("@utility", SqlDbType.VarChar).Value = house.utility;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

    }
}
