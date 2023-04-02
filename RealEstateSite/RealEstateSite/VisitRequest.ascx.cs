using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RealEstateClassLibary;
using RealEstateSoap;

namespace RealEstateSite
{
    public partial class VisitRequest : System.Web.UI.UserControl
    {
        RealEstateSoap.RealEstateAPI pxy = new RealEstateSoap.RealEstateAPI();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void DataBind(string status)
        {
            string username = Request.Cookies["Username"].Value.ToString();
            visitddl.DataSource = pxy.getVisit(username, status);
            visitddl.DataBind();
        }
    }
}