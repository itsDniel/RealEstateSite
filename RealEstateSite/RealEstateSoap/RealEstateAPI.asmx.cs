using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Utilities;
using System.Data.SqlClient;
using RealEstateClassLibary;
using System.Data;

namespace RealEstateSoap
{
    /// <summary>
    /// Summary description for RealEstateAPI
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class RealEstateAPI : System.Web.Services.WebService
    {

        [WebMethod] //This method check if user exist in TP_Account table
        public int scalarLogin(User user)
        {
            DBConnect objDB = new DBConnect();
            StoredProceduralCommand command = new StoredProceduralCommand();
            int userCount = (int)objDB.ExecuteScalarFunction(command.checkLogin(user.Username, user.Password));
            objDB.CloseConnection();
            if(userCount > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        [WebMethod] //This method check if username already exist in TP_Account table
        public int scalarUsername(User user)
        {
            DBConnect objDB = new DBConnect();
            StoredProceduralCommand command = new StoredProceduralCommand();
            int usernameCount = (int)objDB.ExecuteScalarFunction(command.checkUsername(user.Username));
            objDB.CloseConnection();
            if(usernameCount > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        [WebMethod] //This method check if the email already exist with this given role
        public int scalarEmail(User user)
        {
            DBConnect objDB = new DBConnect();
            StoredProceduralCommand command = new StoredProceduralCommand();
            int emailCount = (int)objDB.ExecuteScalarFunction(command.checkEmail(user));
            objDB.CloseConnection();
            if(emailCount > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        [WebMethod] //This method update a new user into TP_Account table
        public void accountUpdate(User user)
        {
            DBConnect objDB = new DBConnect();
            StoredProceduralCommand command = new StoredProceduralCommand();
            objDB.DoUpdate(command.updateAccount(user));
        }

        [WebMethod] //This method retrieve dataset from TP_Account based on the email and role provided
        public DataSet getQuestion(string email, string role)
        {
            DataSet ds = new DataSet();
            DBConnect objDB = new DBConnect();
            StoredProceduralCommand command = new StoredProceduralCommand();
            ds = objDB.GetDataSet(command.getQuestion(email, role));
            return ds;
        }

        [WebMethod] //This method update a user password in TP_Account based on the provided email and role
        public void updatePassword(string email, string role, string password)
        {
            DBConnect objDB = new DBConnect();
            StoredProceduralCommand command = new StoredProceduralCommand();
            objDB.DoUpdate(command.updatePassword(email, role, password));
        }

        [WebMethod] //This method get the role of the given username
        public string getRole(string username)
        {
            DBConnect objDB = new DBConnect();
            StoredProceduralCommand command = new StoredProceduralCommand();
            DataSet ds = new DataSet();
            ds = objDB.GetDataSet(command.getRole(username));
            string role = ds.Tables[0].Rows[0][0].ToString();
            return role;
        }

        [WebMethod] //This retrieve all the houses based on the user defined search filter
        public DataSet getHouse(string location, int minPrice, int maxPrice, string property, string garage, int minSize, int maxSize, string amenity, string utility, string username)
        {
            DBConnect objDB = new DBConnect();
            StoredProceduralCommand command = new StoredProceduralCommand();
            DataSet ds = new DataSet();
            ds = objDB.GetDataSet(command.searchHome(location, minPrice, maxPrice, property, garage, minSize, maxSize, amenity, utility, username));
            return ds;
        }

        [WebMethod] // This retrieve the house based on the homeid
        public DataSet getHouseByID(string homeID)
        {
            DBConnect objDB = new DBConnect();
            StoredProceduralCommand command = new StoredProceduralCommand();
            DataSet ds = new DataSet();
            ds = objDB.GetDataSet(command.getHome(homeID));
            return ds;
        }

        [WebMethod] //This update the user visit request to TP_VisitRequest
        public void insertVisit(visitRequest request)
        {
            DBConnect objDB = new DBConnect();
            StoredProceduralCommand command = new StoredProceduralCommand();
            objDB.DoUpdate(command.addVisit(request));
        }

        [WebMethod] //This check to see if a buyer already has a visit request with this home id
        public int checkVisit(visitRequest request)
        {
            DBConnect objDB = new DBConnect();
            StoredProceduralCommand command = new StoredProceduralCommand();
            int check = (int)objDB.ExecuteScalarFunction(command.checkVisit(request));
            objDB.CloseConnection();
            return check;

        }

        [WebMethod] //This is used to get all the visit request from TP_VisitRequest table based on given buyer username
        public DataSet getVisit(string username, string status)
        {
            DBConnect objDB = new DBConnect();
            StoredProceduralCommand command = new StoredProceduralCommand();
            DataSet ds = new DataSet();
            ds = objDB.GetDataSet(command.getVisit(username, status));
            return ds;
        }

        [WebMethod] //This is used to update the visit status to visited
        public void updateVisit(string username, string status, string homeid)
        {
            DBConnect objDB = new DBConnect();
            StoredProceduralCommand command = new StoredProceduralCommand();
            objDB.DoUpdate(command.updateVisit(username, status, homeid));
        }

    }
}
