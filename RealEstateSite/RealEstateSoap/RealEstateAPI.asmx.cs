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
        DBConnect objDB = new DBConnect();
        StoredProceduralCommand command = new StoredProceduralCommand();
        StoredProcedure storedProcedure = new StoredProcedure();

        [WebMethod] //This method check if user exist in TP_Account table
        public int scalarLogin(User user)
        {
            int userCount = (int)objDB.ExecuteScalarFunction(command.checkLogin(user.Username, user.Password));
            objDB.CloseConnection();

            if(userCount > 0) return 1;
            else return 0;
        }

        [WebMethod] //This method check if username already exist in TP_Account table
        public int scalarUsername(User user)
        {
            int usernameCount = (int)objDB.ExecuteScalarFunction(command.checkUsername(user.Username));
            objDB.CloseConnection();

            if(usernameCount > 0) return 1;
            else return 0;
        }

        [WebMethod] //This method get the user fullname
        public string GetName(string username, string role)
        {
            string name = objDB.GetDataSet(command.GetName(username, role)).Tables[0].Rows[0][0].ToString();
            return name;
        }

        [WebMethod] //This method check if the email already exist with this given role
        public int scalarEmail(User user)
        {
            int emailCount = (int)objDB.ExecuteScalarFunction(command.checkEmail(user));
            objDB.CloseConnection();

            if(emailCount > 0) return 1;
            else return 0;
        }

        [WebMethod] //This method update a new user into TP_Account table
        public void accountUpdate(User user)
        {
            objDB.DoUpdate(command.updateAccount(user));
        }

        [WebMethod] //This method retrieve dataset from TP_Account based on the email and role provided
        public DataSet getQuestion(string email, string role)
        {
            DataSet ds = new DataSet();
            ds = objDB.GetDataSet(command.getQuestion(email, role));
            return ds;
        }

        [WebMethod] //This method update a user password in TP_Account based on the provided email and role
        public void updatePassword(string email, string role, string password)
        {
            objDB.DoUpdate(command.updatePassword(email, role, password));
        }

        [WebMethod] //This method get the role of the given username
        public string GetRole(string username)
        {
            return storedProcedure.GetRole(username).Tables[0].Rows[0][0].ToString(); 
        }

        [WebMethod] //This retrieve all the houses based on the user defined search filter
        public DataSet getHouse(string location, int minPrice, int maxPrice, string property, string garage, int minSize, int maxSize, string amenity, string utility, string username)
        {
            DataSet ds = new DataSet();
            ds = objDB.GetDataSet(command.searchHome(location, minPrice, maxPrice, property, garage, minSize, maxSize, amenity, utility, username));
            return ds;
        }

        [WebMethod] // This retrieve the house based on the homeid
        public DataSet getHouseByID(string homeID)
        {
            DataSet ds = new DataSet();
            ds = objDB.GetDataSet(command.getHome(homeID));
            return ds;
        }

        [WebMethod] //This update the user visit request to TP_VisitRequest
        public void insertVisit(visitRequest request)
        {
            objDB.DoUpdate(command.addVisit(request));
        }

        [WebMethod] //This check to see if a buyer already has a visit request with this home id
        public int checkVisit(visitRequest request)
        {
            int check = (int)objDB.ExecuteScalarFunction(command.checkVisit(request));
            objDB.CloseConnection();
            return check;

        }

        [WebMethod] //This is used to get all the visit request from TP_VisitRequest table based on given buyer username
        public DataSet getVisit(string username, string status)
        {
            DataSet ds = new DataSet();
            ds = objDB.GetDataSet(command.getVisit(username, status));
            return ds;
        }

        [WebMethod] //This is used to delete visit request
        public void DeleteVisit(visitRequest request)
        {
            objDB.DoUpdate(command.DeleteVisit(request));
        }

        [WebMethod] //This is used to update the visit status to visited
        public void updateVisit(string username, string status, string homeid)
        {
            objDB.DoUpdate(command.updateVisit(username, status, homeid));
        }

        [WebMethod] //This is used to get all the home that the buyer have visited
        public DataSet getVisited(string username, string status)
        {
            DataSet ds = new DataSet();
            ds = objDB.GetDataSet(command.getVisited(username, status));
            return ds;
        }

        [WebMethod] //This update feedback to TP_Feedback table
        public void addFeedback(int homeid, string buyer, string buyername, string a1, string a2, string a3, string a4)
        {
            objDB.DoUpdate(command.addFeedback(homeid, buyer, buyername, a1, a2, a3, a4));
        }

        [WebMethod] //This get all the homes that the buyer left the feedback on
        public DataSet getFeedbacked(string buyer, string status)
        {
            DataSet ds = new DataSet();
            ds = objDB.GetDataSet(command.getFeedbacked(buyer, status));
            return ds;
        }

        [WebMethod] //This check if user already have a feedback
        public int CheckFeedback(string username, int id)
        {
            int count = (int)objDB.ExecuteScalarFunction(command.CheckFeedback(username, id));
            objDB.CloseConnection();
            return count;
        }

        [WebMethod] //This add the buyer offer to the TP_Offer table
        public void addOffer(OfferBuyer offer)
        {
            objDB.DoUpdate(command.addOffer(offer));
        }

        [WebMethod] //This gets offer based on status and username
        public DataSet GetOffer(string username, string status)
        {
            DataSet ds = new DataSet();
            ds = objDB.GetDataSet(command.GetOffer(username, status));
            return ds;
        }

        [WebMethod] //This update the status in TP_Feedback
        public void updateFeedback(int homeid, string buyer, string status)
        {
            objDB.DoUpdate(command.updateFeedback(buyer, status, homeid));
        }

        [WebMethod] //This get the count of notification for buyer
        public int GetBuyerNoti(string username, string status, int buyerstatus)
        {
            int count = (int)objDB.ExecuteScalarFunction(command.GetBuyerNoti(username, status, buyerstatus));
            objDB.CloseConnection();
            return count;
        }

        [WebMethod] //This update the buyer notification view status
        public void UpdateBuyerNoti(string username, string status, int buyerstatus)
        {
            objDB.DoUpdate(command.UpdateBuyerNoti(username, status, buyerstatus));
        }

        [WebMethod] //This get the count of notification for seller
        public int GetSellerNoti(string username, string status, int sellerstatus)
        {
            int count = (int)objDB.ExecuteScalarFunction(command.GetSellerNoti(username, status, sellerstatus));
            objDB.CloseConnection();
            return count;
        }

        [WebMethod] //This update the buyer notification view status
        public void UpdateSellerNoti(string username, string status, int sellerstatus)
        {
            objDB.DoUpdate(command.UpdateSellerNoti(username, status, sellerstatus));
        }

        [WebMethod] //This gets the room dimension data
        public DataSet GetRooms(int id)
        {
            DataSet ds = new DataSet();
            ds = objDB.GetDataSet(command.GetRoom(id));
            return ds;
        }

        [WebMethod] //This gets all feedback for seller
        public DataSet GetFeedbackSeller(string username)
        {
            DataSet ds = new DataSet();
            ds = objDB.GetDataSet(command.GetFeedbackSeller(username));
            return ds;
        }

        [WebMethod] //This gets all offer for seller
        public DataSet GetOfferSeller(string username, string status)
        {
            DataSet ds = new DataSet();
            ds = objDB.GetDataSet(command.GetOfferSeller(username, status));
            return ds;
        }

        [WebMethod] //This let seller update offer status
        public void SellerUpdateOffer(int id, string username, string status)
        {
            objDB.DoUpdate(command.SellerUpdateOffer(id, username, status));
        }

        [WebMethod] //This update the home table with new home owner
        public void UpdateHomeOwnere(int id, string username, string status)
        {
            objDB.DoUpdate(command.UpdateHomeOwner(id, username, status));
        }

        [WebMethod] //This gets seller offer based on buyer username and homeid
        public DataSet GetOfferSellerById(string username, int id)
        {
            DataSet ds = new DataSet();
            ds = objDB.GetDataSet(command.GetOfferSellerById(username, id));
            return ds;
        }

        [WebMethod] //This check if user already leave an offer
        public int CheckOffer(string username, int id, string status)
        {
            int count = (int)objDB.ExecuteScalarFunction(command.CheckOffer(username, id, status));
            objDB.CloseConnection();
            return count;
        }

        [WebMethod] //This gets all visit request for seller
        public DataSet GetVisitSeller(string username)
        {
            DataSet ds = new DataSet();
            ds = objDB.GetDataSet(command.GetVisitSeller(username));
            return ds;
        }



    }
}
