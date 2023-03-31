using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Utilities;
using System.Data.SqlClient;
using RealEstateClassLibary;

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
    }
}
