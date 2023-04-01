using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RealEstateClassLibary;
using RealEstateSoap;
using System.Data;

namespace RealEstateSite
{
    public partial class Search : System.Web.UI.Page
    {
        RealEstateSoap.RealEstateAPI pxy = new RealEstateSoap.RealEstateAPI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.Cookies["Username"] != null)
            {

            }
            else
            {
                Response.Redirect("RealEstateLogin.aspx");
            }
        }

        protected void Searchbtn_Click(object sender, EventArgs e)
        {
            
            string location = cityddl.Text;
            int minPrice;
            int maxPrice;
            string property = propertyddl.Text;
            string garage = garageddl.Text;
            int minHouse;
            int maxHouse;
            string amenity = amenityddl.Text;
            string utility = utilityddl.Text;
            string house = priceddl.SelectedValue;
            string size = houseSizeddl.SelectedValue;
            minPrice = housePrice.minPrice(int.Parse(house));
            maxPrice = housePrice.maxPrice(int.Parse(house));
            minHouse = houseSize.minSize(int.Parse(size));
            maxHouse = houseSize.maxSize(int.Parse(size));
            searchHouse getHome = new searchHouse();
            getHome.location = location;
            getHome.minPrice = minPrice;
            getHome.maxPrice = maxPrice;
            getHome.property = property;
            getHome.garage = garage;
            getHome.minSize = minHouse;
            getHome.maxSize = maxHouse;
            getHome.amenity = amenity;
            getHome.utility = utility;
            rprDisplay.Visible = true;
            rprDisplay.DataSource = pxy.getHouse(getHome);
            rprDisplay.DataBind();
        }
    }
}