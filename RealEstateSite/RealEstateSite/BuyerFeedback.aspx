<%@ Page Title="" Language="C#" MasterPageFile="~/MasterBuyer.Master" AutoEventWireup="true" CodeBehind="BuyerFeedback.aspx.cs" Inherits="RealEstateSite.BuyerFeedback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Stylesheet/BuyerFeedback.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="feedbackDiv">
    <asp:Label ID="homeidplaceholder" runat="server" CssClass="hidden"></asp:Label>
    <asp:Label ID="requestlbl" runat="server" Font-Size="X-Large" Font-Strikeout="False" Text="Here are the homes that you have visited"></asp:Label>
    </div>
</asp:Content>
