<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSeller.Master" AutoEventWireup="true" CodeBehind="AddHouse.aspx.cs" Inherits="RealEstateSite.AddHouse" %>

<%@ Register Src="~/HouseControl.ascx" TagPrefix="uc1" TagName="HouseControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="text-center">Add A House</h1>

    <div class="container w-75 bg-info bg-opacity-25">
        <br />
        <asp:Label ID="lblInstruction" runat="server" Text="Label"></asp:Label>
        <uc1:HouseControl runat="server" ID="hc" />
        <br />
        <div class="text-center"><asp:Button ID="btnAddHouse" runat="server" Text="Add House" OnClick="btnAddHouse_Click"/></div>
        <br />
    </div>
</asp:Content>