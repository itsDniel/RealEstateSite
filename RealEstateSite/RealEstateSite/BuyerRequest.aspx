<%@ Page Title="" Language="C#" MasterPageFile="~/MasterBuyer.Master" AutoEventWireup="true" CodeBehind="BuyerRequest.aspx.cs" Inherits="RealEstateSite.BuyerRequest" %>

<%@ Register Src="~/VisitRequest.ascx" TagPrefix="uc1" TagName="VisitRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Stylesheet/BuyerVisitRequest.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="requestMessage">
        <asp:Label ID="homeidplaceholder" runat="server" CssClass="hidden"></asp:Label>
        

    </div>
    
        <uc1:VisitRequest ID="requestdtl" runat="server" Visible="false"></uc1:VisitRequest>
    
</asp:Content>
