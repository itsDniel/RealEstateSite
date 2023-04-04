using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

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
        public SqlCommand searchHome(string location, int minPrice, int maxPrice, string property, string garage, int minSize, int maxSize, string amenity, string utility, string username)
        {
            SqlCommand command = new SqlCommand("TP_SearchHouse");
            command.Parameters.Add("@location", SqlDbType.VarChar).Value = location;
            command.Parameters.Add("@minPrice", SqlDbType.Int).Value = minPrice;
            command.Parameters.Add("@maxPrice", SqlDbType.Int).Value = maxPrice;
            command.Parameters.Add("@property", SqlDbType.VarChar).Value = property;
            command.Parameters.Add("@garage", SqlDbType.VarChar).Value = garage;
            command.Parameters.Add("@minSize", SqlDbType.Int).Value = minSize;
            command.Parameters.Add("@maxSize", SqlDbType.Int).Value = maxSize;
            command.Parameters.Add("@amenity", SqlDbType.VarChar).Value = amenity;
            command.Parameters.Add("@utility", SqlDbType.VarChar).Value = utility;
            command.Parameters.Add("@buyer", SqlDbType.VarChar).Value = username;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Command to get house based on given homeid
        public SqlCommand getHome(string homeid)
        {
            SqlCommand command = new SqlCommand("TP_GetHouse");
            command.Parameters.Add("@homeid", SqlDbType.VarChar).Value = homeid;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Command to add a user visit request to database
        public SqlCommand addVisit(visitRequest request)
        {
            SqlCommand command = new SqlCommand("TP_AddVisitRequest");
            command.Parameters.Add("@homeid", SqlDbType.Int).Value = request.homeid;
            command.Parameters.Add("@buyer", SqlDbType.VarChar).Value = request.buyer;
            command.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Parse(request.date);
            command.Parameters.Add("@time", SqlDbType.DateTime).Value = DateTime.Parse(request.time);
            command.Parameters.Add("@status", SqlDbType.VarChar).Value = request.status;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Command to check if a buyer already has a visit request with this house
        public SqlCommand checkVisit(visitRequest request)
        {
            SqlCommand command = new SqlCommand("TP_CheckVisit");
            command.Parameters.Add("@homeid", SqlDbType.Int).Value = request.homeid;
            command.Parameters.Add("@buyer", SqlDbType.VarChar).Value = request.buyer;
            command.Parameters.Add("@status", SqlDbType.VarChar).Value = request.status;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Command to get all the visit request
        public SqlCommand getVisit(string username, string status)
        {
            SqlCommand command = new SqlCommand("TP_GetVisit");
            command.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@status", SqlDbType.VarChar).Value = status;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Command to update the visit status to visited
        public SqlCommand updateVisit(string username, string status, string homeid)
        {
            SqlCommand command = new SqlCommand("TP_updateVisit");
            command.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@homeid", SqlDbType.VarChar).Value = homeid;
            command.Parameters.Add("@status", SqlDbType.VarChar).Value = status;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Command to get all the house that the buyer have visited
        public SqlCommand getVisited(string username, string status)
        {
            SqlCommand command = new SqlCommand("TP_GetVisitedHome");
            command.Parameters.Add("@buyer", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@status", SqlDbType.VarChar).Value = status;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //This command update feedback to TP_Feedback
        public SqlCommand addFeedback(int homeid, string buyer, string a1, string a2, string a3, string a4)
        {
            SqlCommand command = new SqlCommand("TP_AddFeedback");
            command.Parameters.Add("@homeid", SqlDbType.Int).Value = homeid;
            command.Parameters.Add("@buyer", SqlDbType.VarChar).Value = buyer;
            command.Parameters.Add("@a1", SqlDbType.VarChar).Value = a1;
            command.Parameters.Add("@a2", SqlDbType.VarChar).Value = a2;
            command.Parameters.Add("@a3", SqlDbType.VarChar).Value = a3;
            command.Parameters.Add("@a4", SqlDbType.VarChar).Value = a4;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //This command retrieve all home that the user have left a feedback on
        public SqlCommand getFeedbacked(string username, string status)
        {
            SqlCommand command = new SqlCommand("TP_GetFeedbackedHome");
            command.Parameters.Add("@buyer", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@status", SqlDbType.VarChar).Value = status;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //This command add offer to TP_Offer
        public SqlCommand addOffer(int homeid, string buyer, int a1, string a2, string a3, string status)
        {
            SqlCommand command = new SqlCommand("TP_AddOffer");
            command.Parameters.Add("@homeid", SqlDbType.Int).Value = homeid;
            command.Parameters.Add("@buyer", SqlDbType.VarChar).Value = buyer;
            command.Parameters.Add("@a1", SqlDbType.Int).Value = a1;
            command.Parameters.Add("@a2", SqlDbType.VarChar).Value = a2;
            command.Parameters.Add("@a3", SqlDbType.VarChar).Value = a3;
            command.Parameters.Add("@status", SqlDbType.VarChar).Value = status;
            command.CommandType = CommandType.StoredProcedure;
            return command;

        }

        //Command to update the offer status to TP_Feedback
        public SqlCommand updateFeedback(string username, string status, int homeid)
        {
            SqlCommand command = new SqlCommand("TP_UpdateOffer");
            command.Parameters.Add("@buyer", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@homeid", SqlDbType.Int).Value = homeid;
            command.Parameters.Add("@status", SqlDbType.VarChar).Value = status;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }
    }
}
