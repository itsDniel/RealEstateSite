using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RealEstateSoap;

namespace RealEstateSite
{
    public partial class SellerRequest : System.Web.UI.Page
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
                    string username = Request.Cookies["Username"].Value.ToString();
                    rprDisplay.DataSource = pxy.GetVisitSeller(username);
                    rprDisplay.DataBind();
                }
            }
        }
    }
}