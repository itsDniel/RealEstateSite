using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RealEstateSoap;
using System.Data;
using RealEstateClassLibary;

namespace RealEstateSite
{
    public partial class SellerOffer : System.Web.UI.Page
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
                    string status = "Pending";
                    string username = Request.Cookies["Username"].Value.ToString();
                    rprDisplay.DataSource = pxy.GetOfferSeller(username, status);
                    rprDisplay.DataBind();
                }
            }
        }

        protected void rptDisplay_ItemCommand(Object sender, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            int rowIndex = e.Item.ItemIndex;

            Label myLabel = (Label)rprDisplay.Items[rowIndex].FindControl("homeIDlbl");
            homeidplaceholder.Text = myLabel.Text;


            Label myBuyerLabel = (Label)rprDisplay.Items[rowIndex].FindControl("buyerlbl");

            homeidplaceholder.Text = myLabel.Text;
            buyerplaceholder.Text = myBuyerLabel.Text;

            rprDetail.DataSource = pxy.GetOfferSellerById(buyerplaceholder.Text, int.Parse(homeidplaceholder.Text));
            rprDetail.DataBind();
            SearchPanel.Visible = false;
            DetailPanel.Visible = true;
        }

        protected void OfferAcceptbtn_Click(object sender, EventArgs e)
        {
            Button hiddenButton = (Button)((sender as Button).NamingContainer.FindControl("Accepthiddenbtn"));
            Accepthiddenbtn_click(hiddenButton, EventArgs.Empty);
        }

        protected void Accepthiddenbtn_click(object sender, EventArgs e)
        {
            string approve = "Approved";
            string listStatus = "Sold";
            int homeid = int.Parse(homeidplaceholder.Text);
            pxy.SellerUpdateOffer(homeid, buyerplaceholder.Text, approve);
            pxy.UpdateHomeOwnere(homeid, buyerplaceholder.Text, listStatus);
            DetailPanel.Visible = false;
            SearchPanel.Visible = true;
        }

        protected void OfferDenybtn_Click(object sender, EventArgs e)
        {
            Button hiddenButton = (Button)((sender as Button).NamingContainer.FindControl("Denyhiddenbtn"));
            Denyhiddenbtn_click(hiddenButton, EventArgs.Empty);
        }

        protected void Denyhiddenbtn_click(object sender, EventArgs e)
        {
            string deny = "Denied";
            int homeid = int.Parse(homeidplaceholder.Text);
            pxy.SellerUpdateOffer(homeid, buyerplaceholder.Text, deny);
            DetailPanel.Visible = false;
            SearchPanel.Visible = true;
        }
    }
}