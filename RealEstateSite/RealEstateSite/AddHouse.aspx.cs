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
        protected void Page_Load(object sender, EventArgs e)
        {
            lblInstruction.Text = ADD_HOUSE_DIRECTION;
            //prefill seller and agent textboxes according to the role of user
            //set seller and agent textboxes to read only in HouseControl
        }

        protected void btnAddHouse_Click(object sender, EventArgs e)
        {
            if(hc.Seller.Trim().Equals("") || hc.Agent.Trim().Equals("") || hc.Address.Trim().Equals("") ||
               hc.City.Trim().Equals("") || hc.BuiltYear.Trim().Equals("") || hc.Price.Trim().Equals("") ||
               hc.Description.Trim().Equals("") || hc.KitchenLength.Trim().Equals("") || 
               hc.KitchenWidth.Trim().Equals("") || !hc.ImgFileUpload.HasFile)
            {
                lblInstruction.Text = "Missing Info: please fill out all the textboxes and upload an image file.";
            }
            else if(int.Parse(hc.KitchenWidth) <= 0 || int.Parse(hc.KitchenLength) <= 0 || 
                    int.Parse(hc.Price) <= 0 || int.Parse(hc.BuiltYear) <= 0)
            {
                lblInstruction.Text = "Negative number or 0 is NOT allowed for the width and length of kitchen, price, and built year.";
            }
            else
            {
                String url = "http://localhost:28769/api/house";
                int kitLen = int.Parse(hc.KitchenLength);
                int kitWid = int.Parse(hc.KitchenWidth);

                House house = new House();
                house.Seller = hc.Seller;
                house.Agent = hc.Agent;
                house.Address = hc.Address;
                house.Status = "Listing";
                house.City = hc.City;
                house.PropertyType = hc.PropertyType;
                house.HomeSize = kitLen + " x " + kitWid;
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

                try // Setup an HTTP POST Web Request for adding house and get the HTTP Web Response from the server.
                {   // then use the response (ID of the house) to add a room (kitchen) to the DB
                    String id = DoWebRequest(url + "/addhouse", jsonHouse);   //adding house and getting id
                    
                    Room room = new Room();
                    room.Id = int.Parse(id);
                    room.RoomName = "Kitchen";
                    room.Length = kitLen;
                    room.Width = kitWid;
                    List<Room> rooms = new List<Room>();
                    rooms.Add(room);

                    String roomAdded = DoWebRequest(url + "/addroom", js.Serialize(rooms));  //adding room

                    if (bool.Parse(roomAdded))
                    {
                        lblInstruction.Text = ADD_HOUSE_DIRECTION;
                        Response.Write("<script>alert('The house is added.')</script>");
                    }
                    else lblInstruction.Text = "The house is added, but the kitchen isn't.";
                }
                catch (Exception ex) { lblInstruction.Text = "Error: " + ex.Message; }
            }
        }
    
        private String DoWebRequest(String url, String jsonObj)
        {
            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            request.ContentLength = jsonObj.Length;
            request.ContentType = "application/json";

            // Write the JSON data to the Web Request
            StreamWriter writer = new StreamWriter(request.GetRequestStream());
            writer.Write(jsonObj);
            writer.Flush();
            writer.Close();

            // Read the data from the Web Response, which requires working with streams.
            WebResponse response = request.GetResponse();
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            return data;
        }
    }
}