using RealEstateClassLibary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateSite
{
    public partial class HouseProfileCtrl : System.Web.UI.UserControl
    {
        public String Id
        {
            get { return lblId.Text; }
            set { lblId.Text = value; }
        }
        public String Status
        {
            get { return lblStatus.Text; }
            set { lblStatus.Text = value; }
        }
        public String Buyer
        {
            get { return lblBuyer.Text; }
            set { lblBuyer.Text = value; }
        }
        public String HomeSize
        {
            get { return lblHomeSize.Text; }
            set { lblHomeSize.Text = value; }
        }
        public String Bedroom
        {
            get { return lblBedroom.Text; }
            set { lblBedroom.Text = value; }
        }
        public String Bathroom
        {
            get { return lblBathroom.Text; }
            set { lblBathroom.Text = value; }
        }
        public String Img
        {
            get { return img.ImageUrl; }
            set { img.ImageUrl = value; }
        }
        public HouseControl HouseCtrl{ get { return houseCtrl; } }

        const String ADD_ROOM_DIR = "Click the plus sign to add room.";
        const String URL = "http://localhost:28769/api/house/";
        RestfulWebRequest rwr = new RestfulWebRequest();

        private void ChangeVisibilities(bool canViewRoomCtrl, bool canViewImgBtn)
        {
            roomControls.Visible = canViewRoomCtrl;
            imgBtnPlus.Visible = canViewImgBtn;
        }

        private void ClearText()
        {
            txtRoomName.Text = "";
            txtRoomWidth.Text = "";
            txtRoomLength.Text = "";
        }

        private void AddRoomToDB()
        {
            Room room = new Room();
            room.Id = int.Parse(lblId.Text);
            room.RoomName = txtRoomName.Text;
            room.Length = int.Parse(txtRoomLength.Text);
            room.Width = int.Parse(txtRoomWidth.Text); 

            JavaScriptSerializer js = new JavaScriptSerializer();
            String jsonRoom = js.Serialize(room); //Serialize a room object into a JSON string.

            try
            {   // adding room to the DB and getting result
                String isAdded = rwr.PostWebRequest("POST", URL + "addroom", jsonRoom);

                //if successfully added the new room, calculate the total home size, bedroom, and bathroom
                if (bool.Parse(isAdded)) 
                {   //get the # of bedroom and bathroom and the total house size from the DB
                    HouseSize hs = rwr.GetHouseSizeInfo(URL + "GetHouseSizeInfo/" + lblId.Text);
                    int bedroomNum = hs.Bedroom;
                    int bathroomNum = hs.Bathroom;
                    int totalHomeSize;
                    if (hs.HomeSize.Equals("Unknown")) totalHomeSize = 0;
                    else totalHomeSize = int.Parse(hs.HomeSize);

                    //calculate the # of bedroom and bathroom and the total house size
                    if (txtRoomName.Text.ToLower().Contains("bedroom")) bedroomNum++;
                    if (txtRoomName.Text.ToLower().Contains("bathroom")) bathroomNum++;
                    totalHomeSize += int.Parse(txtRoomLength.Text) * int.Parse(txtRoomWidth.Text);

                    hs.Bedroom = bedroomNum;
                    hs.Bathroom = bathroomNum;
                    hs.HomeSize = totalHomeSize.ToString();
                    hs.Id = int.Parse(lblId.Text);

                    //update # of bedroom and bathroom and total house size in DB
                    String jsonHouseSize = js.Serialize(hs);
                    String isUpdated = rwr.PutWebRequest("PUT", URL + "UpdateHomeSizeInfo", jsonHouseSize);

                    if (Boolean.Parse(isUpdated))
                    {
                        lblHomeSize.Text = totalHomeSize.ToString(); //displaying new data
                        lblBathroom.Text = bathroomNum.ToString();
                        lblBedroom.Text = bedroomNum.ToString();
                        lblInstruction.Text = ADD_ROOM_DIR;
                        ClearText();
                        ChangeVisibilities(false, true);
                    }
                    else lblInstruction.Text = "Room is added, but the total house size, " +
                                                "# of bedroom, or # of bathroom is not updated.";
                }
                else lblInstruction.Text = "Failed to add room.";
            }
            catch (Exception ex) { lblInstruction.Text = "Error: " + ex.Message; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                lblInstruction.Text = ADD_ROOM_DIR;
                roomControls.Visible = false;

                //use gv to display rooms???.................................
                //each row has a delete and update room btn
            }
        }

        protected void imgBtnPlus_Click(object sender, ImageClickEventArgs e)
        {
            lblInstruction.Text = "Fill out the following textboxes.";
            ChangeVisibilities(true, false);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            lblInstruction.Text = ADD_ROOM_DIR;
            ClearText();
            ChangeVisibilities(false, true);
        }

        protected void btnAddRoom_Click(object sender, EventArgs e)
        {
            if (txtRoomName.Text.Trim().Equals("") || txtRoomWidth.Text.Trim().Equals("") || txtRoomLength.Text.Trim().Equals(""))
                lblInstruction.Text = "One of the textboxes is NOT filled in.";
            else if (int.Parse(txtRoomWidth.Text) <= 0 || int.Parse(txtRoomLength.Text) <= 0)
                lblInstruction.Text = "Width and length can't be 0 or negative.";
            else
            {   //check if there's a room with the same name for the same house in the DB (duplicate)
                List<Room> rooms = rwr.GetRoomWR(URL + "getrooms/" + int.Parse(lblId.Text));
                if(rooms != null)
                {
                    bool noDuplicate = true;
                    foreach(Room room in rooms)
                    {
                        if (room.RoomName.Equals(txtRoomName.Text))
                        {   //can't have duplicate room
                            lblInstruction.Text = "Failed to add room. A room with this name already exists for this house.";
                            noDuplicate = false;
                            break;
                        }
                    }
                    if(noDuplicate) AddRoomToDB();
                }
                //this house has no room data, so no duplicate room for the same house
                else AddRoomToDB();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //House house = new House();
            //house.Seller = hc.Seller;
            //house.Agent = hc.Agent;
            //house.Address = hc.Address;
            //house.Status = "Listing";
            //house.City = hc.City;
            //house.PropertyType = hc.PropertyType;
            //house.HomeSize = "Unknown";   //calculate and update in AddRoomToDB(), so delete this later and in Stored procedure
            //house.Bedroom = 0;            //calculate and update in AddRoomToDB(), so delete this later
            //house.Bathroom = 0;           //calculate and update in AddRoomToDB(), so delete this later
            //house.Amenity = hc.Amenities;
            //house.HeatingCooling = hc.HeatingCooling;
            //house.BuiltYear = hc.BuiltYear;
            //house.GarageSize = hc.GarageSize;
            //house.Utility = hc.Utility;
            //house.HomeDescription = hc.Description;
            //house.Price = int.Parse(hc.Price);
            //rwr.PutWebRequest(URL + "updatehouse", );
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}