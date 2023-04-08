<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HouseControl.ascx.cs" Inherits="RealEstateSite.HouseControl" %>
<div class="row">
    <div class="col">Seller <asp:TextBox ID="txtSeller" runat="server"></asp:TextBox></div>
    <div class="col">Agent <asp:TextBox ID="txtAgent" runat="server"></asp:TextBox></div>
</div>
<div class="row">
    <div class="col">Address <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox></div>
    <div class="col">City <asp:TextBox ID="txtCity" runat="server"></asp:TextBox></div>
</div>
<div class="row">
    <div class="col">
        Property Type
        <asp:DropDownList ID="ddlPropertyType" runat="server">
            <asp:ListItem>Single-family</asp:ListItem>
            <asp:ListItem>Multi-family</asp:ListItem>
            <asp:ListItem>Townhouse</asp:ListItem>
            <asp:ListItem>Condo</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="col">
        Amenities
        <asp:DropDownList ID="ddlAmenities" runat="server">
            <asp:ListItem>Swimming pool</asp:ListItem>
            <asp:ListItem>Garden</asp:ListItem>
            <asp:ListItem>Balcony</asp:ListItem>
            <asp:ListItem>Gated community</asp:ListItem>
            <asp:ListItem>Skylights</asp:ListItem>
        </asp:DropDownList>
    </div>
</div>
<div class="row">
    <div class="col">
        Heating/Cooling
        <asp:DropDownList ID="ddlHeatingCooling" runat="server">
            <asp:ListItem>Central air</asp:ListItem>
            <asp:ListItem>Forced air heat</asp:ListItem>
            <asp:ListItem>Oil heat</asp:ListItem>
            <asp:ListItem>Propane heat</asp:ListItem>
            <asp:ListItem>Hot water radiators</asp:ListItem>
            <asp:ListItem>Electric heating</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="col">
        Utility
        <asp:DropDownList ID="ddlUtility" runat="server">
            <asp:ListItem>Well water </asp:ListItem>
            <asp:ListItem>Public supply</asp:ListItem>
        </asp:DropDownList>
    </div>
</div>
<div class="row">
    <div class="col">Kitchen's width <asp:TextBox ID="txtKitchenWidth" runat="server" TextMode="Number"></asp:TextBox></div>
    <div class="col">Kitchen's length <asp:TextBox ID="txtKitchenLength" runat="server" TextMode="Number"></asp:TextBox></div>
</div>
<div class="row">
    <div class="col">
        GarageSize
        <asp:DropDownList ID="ddlGarageSize" runat="server">
            <asp:ListItem>None</asp:ListItem>
            <asp:ListItem>2 cars</asp:ListItem>
            <asp:ListItem>3 cars</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="col">Image <asp:FileUpload ID="fileUpload" runat="server" /></div>
</div>
<div class="row">
    <div class="col">BuiltYear <asp:TextBox ID="txtBuiltYear" runat="server" TextMode="Number"></asp:TextBox></div>
    <div class="col">Price <asp:TextBox ID="txtPrice" runat="server" TextMode="Number"></asp:TextBox></div>
</div>
        
HomeDescription<br />
<asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
        
<%-- when user clicks this img btn, roomControls will be displayed (visible) --%>
<asp:ImageButton ID="imgBtnPlus" runat="server" Height="100px" Width="100px"   
ImageUrl="https://cdn-icons-png.flaticon.com/512/5244/5244841.png" />
        
<div id="roomControls" runat="server">
    <%-- the program will calculate the total dimensions of the house, bedroom #, bathroom # --%>
    Room <asp:TextBox ID="txtRoomName" runat="server"></asp:TextBox>
    <div class="row">
        <div class="col">Width <asp:TextBox ID="txtRoomWidth" runat="server" TextMode="Number"></asp:TextBox></div>
        <div class="col">Length <asp:TextBox ID="txtRoomLength" runat="server" TextMode="Number"></asp:TextBox></div>
    </div>
    <br />
    <asp:Button ID="btnAddRoom" runat="server" Text="Add Room" CssClass="btn btn-outline-primary"/>
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-outline-secondary"/>
</div>