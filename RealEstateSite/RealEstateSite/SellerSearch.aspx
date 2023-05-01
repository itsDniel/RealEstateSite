<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSeller.Master" AutoEventWireup="true" CodeBehind="SellerSearch.aspx.cs" Inherits="RealEstateSite.SellerSearch" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center">
        <asp:Label ID="homeidplaceholder" runat="server" CssClass="hidden"></asp:Label><br />
        <asp:Label ID="searchlbl" runat="server" Font-Strikeout="False" Text="Find it. Tour it. Own it" CssClass="h1 title"></asp:Label>
        <br /><br />
        <asp:Button ID="searchFilterbtn" runat="server" Text ="Search Filter" OnClick="searchFilterbtn_Click" />
    </div>

    <asp:Panel ID="OverlayPanel" runat="server" CssClass="overlay" Visible="false"></asp:Panel>

    <asp:Panel ID="SearchFilterPanel" runat="server" CssClass="modalPopUp" BorderStyle="Solid" Visible="false">
        <asp:Label ID="SearchFilterlbl" runat="server" Text="Please select your search filter" Font-Size="X-Large"></asp:Label>
        <asp:Label ID="Locationlbl" runat="server" Text="Please choose your city"></asp:Label>
        <asp:DropDownList ID="cityddl" runat="server">
        </asp:DropDownList>
        <asp:Label ID="Pricelbl" runat="server" Text="Please select your price range"></asp:Label>
        <asp:DropDownList ID="priceddl" runat="server">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem Value="1">100,000<</asp:ListItem>
            <asp:ListItem Value="2">100,000 - 300,000</asp:ListItem>
            <asp:ListItem Value="3">>300,000</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="propertyTypelbl" runat="server" Text="Please choose your property type"></asp:Label>
        <asp:DropDownList ID="propertyddl" runat="server">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>Single-Family</asp:ListItem>
            <asp:ListItem>Multi-Family</asp:ListItem>
            <asp:ListItem>Townhouse</asp:ListItem>
            <asp:ListItem>Condo</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="garagelbl" runat="server" Text="Please choose your garage size"></asp:Label>
        <asp:DropDownList ID="garageddl" runat="server">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>None</asp:ListItem>
            <asp:ListItem>1 car</asp:ListItem>
            <asp:ListItem>2 cars</asp:ListItem>
            <asp:ListItem>3 cars</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="houseSizelbl" runat="server" Text="Please choose your house size"></asp:Label>
        <asp:DropDownList ID="houseSizeddl" runat="server">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem Value="1">&lt;2500 sq ft</asp:ListItem>
            <asp:ListItem Value="2">2500 sq ft &lt; and &lt; 5000 sq ft</asp:ListItem>
            <asp:ListItem Value="3">&gt; 5000 sq ft</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="amenitylbl" runat="server" Text="Please choose your amenity type"></asp:Label>
        <asp:DropDownList ID="amenityddl" runat="server">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>Swimming pool</asp:ListItem>
            <asp:ListItem>Garden</asp:ListItem>
            <asp:ListItem>Balcony</asp:ListItem>
            <asp:ListItem>Gated community</asp:ListItem>
            <asp:ListItem>Skylights</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="utilitylbl" runat="server" Text="Please choose your utility type"></asp:Label>
        <asp:DropDownList ID="utilityddl" runat="server">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>Well water</asp:ListItem>
            <asp:ListItem>Public supply</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="Searchbtn" runat="server" Text ="Search" OnClick="Searchbtn_Click" />
        <asp:Button ID="SearchFilterClosebtn" runat="server" Text="Close" OnClick="SearchFilterClosebtn_click"/>
        <ajaxToolkit:ModalPopupExtender ID="modalPopUp" runat="server" TargetControlID="searchFilterbtn" PopupControlID="SearchFilterPanel, SearchPanel" OkControlID="Closebtn">
        </ajaxToolkit:ModalPopupExtender>
    </asp:Panel>
        
    <div class="d-flex justify-content-center">
        <div class="container">
            <asp:Panel ID="SearchPanel" runat="server" Visible="false">
                <div class="row row-cols-1 row-cols-md-3 g-4 mt-1">
                    <asp:Repeater ID="rprDisplay" runat="server" OnItemCommand="rptDisplay_ItemCommand" >
                        <ItemTemplate>
                            <div class="col">    
                                <div class="card w-75 text-center mt-3">
                                    <asp:Image ID="HomeImg" runat="server" ImageUrl='<%# Eval("Image") %>' />
                                    <div class="card-body">
                                        <h1 class="card-text">
                                            <asp:Label ID="homeIDlbl" runat="server" CssClass="hidden" Text='<%#DataBinder.Eval(Container.DataItem, "HomeID") %>'></asp:Label>
                                            <asp:Label ID="addresslbl" runat="server" Text='<%# "Address: " + DataBinder.Eval(Container.DataItem, "Address") %>'></asp:Label>
                                        </h1>
                                        <p class="card-text">
                                            <asp:Label ID="citylbl" runat="server" Text='<%# "City " + DataBinder.Eval(Container.DataItem, "City") %>'></asp:Label>
                                        </p>
                                        <p class="card-text">
                                            <asp:Label ID="propertylbl" runat="server" Text='<%# "Property Type: " + DataBinder.Eval(Container.DataItem, "PropertyType") %>'></asp:Label>
                                        </p>
                                        <p class="card-text">
                                            <asp:Label ID="pricelbl" runat="server" Text='<%#"Price: $" + DataBinder.Eval(Container.DataItem, "Price") %>'></asp:Label>
                                        </p>
                                        <asp:Button ID="btnShowDetail" Text="More Details" runat="server"/>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div> 
            </asp:Panel>
        </div>
    </div>   

    <asp:Panel ID="ProfilePanel" runat="server" Visible="false" CssClass="modalPopUp">
        <asp:Repeater ID="rprProfile" runat="server">
            <ItemTemplate>
                <div class="card w-100 text-center">
                    <asp:Image ID="HomeImg" runat="server" ImageUrl='<%# Eval("Image") %>' />
                    <div class="card-body">
                        <h1 class="card-title">
                            <asp:Label ID="homeIDlbl" runat="server" CssClass="hidden" Text='<%#DataBinder.Eval(Container.DataItem, "HomeID") %>'></asp:Label>
                            <asp:Label ID="addresslbl" runat="server" Text='<%# "Address: " + DataBinder.Eval(Container.DataItem, "Address") %>'></asp:Label>
                        </h1>
                        <p class="card-text">
                            <asp:Label ID="citylbl" runat="server" Text='<%# "City: " + DataBinder.Eval(Container.DataItem, "City") %>'></asp:Label>
                        </p>
                        <p class="card-text">
                            <asp:Label ID="propertylbl" runat="server" Text='<%# "Property Type: " + DataBinder.Eval(Container.DataItem, "PropertyType") %>'></asp:Label>
                        </p>
                        <p class="card-text">
                            <asp:Label ID="homesizelbl" runat="server" Text='<%# "Home Size: " + DataBinder.Eval(Container.DataItem, "HomeSize") + " square feet" %>'></asp:Label>
                        </p>
                        <p class="card-text">
                            <asp:Label ID="domlbl" runat="server" Text='<%# "Days on market: " + DataBinder.Eval(Container.DataItem, "DayDiff") + " Day(s)" %>'></asp:Label>
                        </p>
                        <p class="card-text">
                            <asp:Label ID="bedroomlbl" runat="server" Text='<%# "Bedroom: " + DataBinder.Eval(Container.DataItem, "Bedroom") %>'></asp:Label>
                        </p>
                        <p class="card-text">
                            <asp:Label ID="bathroomlbl" runat="server" Text='<%# "Bathroom: " + DataBinder.Eval(Container.DataItem, "Bathroom") %>'></asp:Label>
                        </p>
                        <p class="card-text">
                            <asp:Button ID="roomDetail" Text="Room Dimension Detail" runat="server" OnClick="roomDimensionbtn_Click" />
                        </p>
                        <p class="card-text">
                            <asp:Label ID="amenity" runat="server" Text='<%# "Amenity: " + DataBinder.Eval(Container.DataItem, "Amenity") %>'></asp:Label>
                        </p>
                        <p class="card-text">
                            <asp:Label ID="heatlbl" runat="server" Text='<%# "Heating/Cooling Type: " + DataBinder.Eval(Container.DataItem, "Heating/Cooling") %>'></asp:Label>
                        </p>
                        <p class="card-text">
                            <asp:Label ID="builtyearlbl" runat="server" Text='<%# "Built Year: " + DataBinder.Eval(Container.DataItem, "BuiltYear") %>'></asp:Label>
                        </p>
                        <p class="card-text">
                            <asp:Label ID="garagelbl" runat="server" Text='<%# "Garage Size: " + DataBinder.Eval(Container.DataItem, "GarageSize") %>'></asp:Label>
                        </p>
                        <p class="card-text">
                            <asp:Label ID="utilitylbl" runat="server" Text='<%# "Utility: " + DataBinder.Eval(Container.DataItem, "Utility") %>'></asp:Label>
                        </p>
                        <p class="card-text">
                            <asp:Label ID="homedeslbl" runat="server" Text='<%# "Description: " + DataBinder.Eval(Container.DataItem, "HomeDescription") %>'></asp:Label>
                        </p>
                        <p class="card-text">
                            <asp:Label ID="pricelbl" runat="server" Text='<%#"Price: $" + DataBinder.Eval(Container.DataItem, "Price") %>'></asp:Label>
                        </p>
                        <p class="card-text">
                            <asp:Label ID="agentlbl" runat="server" Text='<%# "Agent: " + DataBinder.Eval(Container.DataItem, "FullName") %>'></asp:Label>
                        </p>
                        <p class="card-text">
                            <asp:Label ID="agentemaillbl" runat="server" Text='<%# "Email: " + DataBinder.Eval(Container.DataItem, "Email") %>'></asp:Label>
                        </p>
                        <p class="card-text">
                            <asp:Label ID="agentphonelbl" runat="server" Text='<%# "Phone number: " + DataBinder.Eval(Container.DataItem, "Phone") %>'></asp:Label>
                        </p>
                        <asp:Button ID="visitRequestbtn" Text="Request Visit" runat="server" OnClick="visitRequestbtn_Click" Visible ="true" />
                        <asp:Button ID="ProfileClosebtn" Text="Close" runat="server" OnClick="ProfileClosebtn_Click" />
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <asp:Button ID="visitHiddenbutton" runat="server" CssClass="hidden" />
    </asp:Panel>

    <asp:Panel ID="roomDimensionPanel" runat="server" CssClass="modalPopUp" BorderStyle="Solid" Visible = "false">
        <asp:Repeater ID="rprRoomDimension" runat="server" Visible="true">
            <ItemTemplate>
                <div class="card w-75 text-center">
                    <div class="card-body">
                        <h1 class="card-title">
                            <asp:Label ID="roomNamelbl" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Room") %>'></asp:Label>
                        </h1>
                        <p class="card-text">
                            <asp:Label ID="dimensionlbl" runat="server" Text='<%# "Dimension (L x W): " + DataBinder.Eval(Container.DataItem, "Length") + " ft " + " x " + DataBinder.Eval(Container.DataItem, "Width") + " ft" %>'></asp:Label>
                        </p>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <asp:Button ID="roomDimensionClosebtn" runat="server" Text="Close" OnClick="roomDimensionClosebtn_Click" />
        <ajaxToolkit:ModalPopupExtender ID="roomDimensionModal" runat="server" TargetControlID="roomDimensionHiddenbtn" PopupControlID="roomDimensionPanel, ProfilePanel" OkControlID="roomDimensionClosebtn" >
        </ajaxToolkit:ModalPopupExtender>
    </asp:Panel>
    <asp:Button ID="roomDimensionHiddenbtn" runat="server" CssClass="hidden" />

    <asp:Panel ID="visitRequestPanel" runat="server" CssClass="modalPopUp" BorderStyle="Solid" Visible = "false">
        <asp:Label ID="visitrequestlbl" runat="server" Text="Schedule a visit date and time" Font-Size="X-Large"></asp:Label>
        <asp:Label ID="Visitmsg" runat="server" ForeColor="Red"></asp:Label>
        <asp:Label ID="visitDatelbl" runat="server" Text="Please enter your desired visit date"></asp:Label>
        <asp:TextBox ID="visitDatetxt" runat="server" TextMode="Date" placeholder ="mm/dd/yy" DataFormatString="{0:MM/dd/yy}"></asp:TextBox>
        <asp:Label ID="visitTimelbl" runat="server" Text="Please enter the time you want to visit"></asp:Label>
        <asp:TextBox ID="visitTimetxt" runat="server" TextMode="Time" DataFormatString="{0:hh:mm}" placeholder="hh:mm"></asp:TextBox>
        <asp:Button ID="visitSubmitbtn" runat="server" Text ="Request Visit" OnClick="visitSubmitbtn_Click" />
        <asp:Button ID="visitClosebtn" runat="server" Text="Close" OnClick="visitClosebtn_Click" />
        <ajaxToolkit:ModalPopupExtender ID="visitModal" runat="server" TargetControlID="visitHiddenbutton" PopupControlID="visitRequestPanel" OkControlID="visitClosebtn" >
        </ajaxToolkit:ModalPopupExtender>
    </asp:Panel>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
</asp:Content>
