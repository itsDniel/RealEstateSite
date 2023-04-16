using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateSite
{
    public partial class HouseProfile : System.Web.UI.Page
    {
        RealEstateSoap.RealEstateAPI pxy = new RealEstateSoap.RealEstateAPI();

        protected void Page_Load(object sender, EventArgs e)
        {
            //grab data from DB 
            //for each record of house, create a house profile control, which includes
            //home id label (hidden), picture box, house control, and dynamically added room controls
            //-pass in data that the house profile control will need
            //-house dataset for house control and home id label (databind)
            //-room dataset for room control to update and delete (databind)

            if (Request.Cookies["Username"] == null) Response.Redirect("RealEstateLogin.aspx");
            else
            {   // Create an HTTP Web Request and get the HTTP Web Response from the server.
                //WebRequest request = WebRequest.Create("http://localhost:28769/api/house/");
                //WebResponse response = request.GetResponse();

                //// Read the data from the Web Response, which requires working with streams.
                //Stream theDataStream = response.GetResponseStream();
                //StreamReader reader = new StreamReader(theDataStream);
                //String data = reader.ReadToEnd();
                //reader.Close();
                //response.Close();

                //// Deserialize a JSON string that contains an array of JSON objects into an Array of Team objects.
                //JavaScriptSerializer js = new JavaScriptSerializer();
                //Team[] teams = js.Deserialize<Team[]>(data);
                //gvTeams.DataSource = teams;
                //gvTeams.DataBind();
            }
        }
    }
}