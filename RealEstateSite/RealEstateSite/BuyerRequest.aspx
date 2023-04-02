<%@ Page Title="" Language="C#" MasterPageFile="~/MasterBuyer.Master" AutoEventWireup="true" CodeBehind="BuyerRequest.aspx.cs" Inherits="RealEstateSite.BuyerRequest" %>

<%@ Register Src="~/VisitRequest.ascx" TagPrefix="uc1" TagName="VisitRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Stylesheet/BuyerVisitRequest.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="requestMessage">
        
    <asp:Label ID="homeidplaceholder" runat="server" CssClass="hidden"></asp:Label>
    <asp:Label ID="requestlbl" runat="server" Font-Size="X-Large" Font-Strikeout="False" Text="Here you can see the status of your visit request"></asp:Label>
    <asp:DropDownList ID="statusddl" runat="server">
            <asp:ListItem>Pending</asp:ListItem>
            <asp:ListItem>Approved</asp:ListItem>
            <asp:ListItem>Denied</asp:ListItem>
        </asp:DropDownList>
    <asp:Button ID="Searchbtn" runat="server" Text="Search" OnClick="Searchbtn_Click" />
   </div>
    <div class="datalist">
    <uc1:VisitRequest ID="requestdtl" runat="server" Visible="false"></uc1:VisitRequest>
    </div>
</asp:Content>
