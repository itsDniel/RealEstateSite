﻿using System;
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
        public static string id { get; set; }
        RealEstateSoap.RealEstateAPI pxy = new RealEstateSoap.RealEstateAPI();
        protected void Page_Load(object sender, EventArgs e)
        {
            requestlbl.Text = "If you have visited these houses,<br/>please click 'I have visited' button";
        }

        public void DataBind(string status, string username)
        {
            visitddl.DataSource = pxy.getVisit(username, status);
            visitddl.DataBind();
        }
        public void showButton()
        {
            foreach(DataListItem item in visitddl.Items)
            {
                Button btn = (Button)item.FindControl("visitedbtn");
                btn.Visible = true;
            }
        }

        public void hidebutton()
        {
            foreach (DataListItem item in visitddl.Items)
            {
                Button btn = (Button)item.FindControl("visitedbtn");
                btn.Visible = false;
            }
        }

        public void visitddl_ItemCommand(object sender, DataListCommandEventArgs e)
        {
            int rowIndex = e.Item.ItemIndex;
            Label myLabel = (Label)visitddl.Items[rowIndex].FindControl("homeidlbl");
            string id = myLabel.Text;
            string username = Request.Cookies["Username"].Value.ToString();
            string status = "Visited";
            pxy.updateVisit(username, status, id);
            foreach (DataListItem item in visitddl.Items)
            {
                Label lbl = (Label)item.FindControl("msglbl");
                requestlbl.Text = "Great! Please go to the feedback page<br/>to leave a feedback.";
            }
        }
    }
}