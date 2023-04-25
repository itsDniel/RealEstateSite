using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RealEstateSoap;
using System.Data;

namespace RealEstateSite
{
    public partial class SellerFeedback : System.Web.UI.Page
    {
        RealEstateSoap.RealEstateAPI pxy = new RealEstateSoap.RealEstateAPI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["Username"] == null || Request.Cookies["Role"].Value == "Buyer")
            {
                ((MasterSeller)Master).logoutbtn_Click(sender, e);
            }
            else
            {
                if (!IsPostBack)
                {
                    string username = Request.Cookies["Username"].Value.ToString();
                    rprDisplay.DataSource = pxy.GetFeedbackSeller(username);
                    rprDisplay.DataBind();
                }
            }
        }
    }
}