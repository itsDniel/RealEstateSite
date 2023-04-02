﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterBuyer.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="RealEstateSite.Search" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Stylesheet/BuyerSearch.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="searchMessage">
    <asp:Label ID="searchlbl" runat="server" Font-Size="X-Large" Font-Strikeout="False" Text="Find it. Tour it. Own it"></asp:Label>
    <asp:Button ID="searchFilterbtn" runat="server" Text ="Search Filter" OnClick="searchFilterbtn_Click" />
   </div>
     <asp:Panel ID="SearchFilterPanel" runat="server" CssClass="SearchModal" BorderStyle="Solid" Visible="false">
            <asp:Label ID="SearchFilterlbl" runat="server" Text="Please select your search filter" Font-Size="X-Large"></asp:Label>
            <asp:Label ID="Locationlbl" runat="server" Text="Please choose your city"></asp:Label>
            <asp:DropDownList ID="cityddl" runat="server">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>Philadelphia</asp:ListItem>
                <asp:ListItem>New York</asp:ListItem>
                <asp:ListItem>Chicago</asp:ListItem>
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
                <asp:ListItem>Condo</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="garagelbl" runat="server" Text="Please choose your garage size"></asp:Label>
            <asp:DropDownList ID="garageddl" runat="server">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>None</asp:ListItem>
                <asp:ListItem>1 car</asp:ListItem>
                <asp:ListItem>2 car</asp:ListItem>
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
                <asp:ListItem>Basement</asp:ListItem>
                <asp:ListItem>Pool</asp:ListItem>
                <asp:ListItem>Garden</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="utilitylbl" runat="server" Text="Please choose your utility type"></asp:Label>
            <asp:DropDownList ID="utilityddl" runat="server">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>Well water</asp:ListItem>
                <asp:ListItem>Public supply</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="Searchbtn" runat="server" Text ="Search" OnClick="Searchbtn_Click" />
            <asp:Button ID="Closebtn" runat="server" Text="Close"/>
            <ajaxToolkit:ModalPopupExtender ID="SearchModal" runat="server" TargetControlID="searchFilterbtn" PopupControlID="SearchFilterPanel, SearchPanel" OkControlID="Closebtn">
            </ajaxToolkit:ModalPopupExtender>

        </asp:Panel>
    <asp:Panel ID="SearchPanel" runat="server" CssClass="Searchrpr" Visible="false">
            <asp:Repeater ID="rprDisplay" runat="server" OnItemCommand="rptDisplay_ItemCommand" >
                        <ItemTemplate>
                            <div class="card" style="width: 18rem;">
                                
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
                                        <asp:Label ID="pricelbl" runat="server" Text='<%#"Price: $" + DataBinder.Eval(Container.DataItem, "Price") %>'></asp:Label>
                                    </p>
                                    <asp:Button ID="btnShowDetail" Text="More Details" runat="server" />
                                </div>
                            </div>
                     </ItemTemplate>
                    </asp:Repeater>
        </asp:Panel>
        <asp:Panel ID="ProfilePanel" runat="server" CssClass="SearchModal" Visible="false">
            <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <div class="card" style="width: 18rem;">
                                
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
                                        <asp:Label ID="pricelbl" runat="server" Text='<%#"Price: $" + DataBinder.Eval(Container.DataItem, "Price") %>'></asp:Label>
                                    </p>
                                    <asp:Button ID="visitRequestbtn" Text="Request Visit" runat="server" />
                                    <asp:Button ID="ProfileClosebtn" Text="Close" runat="server" />
                                </div>
                            </div>
                     </ItemTemplate>
                    </asp:Repeater>
        <ajaxToolkit:ModalPopupExtender ID="ProfilePopUp" runat="server" TargetControlID="btnShowDetail" PopupControlID="ProfilePanel, SearchPanel" OkControlID="ProfileClosebtn">
            </ajaxToolkit:ModalPopupExtender>
        </asp:Panel>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    

</asp:Content>
