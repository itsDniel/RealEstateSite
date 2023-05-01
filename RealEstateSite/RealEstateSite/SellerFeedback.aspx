<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSeller.Master" AutoEventWireup="true" CodeBehind="SellerFeedback.aspx.cs" Inherits="RealEstateSite.SellerFeedback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="h1 title">
        <asp:Label ID="homeidplaceholder" runat="server" CssClass="hidden"></asp:Label>
        <asp:Label ID="searchlbl" runat="server" Font-Strikeout="False" Text="Check out the feedback(s)<br/>on your home"></asp:Label>
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
                                        <h4 class="card-text"><strong>
                                            <asp:Label ID="homeIDlbl" runat="server" CssClass="hidden" Text='<%#DataBinder.Eval(Container.DataItem, "HomeID") %>'></asp:Label>
                                            <asp:Label ID="addresslbl" runat="server" Text='<%# "Address: " + DataBinder.Eval(Container.DataItem, "Address") %>'></asp:Label>
                                        </h4></strong>
                                        <p class="card-text">
                                            <asp:Label ID="namelbl" runat="server" Text='<%# "From: " + DataBinder.Eval(Container.DataItem, "BuyerName") %>'></asp:Label>
                                        </p>
                                        <p class="card-text">
                                            <asp:Label ID="pricelbl" runat="server" Text='<%# "Is the asking price reasonable: " + DataBinder.Eval(Container.DataItem, "PriceIsOk") %>'></asp:Label>
                                        </p>
                                        <p class="card-text">
                                            <asp:Label ID="locationlbl" runat="server" Text='<%#"Is the location convenient: " + DataBinder.Eval(Container.DataItem, "LocationIsOk") %>'></asp:Label>
                                        </p>
                                        <p class="card-text">
                                            <asp:Label ID="commentlbl" runat="server" Text='<%#"Additional Comment: " + DataBinder.Eval(Container.DataItem, "HomeComment") %>'></asp:Label>
                                        </p>
                                        <p class="card-text">
                                            <asp:Label ID="ratinglbl" runat="server" Text='<%#"Rating: " + DataBinder.Eval(Container.DataItem, "Rating") %>'></asp:Label>
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
