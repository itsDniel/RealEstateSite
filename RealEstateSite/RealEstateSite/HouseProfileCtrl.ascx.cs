﻿using RealEstateClassLibary;
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
        JavaScriptSerializer js = new JavaScriptSerializer();

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

        private String SerializeRoom(String roomName, int width, int length)
        {
            Room room = new Room();
            room.RoomName = roomName;
            room.Width = width; 
            room.Length = length; 
            room.Id = int.Parse(lblId.Text);
            return js.Serialize(room);
        }

        private bool UpdateHomeSizeInfo(int bedroomNum, int bathroomNum, String totalHomeSize)
        {   //update # of bedroom and bathroom and total house size in DB
            HouseSize hs = new HouseSize();
            hs.Bedroom = bedroomNum;
            hs.Bathroom = bathroomNum;
            hs.HomeSize = totalHomeSize;
            hs.Id = int.Parse(lblId.Text);

            String jsonHouseSize = js.Serialize(hs);
            return bool.Parse(rwr.PutWebRequest("PUT", URL + "UpdateHomeSizeInfo", jsonHouseSize));
        }

        private void AddRoomToDB()
        {
            String jsonRoom = SerializeRoom(txtRoomName.Text, int.Parse(txtRoomWidth.Text), 
                                            int.Parse(txtRoomLength.Text));
            try
            {   // adding room to the DB and getting result
                String isAdded = rwr.PostWebRequest("POST", URL + "addroom", jsonRoom);

                //if successfully added the new room, calculate the total home size, bedroom, and bathroom
                if (bool.Parse(isAdded)) 
                {   //get the # of bedroom and bathroom and the total house size from the DB
                    int bedroomNum = int.Parse(lblBedroom.Text);
                    int bathroomNum = int.Parse(lblBathroom.Text);
                    int totalHomeSize = int.Parse(lblHomeSize.Text);

                    //calculate the # of bedroom and bathroom and the total house size
                    if (txtRoomName.Text.ToLower().Contains("bedroom")) bedroomNum++;
                    else if (txtRoomName.Text.ToLower().Contains("bathroom")) bathroomNum++;
                    totalHomeSize += int.Parse(txtRoomLength.Text) * int.Parse(txtRoomWidth.Text);

                    //HouseSize hs = new HouseSize();
                    //hs.Bedroom = bedroomNum;
                    //hs.Bathroom = bathroomNum;
                    //hs.HomeSize = totalHomeSize.ToString();
                    //hs.Id = int.Parse(lblId.Text);

                    ////update # of bedroom and bathroom and total house size in DB
                    //String jsonHouseSize = js.Serialize(hs);
                    //String isUpdated = rwr.PutWebRequest("PUT", URL + "UpdateHomeSizeInfo", jsonHouseSize);

                    if (UpdateHomeSizeInfo(bedroomNum, bathroomNum, totalHomeSize.ToString()))//Boolean.Parse(isUpdated))
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
                gvRooms.DataSource = rwr.GetRoomWR(URL + "getrooms/" + int.Parse(lblId.Text));
                gvRooms.DataBind();
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

        protected void btnUpdate_Click(object sender, EventArgs e) //updating house (not including room)
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

        protected void btnDelete_Click(object sender, EventArgs e) //deleting house
        {
            rwr.DeleteWebRequest(URL + "DeleteHouse/" + lblId.Text);
        }

        protected void gvRooms_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            TableCellCollection cells = gvRooms.Rows[rowIndex].Cells;
            String roomName = cells[0].Text;
            int width = int.Parse(cells[2].Text);
            int length = int.Parse(cells[1].Text);

            if (e.CommandName == "UpdateRoom")
            {
                String jsonRoom = SerializeRoom(roomName, width, length);
                bool isRoomUpdated = bool.Parse(rwr.PutWebRequest("PUT", URL + "UpdateRoom", jsonRoom));

                //calculate the total house size and update it in the DB
                if (isRoomUpdated)
                {
                    gvRooms.DataBind(); //rebind
                    int totalHomeSize = 0;
                    List<Room> rooms = rwr.GetRoomWR(URL + "getrooms/" + int.Parse(lblId.Text));
                    
                    //to ensure that we don't mix the old and new data together,
                    //grap all the room data for this house and calculate the total home size
                    foreach (Room room in rooms) { totalHomeSize += room.Width * room.Length; }

                    if (UpdateHomeSizeInfo(int.Parse(lblBedroom.Text), int.Parse(lblBathroom.Text), totalHomeSize.ToString()))
                        lblHomeSize.Text = totalHomeSize.ToString(); //displaying new data
                }
            }
            else if (e.CommandName == "DeleteRoom")
            {
                bool isDeleted = bool.Parse(rwr.DeleteWebRequest(URL + "DeleteRoom/" + lblId.Text + "/" + roomName));

                //calculate # of bedroom and bathroom and total house size and update the data in the DB
                if (isDeleted)
                {
                    gvRooms.DataBind(); //rebind 
                    int bedroom = int.Parse(lblBedroom.Text);
                    int bathroom = int.Parse(lblBathroom.Text);
                    int totalHomeSize = int.Parse(lblHomeSize.Text);
                    totalHomeSize -= width * length;

                    if (roomName.ToLower().Contains("bedroom")) bedroom--;
                    else if (roomName.ToLower().Contains("bathroom")) bathroom--;

                    if(UpdateHomeSizeInfo(bedroom, bathroom, totalHomeSize.ToString())) 
                        lblHomeSize.Text = totalHomeSize.ToString(); //displaying new data
                }
            }
        }
    }
}