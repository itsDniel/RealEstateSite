﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSeller.Master" AutoEventWireup="true" CodeBehind="SellerRequest.aspx.cs" Inherits="RealEstateSite.SellerRequest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Stylesheet/SellerFeedback.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="searchMessage">
        <asp:Label ID="homeidplaceholder" runat="server" CssClass="hidden"></asp:Label>
        <asp:Label ID="searchlbl" runat="server" Font-Size="X-Large" Font-Strikeout="False" Text="Check out the visit request(s) on your home"></asp:Label>
    </div>

    <asp:Panel ID="OverlayPanel" runat="server" CssClass="overlay" Visible="false"></asp:Panel>

    <div class="d-flex justify-content-center">
            <div class="container">
    
    <asp:Panel ID="SearchPanel" runat="server" Visible="true">
        <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater ID="rprDisplay" runat="server">
           
            <ItemTemplate>
               
                <div class="col">    
                <div class="card w-75 text-center mt-3">
                    <asp:Image ID="HomeImg" runat="server" ImageUrl='<%# Eval("Image") %>' />
                    <div class="card-body">
                        <h1 class="card-text">
                            <asp:Label ID="homeIDlbl" runat="server" CssClass="hidden" Text='<%#DataBinder.Eval(Container.DataItem, "HomeID") %>'></asp:Label>
                            <asp:Label ID="addresslbl" runat="server" Text='<%# "Address: " + DataBinder.Eval(Container.DataItem, "Address") %>'></asp:Label>
                        </h1>
                        <p class="card-text">
                            <asp:Label ID="namelbl" runat="server" Text='<%# "From: " + DataBinder.Eval(Container.DataItem, "BuyerName") %>'></asp:Label>
                        </p>
                        <p class="card-text">
                            <asp:Label ID="datelbl" runat="server" Text='<%# "Date Requested: " + ((DateTime)Eval("DateRequested")).ToString("MM/dd/yyyy") %>'></asp:Label>
                        </p>
                        <p class="card-text">
                            <asp:Label ID="timelbl" runat="server" Text='<%#"Time Requested: " + DataBinder.Eval(Container.DataItem, "TimeRequested") %>'></asp:Label>
                        </p>

                        
                    </div>
                </div>
          </div>
                
            </ItemTemplate>
               
        </asp:Repeater>
            </div> 
    </asp:Panel>
                </div>
</div>
</asp:Content>
