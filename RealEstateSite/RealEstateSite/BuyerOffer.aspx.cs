using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RealEstateClassLibary;

namespace RealEstateSite
{
    public partial class BuyerOffer : System.Web.UI.Page
    {
        RealEstateSoap.RealEstateAPI pxy = new RealEstateSoap.RealEstateAPI();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Request.Cookies["Username"] == null)
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
            Button hiddenButton = (Button)((sender as Button).NamingContainer.FindControl("offerHiddenbutton"));
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
                        OfferBuyer offer = new OfferBuyer();

                        string status = "Pending";
                        string statusFeedback = "Offered";
                        int SellerViewStatus = 0;
                        int BuyerViewStatus = 0;


                        int a1 = int.Parse(A1txt.Text);
                        string a2 = A2ddl.Text;
                        string a3 = A3txt.Text;


                        int homeid = int.Parse(homeidplaceholder.Text);
                        string buyer = Request.Cookies["Username"].Value.ToString();

                        offer.homeid = homeid;
                        offer.buyer = buyer;
                        offer.a1 = a1;
                        offer.a2 = a2;
                        offer.a3 = a3;
                        offer.status = status;
                        offer.sellerStatus = SellerViewStatus;
                        offer.buyerStatus = BuyerViewStatus;

                        pxy.addOffer(offer);
                        pxy.updateFeedback(homeid, buyer, statusFeedback);
                        offerlbl.Text = "Great You Submitted An Offer";
                        OfferPanel.Visible = false;
                        OverlayPanel.Visible = false;
                        break;
                    }
                }
            }
        }

        protected void OfferSearchbtn_Click(object sender, EventArgs e)
        {
            //Get the status from the ddl
            string status = " ";
            string buyer = Request.Cookies["Username"].Value.ToString();

            if (OfferStatusddl.Text == "Awaiting Offer")
            {
                status = "Offered";
                rprDisplay.DataSource = pxy.getFeedbacked(buyer, status);
                rprDisplay.DataBind();


                //Show the submit offer button
                foreach (RepeaterItem item in rprDisplay.Items)
                {
                    Button btn = (Button)item.FindControl("offerbtn");
                    btn.Visible = true;

                    Label pricelbl = (Label)item.FindControl("pricelbl");
                    pricelbl.Visible = true;

                    Label statuslbl = (Label)item.FindControl("statuslbl");
                    statuslbl.Visible = false;
                }

            }
            else if(OfferStatusddl.Text == "Pending")
            {
                status = "Pending";
                rprDisplay.DataSource = pxy.GetOffer(buyer, status);
                rprDisplay.DataBind();
                FeedbackedPanel.Visible = true;

                //Hide the submit offer button
                foreach (RepeaterItem item in rprDisplay.Items)
                {
                    Button btn = (Button)item.FindControl("offerbtn");
                    btn.Visible = false;

                    Label pricelbl = (Label)item.FindControl("pricelbl");
                    pricelbl.Visible = true;

                    Label statuslbl = (Label)item.FindControl("statuslbl");
                    statuslbl.Visible = true;
                }
            }
            else if(OfferStatusddl.Text == "Denied")
            {
                status = "Denied";
                rprDisplay.DataSource = pxy.GetOffer(buyer, status);
                rprDisplay.DataBind();
                FeedbackedPanel.Visible = true;
                

                //Hide the submit offer button
                foreach (RepeaterItem item in rprDisplay.Items)
                {
                    Button btn = (Button)item.FindControl("offerbtn");
                    btn.Visible = false;

                    Label pricelbl = (Label)item.FindControl("pricelbl");
                    pricelbl.Visible = true;

                    Label statuslbl = (Label)item.FindControl("statuslbl");
                    statuslbl.Visible = true;
                }
            }
            else if(OfferStatusddl.Text == "Approved")
            {
                status = "Approved";
                rprDisplay.DataSource = pxy.GetOffer(buyer, status);
                rprDisplay.DataBind();
                FeedbackedPanel.Visible = true;

                //Hide the submit offer button and control the visibility of some labels
                foreach (RepeaterItem item in rprDisplay.Items)
                {
                    Button btn = (Button)item.FindControl("offerbtn");
                    btn.Visible = false;

                    Label pricelbl = (Label)item.FindControl("pricelbl");
                    pricelbl.Visible = true;

                    Label statuslbl = (Label)item.FindControl("statuslbl");
                    statuslbl.Visible = true;
                }
            }
        }
    }
}