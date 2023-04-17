using RealEstateClassLibary;
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
    public partial class AddHouse : System.Web.UI.Page
    {
        const String ADD_HOUSE_DIRECTION = "Fill out the following form to add a house.";
        RealEstateSoap.RealEstateAPI pxy = new RealEstateSoap.RealEstateAPI();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["Username"] == null) Response.Redirect("RealEstateLogin.aspx");
            else
            {
                if(!IsPostBack)
                {
                    lblInstruction.Text = ADD_HOUSE_DIRECTION;
                    String user = Request.Cookies["Username"].Value;
                    
                    //prefill seller or agent textbox according to the role
                    if (pxy.GetRole(user).Equals("Seller")) hc.Seller = user;
                    else hc.Agent = user;
                }
            }
        }

        protected void btnAddHouse_Click(object sender, EventArgs e)
        {
            if(hc.Seller.Trim().Equals("") || hc.Agent.Trim().Equals("") || hc.Address.Trim().Equals("") ||
               hc.City.Trim().Equals("") || hc.BuiltYear.Trim().Equals("") || hc.Price.Trim().Equals("") ||
               hc.Description.Trim().Equals("") || !hc.ImgFileUpload.HasFile)
            {
                lblInstruction.Text = "Missing Info: please fill out all the textboxes and upload an image file.";
            }
            else if(int.Parse(hc.Price) <= 0 || int.Parse(hc.BuiltYear) <= 0)
            {
                lblInstruction.Text = "Negative number or 0 is NOT allowed for the price and built year.";
            }
            else
            {
                House house = new House();
                house.Seller = hc.Seller;
                house.Agent = hc.Agent;
                house.Address = hc.Address;
                house.Status = "Listing";
                house.City = hc.City;
                house.PropertyType = hc.PropertyType;
                house.HomeSize = "0";
                house.Bedroom = 0;
                house.Bathroom = 0;
                house.Amenity = hc.Amenities;
                house.HeatingCooling = hc.HeatingCooling;
                house.BuiltYear = hc.BuiltYear;
                house.GarageSize = hc.GarageSize;
                house.Utility = hc.Utility;
                house.HomeDescription = hc.Description;
                house.Price = int.Parse(hc.Price);
                house.Image = hc.ImgFileUpload.FileName; //how do I get the file path?...............//jenny
                
                JavaScriptSerializer js = new JavaScriptSerializer();
                String jsonHouse = js.Serialize(house); //Serialize a House object into a JSON string.

                try 
                {   // adding house and getting result
                    RestfulWebRequest rwr = new RestfulWebRequest();
                    String isAdded= rwr.PostWebRequest("POST", "http://localhost:28769/api/house/addhouse", jsonHouse);   
                    if (bool.Parse(isAdded))
                    {
                        lblInstruction.Text = ADD_HOUSE_DIRECTION;
                        Response.Write("<script>alert('The house is added.')</script>");
                    }
                    else lblInstruction.Text = "Failed to add the house.";
                }
                catch (Exception ex) { lblInstruction.Text = "Error: " + ex.Message; }
            }
        }
    }
}