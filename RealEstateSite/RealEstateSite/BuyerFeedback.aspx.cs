using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateSite
{
    public partial class BuyerFeedback : System.Web.UI.Page
    {
        RealEstateSoap.RealEstateAPI pxy = new RealEstateSoap.RealEstateAPI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["Username"] != null)
            {
                if (!IsPostBack)
                {
                    string buyer = Request.Cookies["Username"].Value.ToString();
                    string status = "Visited";
                    rprDisplay.DataSource = pxy.getVisited(buyer, status);
                    rprDisplay.DataBind();
                }
            }
            else Response.Redirect("RealEstateLogin.aspx");
        }

        protected void rptDisplay_ItemCommand(Object sender, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            int rowIndex = e.Item.ItemIndex;
            Label myLabel = (Label)rprDisplay.Items[rowIndex].FindControl("homeIDlbl");
            homeidplaceholder.Text = myLabel.Text;
        }

        protected void feedbackbtn_Click(object sender, EventArgs e)
        {
            Button hiddenButton = (Button)((sender as Button).NamingContainer.FindControl("feedbackHiddenbutton"));
            feedbackHiddenbutton_click(hiddenButton, EventArgs.Empty);
        }

        protected void feedbackHiddenbutton_click(object sender, EventArgs e)
        {
            FeedbackPanel.Visible = true;
            feedbackModal.Show();
            ApprovedRequestPanel.Visible = false;
            OverlayPanel.Visible = true;
        }

        protected void feedbackClosebtn_Click(object sender, EventArgs e)
        {
            ApprovedRequestPanel.Visible = true;
            FeedbackPanel.Visible = false;
            OverlayPanel.Visible = false;
        }

        protected void feedbackSubmitbtn_Click(object sender, EventArgs e)
        {
            foreach (Control control in FeedbackPanel.Controls)
            {
                if (control is TextBox)
                {
                    TextBox tb = control as TextBox;
                    if (string.IsNullOrEmpty(tb.Text))
                    {
                        feedbackmsg.Text = "You need to fill in all the textbox";
                    }
                    else
                    {
                        
                        string status = "Feedbacked";
                        string a1 = A1ddl.Text;
                        string a2 = A2ddl.Text;
                        string a3 = A3txt.Text;
                        string a4 = A4txt.Text;


                        int homeid = int.Parse(homeidplaceholder.Text);
                        string buyer = Request.Cookies["Username"].Value.ToString();
                        string buyerName = Request.Cookies["Name"].Value.ToString();
                        int FeedbackCount = pxy.CheckFeedback(buyer, homeid);

                        if (FeedbackCount > 0)
                        {
                            requestlbl.Text = "You already left a feedback on this home";
                        }
                        else
                        {
                            pxy.addFeedback(homeid, buyer, buyerName, a1, a2, a3, a4);
                            pxy.updateVisit(buyer, status, homeid.ToString());
                            requestlbl.Text = "Great You Left A Feedback, Head On To The Offer Page If You Would Like To Make An Offer";
                            FeedbackPanel.Visible = false;
                            OverlayPanel.Visible = false;
                            ApprovedRequestPanel.Visible = true;
                            break;
                        }
                    }
                }
            }
        }
    }
}