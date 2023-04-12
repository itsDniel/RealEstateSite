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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void logoutbtn_Click(object sender, EventArgs e)
        {
            Response.Cookies.Add(new HttpCookie("Username") { Expires = DateTime.Now.AddDays(-1) });
            Response.Redirect("RealEstateLogin.aspx");
        }
    }
}