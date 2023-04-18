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
        {
            if (Request.Cookies["Username"] == null)
            {
                Response.Redirect("RealEstateLogin.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    string status = "Scheduled";
                    string buyer = Request.Cookies["Username"].Value.ToString();
                    requestdtl.DataBind(status, buyer);
                    requestdtl.Visible = true;
                    requestdtl.showButton();
                }
            }
        }

    }
}