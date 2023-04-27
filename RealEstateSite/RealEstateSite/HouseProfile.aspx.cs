using RealEstateClassLibary;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateSite
{
    public partial class HouseProfile : System.Web.UI.Page
    {
        RealEstateSoap.RealEstateAPI pxy = new RealEstateSoap.RealEstateAPI();

        private void DisplayHouses(String url)
        {   //create a web request and get the response
            RestfulWebRequest rwr = new RestfulWebRequest();
            List<House> houseList = rwr.GetHouseWR(url);

            if(houseList != null)
            {
                foreach (House house in houseList)
                {
                    HouseProfileCtrl hpc = (HouseProfileCtrl)LoadControl("HouseProfileCtrl.ascx");
                    HouseControl hc = hpc.HouseCtrl;

                    hpc.Id = house.Id.ToString();
                    hpc.Status = house.Status;
                    hpc.Buyer = house.Homebuyer;
                    hc.Seller = house.Seller;
                    hc.Agent = house.Agent;
                    hc.City = house.City;
                    hc.Address = house.Address;
                    hc.PropertyType = house.PropertyType;
                    hpc.HomeSize = house.HomeSize;
                    hpc.Bedroom = house.Bedroom.ToString();
                    hpc.Bathroom = house.Bathroom.ToString();
                    hc.Amenities = house.Amenity;
                    hc.HeatingCooling = house.HeatingCooling;
                    hc.BuiltYear = house.BuiltYear;
                    hc.GarageSize = house.GarageSize;
                    hc.Utility = house.Utility;
                    hc.Description = house.HomeDescription;
                    hc.Price = house.Price.ToString();
                    hpc.Img = house.Image;
                    hpc.FullName = house.FullName;
                    hpc.Phone = house.PhoneNumber;
                    hpc.Email = house.Email;
                    hpc.Img = house.Image;
                    houseContainer.Controls.Add(hpc);
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["Username"] == null || Request.Cookies["Role"].Value == "Buyer")
            {
                ((MasterSeller)Master).logoutbtn_Click(sender, e); 
            }
            else
            {
                String username = Request.Cookies["Username"].Value;
                String url = "https://cis-iis2.temple.edu/Spring2023/CIS3342_tug41792/WebAPI/api/house/";

                if (pxy.GetRole(username).Equals("Seller"))
                    DisplayHouses(url + "GetHouseBySeller/" + username);
                else DisplayHouses(url + "GetHouseByAgent/" + username);
            }
        }
    }
}