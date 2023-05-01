<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSeller.Master" AutoEventWireup="true" CodeBehind="HouseProfile.aspx.cs" Inherits="RealEstateSite.HouseProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>House Profile</h1>

    <div class="" id="houseContainer" runat="server">
        <%-- HouseProfileCtrl (custom control) will be dynamically added to this page for each house record --%>
    </div>
</asp:Content>