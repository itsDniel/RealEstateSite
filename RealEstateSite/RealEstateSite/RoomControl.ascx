<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RoomControl.ascx.cs" Inherits="RealEstateSite.RoomControl" %>

<%-- when user clicks this img btn, roomControls will be displayed (visible) --%>
<asp:Label ID="lblInstruction" runat="server" Text="Label"></asp:Label><br />

<asp:ImageButton ID="imgBtnPlus" runat="server" Height="100px" Width="100px"   
ImageUrl="https://cdn-icons-png.flaticon.com/512/5244/5244841.png" OnClick="imgBtnPlus_Click" />
        
<div id="roomControls" runat="server">
    <%-- the program will calculate the total dimensions of the house, bedroom #, bathroom # --%>
    Room <asp:TextBox ID="txtRoomName" runat="server"></asp:TextBox>
    <div class="row">
        <div class="col">Width <asp:TextBox ID="txtRoomWidth" runat="server" TextMode="Number"></asp:TextBox></div>
        <div class="col">Length <asp:TextBox ID="txtRoomLength" runat="server" TextMode="Number"></asp:TextBox></div>
    </div>
    <br />
    <asp:Button ID="btnAddRoom" runat="server" Text="Add Room" CssClass="btn btn-outline-primary" OnClick="btnAddRoom_Click"/>
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-outline-secondary" OnClick="btnCancel_Click"/>
</div>