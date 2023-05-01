using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RealEstateClassLibary;
using RealEstateSoap;
using System.Data;
using AjaxControlToolkit;

namespace RealEstateSite
{
    public partial class SellerSearch : System.Web.UI.Page
    {
        RealEstateSoap.RealEstateAPI pxy = new RealEstateSoap.RealEstateAPI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["Username"] == null || Request.Cookies["Role"].Value == "Buyer")
                ((MasterSeller)Master).logoutbtn_Click(sender, e);
            else
            {
                if (!IsPostBack)
                {
                    DataTable cityTable = pxy.GetDistinctCities();  //get data from DB
                    DataRow emptyRow = cityTable.NewRow();          //create a row that contains an empty string
                    emptyRow[0] = "";
                    cityTable.Rows.InsertAt(emptyRow, 0);           //insert this new row as the 1st row to the table
                    cityddl.DataTextField = "City";                 // Set the column name to use for the display text
                    cityddl.DataValueField = "City";
                    cityddl.DataSource = cityTable;
                    cityddl.DataBind();
                }
            }
        }

        protected void Searchbtn_Click(object sender, EventArgs e)
        {
            string buyer = Request.Cookies["Username"].Value.ToString();
            string location = cityddl.Text;
            int minPrice = housePrice.minPrice(priceddl.SelectedValue); ;
            int maxPrice = housePrice.maxPrice(priceddl.SelectedValue); ;
            string property = propertyddl.Text;
            string garage = garageddl.Text;
            int minHouse = HouseSize.MinSize(houseSizeddl.SelectedValue);
            int maxHouse = HouseSize.MaxSize(houseSizeddl.SelectedValue);
            string amenity = amenityddl.Text;
            string utility = utilityddl.Text;

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
            rprDisplay.DataSource = pxy.getHouse(location, minPrice, maxPrice, property, garage, minHouse,
                                                    maxHouse, amenity, utility, buyer);
            rprDisplay.DataBind();
            SearchPanel.Visible = true;
            SearchFilterPanel.Visible = false;
            OverlayPanel.Visible = false;
        }

        protected void searchFilterbtn_Click(object sender, EventArgs e)
        {
            SearchFilterPanel.Visible = true;
            SearchPanel.Visible = false;
            searchlbl.Text = "Find it. Tour it. Own it";
            visitRequestPanel.Visible = false;
            ProfilePanel.Visible = false;
            OverlayPanel.Visible = true;
        }

        protected void SearchFilterClosebtn_click(object sender, EventArgs e)
        {
            SearchFilterPanel.Visible = false;
            OverlayPanel.Visible = false;
        }

        protected void rptDisplay_ItemCommand(Object sender, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            int rowIndex = e.Item.ItemIndex;
            Label myLabel = (Label)rprDisplay.Items[rowIndex].FindControl("homeIDlbl");
            homeidplaceholder.Text = myLabel.Text;

            DateTime AddedDate = DateTime.Parse(pxy.getHouseByID(homeidplaceholder.Text).Tables[0].Rows[0]["DateAdded"].ToString());
            TimeSpan DateCount = DateTime.Now - AddedDate;
            int DayDiff = DateCount.Days;

            DataTable dt = pxy.getHouseByID(homeidplaceholder.Text).Tables[0];
            dt.Columns.Add("DayDiff", typeof(int));
            dt.Rows[0]["DayDiff"] = DayDiff;

            rprProfile.DataSource = dt;
            rprProfile.DataBind();

            ProfilePanel.Visible = true;
            SearchPanel.Visible = false;
            searchlbl.Text = "Find it. Tour it. Own it";
        }

        protected void ProfileClosebtn_Click(object sender, EventArgs e)
        {
            ProfilePanel.Visible = false;
            SearchPanel.Visible = true;
        }

        protected void visitRequestbtn_Click(object sender, EventArgs e)
        {
            Button hiddenButton = (Button)((sender as Button).NamingContainer.FindControl("visitHiddenbutton"));
            hiddenButton_click(hiddenButton, EventArgs.Empty);
        }

        protected void hiddenButton_click(object sender, EventArgs e)
        {
            if (Request.Cookies["Role"].Value == "Buyer")
            {
                visitRequestPanel.Visible = true;
                visitModal.Show();
                ProfilePanel.Visible = false;
                OverlayPanel.Visible = true;
            }
            else
                searchlbl.Text = "Only buyer can request a visit,<br/>please create or log into a buyer account";
        }

        protected void visitClosebtn_Click(object sender, EventArgs e)
        {
            ProfilePanel.Visible = true;
            visitRequestPanel.Visible = false;
            Visitmsg.Text = string.Empty;
            OverlayPanel.Visible = false;
        }

        protected void visitSubmitbtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(visitDatetxt.Text) || string.IsNullOrEmpty(visitTimetxt.Text))
            {
                Visitmsg.Text = "You must enter the date and time";
            }
            else
            {
                string date = DateTime.Now.ToString("MM/dd/yy");
                if (DateTime.Parse(visitDatetxt.Text) < DateTime.Parse(date))
                {
                    Visitmsg.Text = "You must enter a valid date";
                }
                else
                {
                    string status = "Scheduled";

                    //Creating object for visit request with status pending and visit request with status denied in the db
                    visitRequest request = new visitRequest();
                    string buyer = Request.Cookies["Username"].Value.ToString();

                    //Pending vist request object
                    request.homeid = int.Parse(homeidplaceholder.Text);
                    request.buyer = buyer;
                    request.buyerName = Request.Cookies["Name"].Value.ToString();
                    request.date = visitDatetxt.Text;
                    request.time = visitTimetxt.Text;
                    request.status = status;

                    int check = pxy.checkVisit(request);
                    if (check > 0)
                    {
                        Visitmsg.Text = "You already have a visit request with this specific home";
                    }
                    else
                    {
                        pxy.insertVisit(request);
                        searchlbl.Text = "Visit request is sent. Check your visit status in the request page!";
                        visitRequestPanel.Visible = false;
                        SearchPanel.Visible = true;
                        OverlayPanel.Visible = false;
                    }

                }
            }
        }

        protected void roomDimensionbtn_Click(object sender, EventArgs e)
        {
            Button roomHiddenButton = (Button)((sender as Button).NamingContainer.FindControl("roomDimensionHiddentbtn"));
            roomHiddenbtn_Click(roomHiddenButton, EventArgs.Empty);
        }

        protected void roomHiddenbtn_Click(object sender, EventArgs e)
        {
            roomDimensionPanel.Visible = true;
            roomDimensionModal.Show();
            ProfilePanel.Visible = false;

            rprRoomDimension.DataSource = pxy.GetRooms(int.Parse(homeidplaceholder.Text));
            rprRoomDimension.DataBind();
            OverlayPanel.Visible = true;

        }

        protected void roomDimensionClosebtn_Click(object sender, EventArgs e)
        {
            roomDimensionPanel.Visible = false;
            ProfilePanel.Visible = true;
            OverlayPanel.Visible = false;
        }

    }
}