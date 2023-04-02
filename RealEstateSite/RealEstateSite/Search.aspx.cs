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
        public static string HomeID { get; set; }
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
            minPrice = housePrice.minPrice(priceddl.SelectedValue);
            maxPrice = housePrice.maxPrice(priceddl.SelectedValue);
            minHouse = houseSize.minSize(houseSizeddl.SelectedValue);
            maxHouse = houseSize.maxSize(houseSizeddl.SelectedValue);
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
            rprDisplay.DataSource = pxy.getHouse(location, minPrice, maxPrice, property, garage, minHouse, maxHouse, amenity, utility);
            rprDisplay.DataBind();
            SearchPanel.Visible = true;
            SearchFilterPanel.Visible = false;
        }

        protected void searchFilterbtn_Click(object sender, EventArgs e)
        {
            SearchFilterPanel.Visible = true;
            SearchPanel.Visible = false;
        }

        protected void rptDisplay_ItemCommand(Object sender, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {

            
            int rowIndex = e.Item.ItemIndex;
            Label myLabel = (Label)rprDisplay.Items[rowIndex].FindControl("homeIDlbl");
            HomeID = myLabel.Text;
            
        }

        protected void btnShowDetail_Click(object sender, EventArgs e)
        {
            ProfilePanel.Visible = true;
        }

        protected void profileClosebtn_Click(object sender, EventArgs e)
        {
            ProfilePanel.Visible = false;
        }
    }
}