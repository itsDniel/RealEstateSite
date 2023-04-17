using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateSite
{
    public partial class BuyerOffer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RealEstateSoap.RealEstateAPI pxy = new RealEstateSoap.RealEstateAPI();
            if (Request.Cookies["Username"] != null)
            {
                if (!IsPostBack)
                {
                    string status = "Offered";
                    string buyer = Request.Cookies["Username"].Value.ToString();
                    rprDisplay.DataSource = pxy.getFeedbacked(buyer, status);
                    rprDisplay.DataBind();
                }
            }
            else
            {
                Response.Redirect("RealEstateLogin.aspx");
            }
        }

        protected void rptDisplay_ItemCommand(Object sender, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            int rowIndex = e.Item.ItemIndex;
            Label myLabel = (Label)rprDisplay.Items[rowIndex].FindControl("homeIDlbl");
            homeidplaceholder.Text = myLabel.Text;
        }

        protected void offerbtn_Click(object sender, EventArgs e)
        {
            Button hiddenButton = (Button)((sender as Button).NamingContainer.FindControl("feedbackHiddenbutton"));
            offerHiddenbutton_click(hiddenButton, EventArgs.Empty);
        }

        protected void offerHiddenbutton_click(object sender, EventArgs e)
        {
            OfferPanel.Visible = true;
            OfferModal.Show();
            FeedbackedPanel.Visible = false;
            OverlayPanel.Visible = true;
        }

        protected void offerClosebtn_Click(object sender, EventArgs e)
        {
            FeedbackedPanel.Visible = true;
            OfferPanel.Visible = false;
            OverlayPanel.Visible = false;
        }

        protected void offerSubmitbtn_Click(object sender, EventArgs e)
        {
            foreach (Control control in OfferPanel.Controls)
            {
                if (control is TextBox)
                {
                    TextBox tb = control as TextBox;
                    if (string.IsNullOrEmpty(tb.Text))
                    {
                        offermsg.Text = "You need to answer all the questions";
                    }
                    else
                    {
                        RealEstateSoap.RealEstateAPI pxy = new RealEstateSoap.RealEstateAPI();
                        string status = "Pending";
                        string statusFeedback = "Offered";


                        int a1 = int.Parse(A1txt.Text);
                        string a2 = A2ddl.Text;
                        string a3 = A3txt.Text;


                        int homeid = int.Parse(homeidplaceholder.Text);
                        string buyer = Request.Cookies["Username"].Value.ToString();


                        pxy.addOffer(homeid, buyer, a1, a2, a3, status);
                        pxy.updateFeedback(homeid, buyer, statusFeedback);
                        offerlbl.Text = "Great You Submitted An Offer";
                        OfferPanel.Visible = false;
                        OverlayPanel.Visible = false;
                    }
                }
            }
        }
    }
}