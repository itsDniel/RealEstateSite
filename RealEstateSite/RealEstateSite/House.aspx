<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSeller.Master" AutoEventWireup="true" CodeBehind="House.aspx.cs" Inherits="RealEstateSite.House" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="text-center">House Profile</h1>

    <div class="container w-75 bg-info bg-opacity-25 px-4">
        <br />
        Seller <asp:TextBox ID="txtSeller" runat="server"></asp:TextBox><br />
        Agent <asp:TextBox ID="txtAgent" runat="server"></asp:TextBox><br />
        <%-- Buyer is not editable. It's updated when user accepts an offer. --%>
        <%--Buyer: <asp:Label ID="lblBuyer" runat="server" Text="None"></asp:Label><br />--%>
        Address <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox><br />
        <%-- Status is not editable. It's updated to 'sold' when user accepts an offer. --%>
        <%--Status<asp:Label ID="lblStatus" runat="server" Text="Listing"></asp:Label><br />--%>
        City <asp:TextBox ID="txtCity" runat="server"></asp:TextBox><br />

        Property Type
        <asp:DropDownList ID="ddlPropertyType" runat="server">
            <asp:ListItem>Single-family</asp:ListItem>
            <asp:ListItem>Multi-family</asp:ListItem>
            <asp:ListItem>Townhouse</asp:ListItem>
            <asp:ListItem>Condo</asp:ListItem>
        </asp:DropDownList><br />

        <%-- total dimensions of the house will be calculated by the program, 
            so user doesn't need to enter a value for it --%>
        <%-- Bedroom # and Bathroom # will be calculated by the program 
            as user adds bedroom and bathroom dimensions --%>
    
        Amenities
        <asp:DropDownList ID="ddlAmenities" runat="server">
            <asp:ListItem>Swimming pool</asp:ListItem>
            <asp:ListItem>Garden</asp:ListItem>
            <asp:ListItem>Balcony</asp:ListItem>
            <asp:ListItem>Gated community</asp:ListItem>
            <asp:ListItem>Skylights</asp:ListItem>
        </asp:DropDownList><br />

        Heating/Cooling
        <asp:DropDownList ID="ddlHeatingCooling" runat="server">
            <asp:ListItem>Central air</asp:ListItem>
            <asp:ListItem>Forced air heat</asp:ListItem>
            <asp:ListItem>Oil heat</asp:ListItem>
            <asp:ListItem>Propane heat</asp:ListItem>
            <asp:ListItem>Hot water radiators</asp:ListItem>
            <asp:ListItem>Electric heating</asp:ListItem>
        </asp:DropDownList><br />

        <%-- only allow positive # for input validation and note that its datatype is varchar in the DB --%>
        BuiltYear <asp:TextBox ID="txtBuiltYear" runat="server" TextMode="Number"></asp:TextBox><br />

        GarageSize
        <asp:DropDownList ID="ddlGarageSize" runat="server">
            <asp:ListItem>None</asp:ListItem>
            <asp:ListItem>2 cars</asp:ListItem>
            <asp:ListItem>3 cars</asp:ListItem>
        </asp:DropDownList><br />

        Utility
        <asp:DropDownList ID="ddlUtility" runat="server">
            <asp:ListItem>Well water </asp:ListItem>
            <asp:ListItem>Public supply</asp:ListItem>
        </asp:DropDownList><br />

        Kitchen's width <asp:TextBox ID="txtKitchenWidth" runat="server" TextMode="Number"></asp:TextBox><br />
        Kitchen's length <asp:TextBox ID="txtKitchenLength" runat="server" TextMode="Number"></asp:TextBox><br />

        HomeDescription<br />
        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Width="250px"></asp:TextBox><br />
        <%-- only allow positive # for input validation --%>
        Price <asp:TextBox ID="txtPrice" runat="server" TextMode="Number"></asp:TextBox><br />
        Image <asp:FileUpload ID="fileUpload" runat="server" /><br />
        <asp:ImageButton ID="imgBtnPlus" runat="server" Height="100px" Width="100px"   
            ImageUrl="https://cdn-icons-png.flaticon.com/512/5244/5244841.png" />

        <div id="roomControls" runat="server" class="text-center">
            Room <asp:TextBox ID="txtRoomName" runat="server"></asp:TextBox><br />
            Width <asp:TextBox ID="txtRoomWidth" runat="server" TextMode="Number"></asp:TextBox><br />
            Length <asp:TextBox ID="txtRoomLength" runat="server" TextMode="Number"></asp:TextBox><br />
        </div>
        
        <asp:Button ID="btnAddHouse" runat="server" Text="Add House"/><br /><br />
    </div>
</asp:Content>