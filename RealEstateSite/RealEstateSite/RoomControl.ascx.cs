using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateSite
{
    public partial class RoomControl : System.Web.UI.UserControl
    {
        const String ADD_ROOM_DIR = "Click the plus sign to add room.";
        const String FILL_IN_TEXTBOXES = "Fill out the following textboxes.";
        const String MISSING_INFO = "One of the textboxes is NOT filled in.";
        const String ERROR_DUPLICATE_ROOM = "Failed to add room. A room with this name already exists.";

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

        protected void Page_Load(object sender, EventArgs e)
        {
            lblInstruction.Text = ADD_ROOM_DIR;
            roomControls.Visible = false;
        }

        protected void imgBtnPlus_Click(object sender, ImageClickEventArgs e)
        {
            lblInstruction.Text = FILL_IN_TEXTBOXES;
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
            if(txtRoomName.Text.Trim().Equals("") || txtRoomWidth.Text.Trim().Equals("") ||
               txtRoomLength.Text.Trim().Equals(""))
            { lblInstruction.Text = MISSING_INFO; }
            else
            {
                
            }
        }
    }
}