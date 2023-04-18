using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateSite
{
    public partial class MasterSeller : System.Web.UI.MasterPage
    {
        RealEstateSoap.RealEstateAPI pxy = new RealEstateSoap.RealEstateAPI();
        protected void Page_Load(object sender, EventArgs e)
        {
            SellerNotibtn.Visible = false;
            string username = Request.Cookies["Username"].Value.ToString();
            string status = "Pending";
            int sellerstatus = 0;
            SellerNotibtn.Text = "You have " + pxy.GetSellerNoti(username, status, sellerstatus) + " new accepted offer";
            SellerNotibtn.Visible = true;
        }

        protected void logoutbtn_Click(object sender, EventArgs e)
        {
            Response.Cookies.Add(new HttpCookie("Username") { Expires = DateTime.Now.AddDays(-1) });
            Response.Redirect("RealEstateLogin.aspx");
        }

        protected void SellerNotibtn_Click(object sender, EventArgs e)
        {
            string username = Request.Cookies["Username"].Value.ToString();
            string status = "Approved";
            int sellerstatus = 1;
            pxy.UpdateSellerNoti(username, status, sellerstatus);
            SellerNotibtn.Visible = false;
        }
    }
}