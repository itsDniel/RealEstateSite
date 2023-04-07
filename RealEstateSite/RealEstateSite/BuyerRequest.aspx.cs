using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateSite
{
    public partial class BuyerRequest : System.Web.UI.Page
    {
        RealEstateSoap.RealEstateAPI pxy = new RealEstateSoap.RealEstateAPI();
        protected void Page_Load(object sender, EventArgs e)
        {   //jenny's comment
            //eh...if there's nothing to do for the if statement
            //why not just do if(Request.Cookies["Username"] == null) Response.Redirect("RealEstateLogin.aspx");
            if (Request.Cookies["Username"] != null)
            {

            }
            else
            {
                Response.Redirect("RealEstateLogin.aspx");
            }
        }

        protected void Searchbtn_Click(object sender, EventArgs e)
        {
            string buyer = Request.Cookies["Username"].Value.ToString();
            string status = "";
            if(statusddl.Text == "Pending")
            {
                status = "Pending";
                requestdtl.DataBind(status);
                requestdtl.Visible = true;
                requestdtl.hidebutton();
            }
            else if(statusddl.Text == "Approved")
            {
                status = "Approved";
                requestdtl.DataBind(status);
                requestdtl.Visible = true;
                requestdtl.showButton();
                
            }
            else
            {
                status = "Denied";
                requestdtl.DataBind(status);
                requestdtl.Visible = true;
                requestdtl.hidebutton();
            }
        }
    }
}