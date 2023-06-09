﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HouseProfileCtrl.ascx.cs" Inherits="RealEstateSite.HouseProfileCtrl" %>
<%@ Register Src="~/HouseControl.ascx" TagPrefix="uc1" TagName="HouseControl" %>

<div class="container w-75 bg-light bg-opacity-75 px-4">
    <br />
    <div class="row">
        <div class="col text-center"><asp:Image ID="img" runat="server" Height="350px" Width="501px" /></div>
    </div>
    <br />
    <div class="row">
        <div class="col">House Id: <asp:Label ID="lblId" runat="server" Text="Label"></asp:Label></div>
    </div>
    <div class="row">
        <%-- Status will be updated when user accepts an offer --%>
        <div class="col">Status: <asp:Label ID="lblStatus" runat="server" Text="Label"></asp:Label></div>
        <div class="col">
            <%-- if logged in user is a seller, display Agent's full name and vice versa --%>
            <div class="col">Full Name: <asp:Label ID="lblFullName" runat="server" Text="Label"></asp:Label></div>
        </div>
    </div>
    <div class="row">
        <%-- if logged in user is a seller, display Agent's contact info and vice versa --%>
        <div class="col">Phone number: <asp:Label ID="lblPhone" runat="server" Text="Label"></asp:Label></div>
        <div class="col">Email: <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label></div>
    </div>
    <div class="row">
        <%-- Buyer will be updated when user accepts an offer --%>
        <div class="col">Buyer: <asp:Label ID="lblBuyer" runat="server" Text="Label"></asp:Label></div>
        <div class="col">House Size (sq ft): <asp:Label ID="lblHomeSize" runat="server" Text="Label"></asp:Label></div>
    </div>

    <uc1:HouseControl runat="server" ID="houseCtrl" />

    <br />
    <div class="text-center">
        <asp:Button ID="btnUpdateImg" runat="server" Text="Update Image" CssClass="btn btn-outline-dark" OnClick="btnUpdateImg_Click"/>
        <asp:Button ID="btnUpdate" runat="server" Text="Update House" CssClass="btn btn-outline-primary" OnClick="btnUpdate_Click"/>
        <asp:Button ID="btnDelete" runat="server" Text="Delete House" CssClass="btn btn-outline-danger" OnClick="btnDelete_Click"/>
    </div>
    <br />

    <%-- Room --%>
    <div class="row">
        <div class="col">Number of bedroom: <asp:Label ID="lblBedroom" runat="server" Text="Label"></asp:Label></div>
        <div class="col">Number of bathroom: <asp:Label ID="lblBathroom" runat="server" Text="Label"></asp:Label></div>
    </div>
    <br />

    <div class="text-center">
        <asp:GridView ID="gvRooms" runat="server" AutoGenerateColumns="False" OnRowCommand="gvRooms_RowCommand">
            <Columns>
                <asp:BoundField DataField="RoomName" HeaderText="Room" />
                <asp:TemplateField HeaderText="Length">
                    <ItemTemplate>
                        <asp:TextBox ID="txtLength"  TextMode="Number" runat="server" Text='<%# Bind("Length") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Width">
                    <ItemTemplate>
                        <asp:TextBox ID="txtWidth" TextMode="Number" runat="server" Text='<%# Bind("Width") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:ButtonField HeaderText="Update" Text="Update" CommandName="UpdateRoom">
                    <ControlStyle CssClass="btn btn-outline-primary" />
                </asp:ButtonField>
                <asp:ButtonField HeaderText="Delete" Text="Delete" CommandName="DeleteRoom">
                    <ControlStyle CssClass="btn btn-outline-danger" />
                </asp:ButtonField>
            </Columns>
        </asp:GridView>
    </div>
    <br />
    <asp:Label ID="lblInstruction" runat="server" Text="Label"></asp:Label><br />

    <%-- when user clicks this img btn, roomControls will be displayed (visible) --%>
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
    <br />
</div>
<br />