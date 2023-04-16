using RealEstateClassLibary;
using System;
using System.Collections.Generic;
using System.Data;
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

        private void DisplayHouses(String url)
        {   //create a web request and get the response
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();

            // Read the data from the Web Response, which requires working with streams.
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            JavaScriptSerializer js = new JavaScriptSerializer();
            List<House> houseList = js.Deserialize<List<House>>(data); 
            if(houseList != null)
            {
                foreach (House house in houseList)
                {
                    HouseProfileCtrl hpc = (HouseProfileCtrl)LoadControl("HouseProfileCtrl.ascx");
                    HouseControl hc = hpc.HouseCtrl;

                    hpc.Id = house.Id.ToString();
                    hpc.Status = house.Status;
                    hpc.Buyer = house.Homebuyer;
                    hc.Seller = house.Seller;
                    hc.Agent = house.Agent;
                    hc.City = house.City;
                    hc.Address = house.Address;
                    hc.PropertyType = house.PropertyType;
                    hpc.HomeSize = house.HomeSize;
                    hpc.Bedroom = house.Bedroom.ToString();
                    hpc.Bathroom = house.Bathroom.ToString();
                    hc.Amenities = house.Amenity;
                    hc.HeatingCooling = house.HeatingCooling;
                    hc.BuiltYear = house.BuiltYear;
                    hc.GarageSize = house.GarageSize;
                    hc.Utility = house.Utility;
                    hc.Description = house.HomeDescription;
                    hc.Price = house.Price.ToString();
                    hpc.Img = house.Image;
                    houseContainer.Controls.Add(hpc);
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //for each record of house, create a house profile control, which includes
            //home id label (hidden), picture box, house control, and dynamically added room controls
            //-pass in data that the house profile control will need
            //-house dataset for house control and home id label (databind)
            //-room dataset for room control to update and delete (databind)

            if (Request.Cookies["Username"] == null) Response.Redirect("RealEstateLogin.aspx");
            else
            {
                //if(!IsPostBack)
                //{
                    String username = Request.Cookies["Username"].Value;
                    String url = "http://localhost:28769/api/house/";

                    if (pxy.GetRole(username).Equals("Seller")) 
                        DisplayHouses(url + "GetHouseBySeller/" + username); 
                    else DisplayHouses(url + "GetHouseByAgent/" + username);
                //}
            }
        }
    }
}