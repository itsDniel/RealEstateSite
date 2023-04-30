<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSeller.Master" AutoEventWireup="true" CodeBehind="SellerOffer.aspx.cs" Inherits="RealEstateSite.SellerOffer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center">
        <asp:Label ID="homeidplaceholder" runat="server" CssClass="hidden"></asp:Label>
        <asp:Label ID="buyerplaceholder" runat="server" CssClass="hidden"></asp:Label>
        <asp:Button ID="Accepthiddenbtn" Text="Accept" CssClass="hidden" runat="server" CausesValidation="False" />
        <asp:Button ID="Denyhiddenbtn" Text="Deny" CssClass="hidden" runat="server" CausesValidation="False" />
        <div class="h1 title">
            <asp:Label ID="searchlbl" runat="server" Font-Strikeout="False" Text="Check out offer(s) for your home"></asp:Label>
        </div>
    </div>

    <div class="d-flex justify-content-center">
        <div class="container">
            <asp:Panel ID="SearchPanel" runat="server" Visible="true">
                <div class="row row-cols-1 row-cols-md-3 g-4">
                    <asp:Repeater ID="rprDisplay" runat="server" OnItemCommand="rptDisplay_ItemCommand">
                        <ItemTemplate>
                            <div class="col">    
                                <div class="card w-75 text-center mt-3">
                                    <asp:Image ID="HomeImg" runat="server" ImageUrl='<%# Eval("Image") %>' />
                                    <div class="card-body">
                                        <h1 class="card-text">
                                            <asp:Label ID="homeIDlbl" runat="server" CssClass="hidden" Text='<%#DataBinder.Eval(Container.DataItem, "HomeID") %>'></asp:Label>
                                            <asp:Label ID="buyerlbl" runat="server" CssClass="hidden" Text='<%#DataBinder.Eval(Container.DataItem, "BuyerUsername") %>'></asp:Label>
                                            <asp:Label ID="addresslbl" runat="server" Text='<%# "Address: " + DataBinder.Eval(Container.DataItem, "Address") %>'></asp:Label>
                                        </h1>
                                        <p class="card-text">
                                            <asp:Label ID="namelbl" runat="server" Text='<%# "From: " + DataBinder.Eval(Container.DataItem, "BuyerName") %>'></asp:Label>
                                        </p>
                                        <asp:Button ID="btnDetail" Text="More Detail" runat="server" Visible="true" />
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div> 
            </asp:Panel>
        </div>
    </div>   

    <asp:Panel ID="DetailPanel" runat="server" Visible="false" CssClass="modalPopUp">
        <asp:Repeater ID="rprDetail" runat="server">
            <ItemTemplate>
                <div class="card w-100 text-center">
                    <asp:Image ID="HomeImg" runat="server" ImageUrl='<%# Eval("Image") %>' />
                    <div class="card-body">
                        <h1 class="card-text">
                            <asp:Label ID="homeIDlbl" runat="server" CssClass="hidden" Text='<%#DataBinder.Eval(Container.DataItem, "HomeID") %>'></asp:Label>
                            <asp:Label ID="buyerlbl" runat="server" CssClass="hidden" Text='<%#DataBinder.Eval(Container.DataItem, "BuyerUsername") %>'></asp:Label>
                            <asp:Label ID="addresslbl" runat="server" Text='<%# "Address: " + DataBinder.Eval(Container.DataItem, "Address") %>'></asp:Label>
                        </h1>
                        <p class="card-text">
                            <asp:Label ID="namelbl" runat="server" Text='<%# "From: " + DataBinder.Eval(Container.DataItem, "BuyerName") %>'></asp:Label>
                        </p>
                        <p class="card-text">
                            <asp:Label ID="amountlbl" runat="server" Text='<%# "Offer amount: " + DataBinder.Eval(Container.DataItem, "OfferAmount") %>'></asp:Label>
                        </p>
                        <p class="card-text">
                            <asp:Label ID="salelbl" runat="server" Text='<%#"Sale type: " + DataBinder.Eval(Container.DataItem, "SaleType") %>'></asp:Label>
                        </p>
                        <p class="card-text">
                            <asp:Label ID="conditionlbl" runat="server" Text='<%#"Sale condition: " + DataBinder.Eval(Container.DataItem, "SaleCondition") %>'></asp:Label>
                        </p>
                        <asp:Button ID="btnDeny" Text="Deny" runat="server" OnClick="OfferDenybtn_Click"/>&nbsp&nbsp
                        <asp:Button ID="btnAccept" Text="Accept" runat="server" OnClick="OfferAcceptbtn_Click"/>&nbsp&nbsp
                        <asp:Button ID="btnClose" Text="Close" runat="server" OnClick="btnClose_Click"/>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </asp:Panel>
</asp:Content>
