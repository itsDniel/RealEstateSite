using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateSite
{
    public partial class HouseControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        
        public String Seller { 
            get { return txtSeller.Text; }
            set { txtSeller.Text = value; }
        }
        public String Agent
        {
            get { return txtAgent.Text; }
            set { txtAgent.Text = value; }
        }
        public String Address
        {
            get { return txtAddress.Text; }
            set { txtAddress.Text = value; }
        }
        public String City
        {
            get { return txtCity.Text; }
            set { txtCity.Text = value; }
        }
        public String PropertyType
        {
            get { return ddlPropertyType.SelectedValue; }
            set { ddlPropertyType.SelectedValue = value; }
        }
        public String Amenities
        {
            get { return ddlAmenities.SelectedValue; }
            set { ddlAmenities.SelectedValue = value; }
        }
        public String HeatingCooling
        {
            get { return ddlHeatingCooling.SelectedValue; }
            set { ddlHeatingCooling.SelectedValue = value; }
        }
        public String Utility
        {
            get { return ddlUtility.SelectedValue; }
            set { ddlUtility.SelectedValue = value; }
        }
        public String KitchenWidth
        {
            get { return txtKitchenWidth.Text; }
            set { txtKitchenWidth.Text = value; }
        }
        public String KitchenLength
        {
            get { return txtKitchenLength.Text; }
            set { txtKitchenLength.Text = value; }
        }
        public String GarageSize
        {
            get { return ddlGarageSize.SelectedValue; }
            set { ddlGarageSize.SelectedValue = value; }
        }
        public FileUpload ImgFileUpload { get { return fileUpload; } } 
        public String BuiltYear
        {
            get { return txtBuiltYear.Text; }
            set { txtBuiltYear.Text = value; }
        }
        public String Price
        {
            get { return txtPrice.Text; }
            set { txtPrice.Text = value; }
        }
        public String Description
        {
            get { return txtDescription.Text; }
            set { txtDescription.Text = value; }
        }
    }
}