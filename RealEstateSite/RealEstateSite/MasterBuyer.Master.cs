using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RealEstateSoap;

namespace RealEstateSite
{
    public partial class MasterBuyer : System.Web.UI.MasterPage
    {
        RealEstateSoap.RealEstateAPI pxy = new RealEstateSoap.RealEstateAPI();
        protected void Page_Load(object sender, EventArgs e)
        {
            BuyerNotibtn.Visible = false;
            string username = Request.Cookies["Username"].Value.ToString();
            string status = "Approved";
            int buyerstatus = 0;
            BuyerNotibtn.Text = "You have " + pxy.GetBuyerNoti(username, status, buyerstatus) + " new accepted offer";
            BuyerNotibtn.Visible = true;
        }

        protected void logoutbtn_Click(object sender, EventArgs e)
        {
            Response.Cookies.Add(new HttpCookie("Username") { Expires = DateTime.Now.AddDays(-1) });
            Response.Cookies.Add(new HttpCookie("Name") { Expires = DateTime.Now.AddDays(-1) });
            Response.Redirect("RealEstateLogin.aspx");
        }

        protected void BuyerNotibtn_Click(object sender, EventArgs e)
        {
            string username = Request.Cookies["Username"].Value.ToString();
            string status = "Approved";
            int buyerstatus = 1;
            pxy.UpdateBuyerNoti(username, status, buyerstatus);
            BuyerNotibtn.Visible = false;
        }
    }
}