using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateSite
{
    public partial class HouseProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //grab data from DB 
            //for each record of house, create a house profile control, which includes
            //home id label (hidden), picture box, house control, and dynamically added room controls
                //-pass in data that the house profile control will need
                    //-house dataset for house control and home id label (databind)
                    //-room dataset for room control to update and delete (databind)
        }
    }
}