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
            room.Width = int.Parse(txtRoomWidth.Text); ;

            JavaScriptSerializer js = new JavaScriptSerializer();
            String jsonRoom = js.Serialize(room); //Serialize a room object into a JSON string.

            try
            {   // adding house and getting result
                String isAdded = rwr.PostWebRequest(URL + "addroom", jsonRoom);
                if (bool.Parse(isAdded))
                {
                    lblInstruction.Text = ADD_ROOM_DIR;
                    ClearText();
                    ChangeVisibilities(false, true);
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

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}